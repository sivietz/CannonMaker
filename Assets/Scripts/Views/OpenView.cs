using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenView : BaseView
{
    public Action<int> OnSaveChosen;

    [SerializeField]
    private GameObject gridItem;
    [SerializeField]
    private RectTransform gridContent;
    [SerializeField]
    private GridLayoutGroup gridLayoutGroup;

    private List<SavedElementButton> savedElementsButtons = new List<SavedElementButton>();

    public void CreateGridButton(int saveId)
    {
        GameObject savedElementButtonObject = Instantiate(gridItem, gridContent, false);
        SavedElementButton saveFileButton = savedElementButtonObject.GetComponent<SavedElementButton>();
        saveFileButton.ButtonId = saveId;
        Sprite sprite = SaveController.Instance.GetScreenshotImageBySaveId(saveId);
        saveFileButton.SetButtonImage(sprite);
        savedElementsButtons.Add(saveFileButton);
        gridLayoutGroup.enabled = true;
    }

    public void SubscribeButtonActions()
    {
        foreach (var button in savedElementsButtons)
        {
            button.OnButtonClicked += ChooseSaveToLoad;
        }
    }

    public void UnsubscribeButtonActions()
    {
        foreach (var button in savedElementsButtons)
        {
            button.OnButtonClicked -= ChooseSaveToLoad;
        }
    }

    private void ChooseSaveToLoad(int saveId)
    {
        OnSaveChosen?.Invoke(saveId);
    }
}
