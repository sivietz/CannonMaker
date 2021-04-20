using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetter : MonoBehaviour
{
    public Action<int, Color> OnColorChanged;
    public Action OnCloseButton;

    [SerializeField]
    private Slider rSlider;
    [SerializeField]
    private Slider gSlider;
    [SerializeField]
    private Slider bSlider;
    [SerializeField]
    private Button closeButon;

    private Color color;
    private int currentMaterialId;

    public void OpenColorSetter(int materialId)
    {
        this.currentMaterialId = materialId;
    }

    public void SetSliderValues(Color color)
    {
        rSlider.value = color.r;
        gSlider.value = color.g;
        bSlider.value = color.b;
    }

    public void OnSliderValueChanged()
    {
        color.r = rSlider.value;
        color.g = gSlider.value;
        color.b = bSlider.value;
        color.a = 1;
        OnColorChanged?.Invoke(currentMaterialId, color);
    }

    public void OnCloseButtonClicked()
    {
        OnCloseButton?.Invoke();
    }
}
