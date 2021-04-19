using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New MaterialColorsData", fileName = "MaterialColorsData")]
public class MaterialColorsData : ScriptableObject, ISaveable
{
    [SerializeField]
    private List<CannonMaterial> cannonMaterials;

    public void SetDefaultColors()
    {
        foreach (var cannonMaterial in cannonMaterials)
        {
            cannonMaterial.SetDefaultColor();
        }
    }

    public void LoadData(SaveData save)
    {
        bool isColorAssigned = false;

        for (int i = 0; i < cannonMaterials.Count; i++)
        {
            for (int j = 0; j < save.cannonMaterialsColors.Count; j++)
            {
                if(cannonMaterials[i].MaterialId == save.cannonMaterialsColors[j].MaterialId)
                {
                    cannonMaterials[i].SetColor(save.cannonMaterialsColors[j].MaterialColor);
                    isColorAssigned = true;
                }
            }

            if (!isColorAssigned)
            {
                cannonMaterials[i].SetDefaultColor();
            }
            else
            {
                isColorAssigned = false;
            }
        }
    }

    public void SaveData(SaveData save)
    {
        foreach (var cannonMaterial in cannonMaterials)
        {
            save.cannonMaterialsColors.Add(new CannonMaterialColor(cannonMaterial.MaterialId, cannonMaterial.Material.color));
        }
    }
}
