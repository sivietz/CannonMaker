using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cannon : ISaveable
{
    [SerializeField]
    private int BarrelId;
    [SerializeField]
    private int StandId;
    [SerializeField]
    private int WheelsId;

    //public List<string> MaterialColorsHex { get; private set; }
    public List<Color> MaterialColors { get; private set; }

    public Cannon(int barrelId, int standId, int wheelsId)//, List<Color> materialColors)
    {
        BarrelId = barrelId;
        StandId = standId;
        WheelsId = wheelsId;
        //MaterialColorsHex = ConvertColorsToHex(materialColors);
        //MaterialColors = materialColors;
    }

    private List<string> ConvertColorsToHex(List<Color> colors)
    {
        List<string> convertedColors = new List<string>();
        foreach (var color in colors)
        {
            convertedColors.Add(ColorUtility.ToHtmlStringRGB(color));
        }

        return convertedColors;
    }

    public void SaveData(SaveData save)
    {
        //save.AddNewCannonToList()
    }

    public void LoadData(SaveData save)
    {
        throw new NotImplementedException();
    }
}
