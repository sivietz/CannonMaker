using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New MaterialColorsData", fileName = "MaterialColorsData")]
public class MaterialColorsData : ScriptableObject, ISaveable
{
    [SerializeField]
    private List<CannonMaterial> cannonMaterials;

    private void Start()
    {
        SetDefaultColors();
    }

    public void SetDefaultColors()
    {
        foreach (var material in cannonMaterials)
        {
            material.material.color = material.defaultColor;
        }
    }

    public void LoadData(SaveData save)
    {
        for (int i = 0; i < cannonMaterials.Count; i++)
        {
            //cannonMaterials[i].materialColor.color = save.cannonMaterialsColors[i].materialColor;
            for (int j = 0; j < save.cannonMaterialsColors.Count; j++)
            {
                if(cannonMaterials[i].materialId == save.cannonMaterialsColors[j].materialId)
                {
                    cannonMaterials[i].material.color = save.cannonMaterialsColors[j].materialColor;
                    break;
                }
                cannonMaterials[i].material.color = cannonMaterials[i].defaultColor;
            }
        }
    }

    public void SaveData(SaveData save)
    {
        foreach (var cannonMaterial in cannonMaterials)
        {
            save.cannonMaterialsColors.Add(new CannonMaterialColor(cannonMaterial.materialId, cannonMaterial.material.color));
        }
    }
}
