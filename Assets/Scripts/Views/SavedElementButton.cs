using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SavedElementButton : MonoBehaviour
{
    [SerializeField]
    private Image buttonImage;

    public Action<int> OnButtonClicked;

    public int ButtonId { get; set; }

    public void OnButtonClick()
    {
        OnButtonClicked?.Invoke(ButtonId);
    }

    public void SetButtonImage(Sprite sprite)
    {
        buttonImage.sprite = sprite;
    }
}
