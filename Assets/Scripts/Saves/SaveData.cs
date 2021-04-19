using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int id;
    public List<CannonPart> cannonParts;
    public List<CannonMaterialColor> cannonMaterialsColors;
    public string screenshotPath;
}
