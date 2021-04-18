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

    [SerializeField]
    private CannonController cannonController;
    [SerializeField]
    private MaterialColorsData materialColors;

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

        if (!Directory.Exists(Path.Combine(Application.persistentDataPath, ScreenshotFolderName)))
        {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, ScreenshotFolderName));
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

        Debug.Log("save to: " + jsonPath);
        Debug.Log(json);
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

    public void SaveScreenshot(RenderTexture renderTexture)
    {
        StartCoroutine(SaveImageAtTheEndOfFrame(renderTexture));
    }

    private IEnumerator SaveImageAtTheEndOfFrame(RenderTexture renderTexture)
    {
        yield return endOfFrame;

        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false, false);

        texture.Apply(false);
        Graphics.CopyTexture(renderTexture, texture);


        //texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        //texture.ReadPixels(new Rect(new Vector2(renderTexture.pos), 0, 0);
        texture.Apply();
        var imageBytes = texture.EncodeToPNG();
        File.WriteAllBytes(screenshotPath, imageBytes);
    }

    private void PrepareDataToSave()
    {
        SaveData saveData = new SaveData
        {
            id = SaveDataCollection.saveDataList.Count,
            cannonParts = new List<CannonPart>(),
            cannonMaterialsColors = new List<Color>(),
            screenshotPath = screenshotPath
        };
        cannonController.SaveData(saveData);
        materialColors.SaveData(saveData);
        SaveDataCollection.saveDataList.Add(saveData);
    }

    private string GenerateScreenshotPath()
    {
        screenshotPath = Path.Combine(Application.persistentDataPath, ScreenshotFolderName, $"{DateTime.Now:yyyy-MM-dd-HHmmss}.png");
        return screenshotPath;
    }
}
