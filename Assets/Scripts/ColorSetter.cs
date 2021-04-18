using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetter : MonoBehaviour
{
    [SerializeField]
    private Material material;
    [SerializeField]
    private Image colorIndicatorImage;
    [SerializeField]
    private Slider rSlider;
    [SerializeField]
    private Slider gSlider;
    [SerializeField]
    private Slider bSlider;

    private Color defaultMaterialColor;

    private void Start()
    {
        defaultMaterialColor = material.color;
        colorIndicatorImage.color = material.color;
    }

    private void OnDestroy()
    {
        material.color = defaultMaterialColor;
    }

    public void ChangeColor()
    {
        Color color = material.color;
        color.r = rSlider.value;
        color.g = gSlider.value;
        color.b = bSlider.value;
        material.color = color;
        colorIndicatorImage.color = color;
    }
}
