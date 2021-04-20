using UnityEngine;

public class MaterialColorController : MonoBehaviour, ISaveable
{
    [SerializeField]
    private MaterialColorsData materialColorsData;
    [SerializeField]
    private ColorPaletteView colorPaletteView;

    private static MaterialColorController instance;

    private CannonMaterial currentlyUpdatedCannonMaterial;

    public CannonMaterial CurrentlyUpdatedCannonMaterial => currentlyUpdatedCannonMaterial;

    public static MaterialColorController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void SetUp()
    {
        PrepareColorPaletteView();
        colorPaletteView.SubscribeToButtonActions();
    }

    public void PrepareColorPaletteView()
    {
        if (colorPaletteView.ColorButtons.Count == materialColorsData.CannonMaterials.Count)
        {
            for (int i = 0; i < colorPaletteView.ColorButtons.Count; i++)
            {
                colorPaletteView.ColorButtons[i].materialId = materialColorsData.CannonMaterials[i].MaterialId;
                colorPaletteView.ColorButtons[i].SetButtonImageColor(colorPaletteView.ColorButtons[i].materialId, materialColorsData.CannonMaterials[i].Material.color);
                colorPaletteView.OnColorSetterOpened += SetCurrentlyUpdatedMaterial;
            }
        }
        else
        {
            Debug.LogError("The amount of color buttons does not correspond to the amount of materials.", this);
        }
    }

    private void SetCurrentlyUpdatedMaterial(int materialId)
    {
        currentlyUpdatedCannonMaterial = FindCannonMaterialById(materialId);
        colorPaletteView.ColorSetter.OnColorChanged += UpdateMaterialColor;
        colorPaletteView.ColorSetter.SetSliderValues(currentlyUpdatedCannonMaterial.Material.color);
    }

    private CannonMaterial FindCannonMaterialById(int id)
    {
        foreach (var cannonMatrial in materialColorsData.CannonMaterials)
        {
            if(cannonMatrial.MaterialId == id)
            {
                return cannonMatrial;
            }
        }
        Debug.LogError($"Could not find any material with id {id}");
        return null;
    }

    public void UnsubscribeEvents()
    {
        for (int i = 0; i < colorPaletteView.ColorButtons.Count; i++)
        {
            colorPaletteView.OnColorSetterOpened -= SetCurrentlyUpdatedMaterial;
        }
        colorPaletteView.ColorSetter.OnColorChanged -= UpdateMaterialColor;
        colorPaletteView.UnsubscribeToButtonActions();
    }

    private void UpdateMaterialColor(int materialId, Color color)
    {
        if(currentlyUpdatedCannonMaterial.MaterialId == materialId)
        {
            currentlyUpdatedCannonMaterial.SetColor(color);
        }
    }

    public void SetDefaultCannonColors()
    {
        materialColorsData.SetDefaultColors();
    }

    public void SaveData(SaveData save)
    {
        materialColorsData.SaveData(save);
    }

    public void LoadData(SaveData save)
    {
        materialColorsData.LoadData(save);
    }
}
