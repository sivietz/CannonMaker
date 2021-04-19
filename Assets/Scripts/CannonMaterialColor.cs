using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CannonMaterialColor
{
    public int materialId;
    public Color materialColor;

    public CannonMaterialColor(int materialId, Color materialColor)
    {
        this.materialId = materialId;
        this.materialColor = materialColor;
    }
}
