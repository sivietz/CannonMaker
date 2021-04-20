using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public Action<int> OnColorButton;

    [SerializeField]
    private Image buttonImage;
    //[SerializeField]
    //private ColorSetter colorSetter;

    public int materialId;

    public void OnColorButtonClicked()
    {
        //colorSetter.gameObject.SetActive(true);
        //colorSetter.OnColorChanged += SetButtonImageColor;
        //colorSetter.OnCloseButton += HideColorSetter;
        OnColorButton?.Invoke(materialId);
    }

    public void SetButtonImageColor(int materialId, Color color)
    {
        if(this.materialId == materialId)
        {
            buttonImage.color = color;
        }
    }



    private void HideColorSetter()
    {
        //colorSetter.gameObject.SetActive(false);
        //colorSetter.OnColorChanged -= SetButtonImageColor;
        //colorSetter.OnCloseButton -= HideColorSetter;
    }
}
