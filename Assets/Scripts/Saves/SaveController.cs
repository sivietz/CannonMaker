using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveController : MonoBehaviour
{
    public Action OnJsonDataLoaded;

    private const string JsonFileName = "save.json";
    private const string ScreenshotFolderName = "Screenshots";
    private const string ResourcesFolderName = "Resources";

    [SerializeField]
    private CannonController cannonController;
    [SerializeField]
    private MaterialColorsData materialColors;
    [SerializeField]
    private Camera screenshotCamera;

    private string jsonPath;
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
        if (!Directory.Exists(Path.Combine(Application.dataPath, ResourcesFolderName)))
        {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, ResourcesFolderName));
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
        cannonController.LoadData(saveToLoad);
        materialColors.LoadData(saveToLoad);
    }

    public void SaveScreenshot()
    {
        StartCoroutine(SaveImageAtTheEndOfFrame());
    }

    public Sprite GetScreenshotImageBySaveId(int saveId)
    {
        Sprite sprite = Resources.Load<Sprite>(SaveDataCollection.saveDataList[saveId].screenshotPath) as Sprite;
        //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        return sprite;
    }

    private IEnumerator SaveImageAtTheEndOfFrame()
    {
        yield return endOfFrame;

        RenderTexture renderTexture = new RenderTexture(screenshotCamera.pixelWidth, screenshotCamera.pixelHeight, 0);
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
            screenshotPath = screenshotPath
        };
        cannonController.SaveData(saveData);
        materialColors.SaveData(saveData);
        SaveDataCollection.saveDataList.Add(saveData);
    }

    private string GenerateScreenshotPath()
    {
        screenshotPath = Path.Combine(Application.dataPath, ResourcesFolderName, $"{DateTime.Now:yyyy-MM-dd-HHmmss}.png");
        return screenshotPath;
    }
}
