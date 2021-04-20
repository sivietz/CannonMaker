using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int id;
    public List<CannonPart> cannonParts;
    public List<CannonMaterialColor> cannonMaterialsColors;
    public string imagePath;
}
