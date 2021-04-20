using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public Action<int> OnColorButton;

    [SerializeField]
    private Image buttonImage;

    public int materialId;

    public void OnColorButtonClicked()
    {
        OnColorButton?.Invoke(materialId);
    }

    public void SetButtonImageColor(int materialId, Color color)
    {
        if(this.materialId == materialId)
        {
            buttonImage.color = color;
        }
    }
}
