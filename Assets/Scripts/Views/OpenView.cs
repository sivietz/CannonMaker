using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenView : BaseView
{
    public Action<int> OnSaveChosen;
    public Action OnBackButton;

    [SerializeField]
    private GameObject gridItem;
    [SerializeField]
    private RectTransform gridContent;
    [SerializeField]
    private GridLayoutGroup gridLayoutGroup;

    private List<SavedElementButton> savedElementsButtons = new List<SavedElementButton>();

    public void SetupGridButton(int saveId)
    {
        if(!savedElementsButtons.Find(x => x.ButtonId == saveId))
        {
            GameObject savedElementButtonObject = Instantiate(gridItem, gridContent, false);
            SavedElementButton saveFileButton = savedElementButtonObject.GetComponent<SavedElementButton>();
            saveFileButton.ButtonId = saveId;
            Sprite sprite = SaveController.Instance.GetScreenshotImageBySaveId(saveId);
            if (sprite != null)
            {
                saveFileButton.SetButtonImage(sprite);
            }
            savedElementsButtons.Add(saveFileButton);
        }
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

    public void OnBackButtonClicked()
    {
        OnBackButton?.Invoke();
    }
}
