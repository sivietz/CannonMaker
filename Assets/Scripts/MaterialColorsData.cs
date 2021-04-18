using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorsData : MonoBehaviour, ISaveable
{
    [SerializeField]
    private List<Material> materials;
    //todo
    public void LoadData(SaveData save)
    {
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].color = save.cannonMaterialsColors[i];
        }
    }

    public void SaveData(SaveData save)
    {
        foreach (var material in materials)
        {
            save.cannonMaterialsColors.Add(material.color);
        }
    }

    //public List<Color> MaterialColors => materialColors;
}
