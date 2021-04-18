using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFileButton : MonoBehaviour
{
    [SerializeField]
    private Image buttonImage;

    public Action<int> OnButtonClicked;

    public int ButtonId { get; set; }

    private void Start()
    {
        //buttonImage = 
            //SaveController.Instance.SaveDataCollection.saveDataList[ButtonId].screenshotPath;
    }

    public void OnButtonClick()
    {
        OnButtonClicked?.Invoke(ButtonId);
    }
}
