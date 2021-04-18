using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGridButton : MonoBehaviour
{
    [SerializeField]
    private Image buttonImage;

    public int ButtonId { get; set; }

    private void Start()
    {
        //buttonImage = 
            //SaveController.Instance.SaveDataCollection.saveDataList[ButtonId].screenshotPath;
    }

    public void OnButtonClick()
    {
        SaveController.Instance.LoadSingleSaveData(ButtonId);
    }
}
