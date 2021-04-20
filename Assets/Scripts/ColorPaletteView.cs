using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteView : MonoBehaviour
{
    public Action<int> OnColorSetterOpened;

    [SerializeField]
    private List<ColorButton> colorButtons;
    [SerializeField]
    private ColorSetter colorSetter;

    private int currentMaterialId;

    public List<ColorButton> ColorButtons => colorButtons;
    public ColorSetter ColorSetter => colorSetter;

    private void DisplayColorSetter(int materialButtonId)
    {
        colorSetter.OpenColorSetter(materialButtonId);
        colorSetter.gameObject.SetActive(true);
        foreach (var button in colorButtons)
        {
            if (button.materialId == materialButtonId)
            {
                currentMaterialId = materialButtonId;
                colorSetter.OnColorChanged += button.SetButtonImageColor;
            }
        }
        OnColorSetterOpened?.Invoke(materialButtonId);
    }

    public void SubscribeToButtonActions()
    {
        foreach (var button in colorButtons)
        {
            button.OnColorButton += DisplayColorSetter;
        }
        colorSetter.OnCloseButton += HideColorSetter;
    }

    public void UnsubscribeToButtonActions()
    {
        foreach (var button in colorButtons)
        {
            button.OnColorButton -= DisplayColorSetter;
        }
        colorSetter.OnCloseButton -= HideColorSetter;
    }

    private void HideColorSetter()
    {
        colorSetter.gameObject.SetActive(false);
        foreach (var button in colorButtons)
        {
            if (button.materialId == currentMaterialId)
            {
                colorSetter.OnColorChanged -= button.SetButtonImageColor;
            }
        }
        //colorSetter.OnCloseButton -= HideColorSetter;
    }
}
