using System;
using UnityEngine;

[Serializable]
public class CannonMaterialColor
{
    [SerializeField]
    private int materialId;
    [SerializeField]
    private Color materialColor;

    public int MaterialId => materialId;
    public Color MaterialColor => materialColor;

    public CannonMaterialColor(int materialId, Color materialColor)
    {
        this.materialId = materialId;
        this.materialColor = materialColor;
    }
}
