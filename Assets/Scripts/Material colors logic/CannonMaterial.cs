using System;
using UnityEngine;

[Serializable]
public class CannonMaterial
{
    [SerializeField]
    private int materialId;
    [SerializeField]
    private Color defaultColor;
    [SerializeField]
    private Material material;

    public int MaterialId => materialId;
    public Color DefaultColor => defaultColor;
    public Material Material => material;

    public void SetDefaultColor()
    {
        material.color = defaultColor;
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }
}
