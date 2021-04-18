using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenView : BaseView
{
    public Action<int> OnSaveFileChosen;

    [SerializeField]
    private GameObject gridItem;
    [SerializeField]
    private RectTransform content;
    [SerializeField]
    private GridLayoutGroup gridLayoutGroup;

    private List<SaveFileButton> saveFileButtons = new List<SaveFileButton>();

    public void CreateGridButton(int saveId)
    {
        GameObject saveFileButtonObject = Instantiate(gridItem, content, false);
        SaveFileButton saveFileButton = saveFileButtonObject.GetComponent<SaveFileButton>();
        saveFileButton.ButtonId = saveId;
        saveFileButtons.Add(saveFileButton);
        gridLayoutGroup.enabled = true;
    }

    public void SubscribeButtonActions()
    {
        foreach (var button in saveFileButtons)
        {
            button.OnButtonClicked += FileSaveButtonClicked;
        }
    }

    public void UnsubscribeButtonActions()
    {
        foreach (var button in saveFileButtons)
        {
            button.OnButtonClicked -= FileSaveButtonClicked;
        }
    }

    private void FileSaveButtonClicked(int buttonId)
    {
        OnSaveFileChosen?.Invoke(buttonId);
    }
}
