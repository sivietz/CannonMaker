using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveController : MonoBehaviour
{
    public Action OnJsonDataLoaded;

    private const string JsonFileName = "save.json";
    private const string ScreenshotFolderName = "Screenshot";

    [SerializeField]
    private Camera screenshotCamera;

    private string jsonPath;
    private string screenshotDirectoryPath;
    private string screenshotPath;
    private WaitForEndOfFrame endOfFrame;
    private static SaveController instance;

    public SaveDataCollection SaveDataCollection { get; private set; }
    public static SaveController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        jsonPath = Path.Combine(Application.persistentDataPath, JsonFileName);
        screenshotDirectoryPath = Path.Combine(Application.persistentDataPath, ScreenshotFolderName);
        if (!Directory.Exists(screenshotDirectoryPath))
        {
            Directory.CreateDirectory(screenshotDirectoryPath);
        }
    }

    private void Start()
    {
        endOfFrame = new WaitForEndOfFrame();
    }

    public void SaveToJSON()
    {
        GenerateScreenshotPath();
        PrepareDataToSave();
        string json = JsonUtility.ToJson(SaveDataCollection);
        File.WriteAllText(jsonPath, json);
    }

    public void LoadFromJSON()
    {
        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            SaveDataCollection = JsonUtility.FromJson<SaveDataCollection>(json);
        }
        else
        {
            SaveDataCollection = new SaveDataCollection();
        }
    }

    public void LoadSingleSaveData(int id)
    {
        SaveData saveToLoad = SaveDataCollection.saveDataList[id];
        CannonController.Instance.LoadData(saveToLoad);
        MaterialColorController.Instance.LoadData(saveToLoad);
    }

    public void SaveScreenshot()
    {
        StartCoroutine(SaveImageAtTheEndOfFrame());
    }

    public Sprite GetScreenshotImageBySaveId(int saveId)
    {
        Texture2D texture = LoadPNG(SaveDataCollection.saveDataList[saveId].imagePath);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        return sprite;
    }

    private IEnumerator SaveImageAtTheEndOfFrame()
    {
        yield return endOfFrame;

        RenderTexture renderTexture = screenshotCamera.targetTexture;
        Texture2D screenshot = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false, false);
        screenshotCamera.targetTexture = renderTexture;
        screenshotCamera.Render();
        RenderTexture.active = screenshotCamera.targetTexture;
        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();
        var imageBytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(screenshotPath, imageBytes);
    }

    private void PrepareDataToSave()
    {
        SaveData saveData = new SaveData
        {
            id = SaveDataCollection.saveDataList.Count,
            cannonParts = new List<CannonPart>(),
            cannonMaterialsColors = new List<CannonMaterialColor>(),
            imagePath = screenshotPath
        };
        CannonController.Instance.SaveData(saveData);
        MaterialColorController.Instance.SaveData(saveData);
        SaveDataCollection.saveDataList.Add(saveData);
    }

    private Texture2D LoadPNG(string path)
    {
        Texture2D texture = null;
        byte[] fileData;

        if (File.Exists(path))
        {
            fileData = File.ReadAllBytes(path);
            texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            texture.LoadImage(fileData);
        }
        return texture;
    }

    private void GenerateScreenshotPath()
    {
        string fileName = $"{DateTime.Now:yyyy-MM-dd-HHmmss}.png";
        screenshotPath = Path.Combine(Application.persistentDataPath, ScreenshotFolderName, fileName);
    }
}
