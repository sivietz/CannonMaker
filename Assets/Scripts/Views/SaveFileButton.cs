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

    public void OnButtonClick()
    {
        OnButtonClicked?.Invoke(ButtonId);
    }

    public void SetButtonImage(Sprite sprite)
    {
        buttonImage.sprite = sprite;
    }
}
