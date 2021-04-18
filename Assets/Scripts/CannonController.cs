using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour, ISaveable
{
    public static Action OnCannonPartChanged;

    [SerializeField]
    private CannonPartController barrelController;
    [SerializeField]
    private CannonPartController standController;
    [SerializeField]
    private CannonPartController wheelsController;

    private void Start()
    {
        OnCannonPartChanged += AlignCannonParts;
        //SaveView.OnSave += SaveCurrentCannon;
        GenerateRandomCannon();
    }


    private void OnDestroy()
    {
        OnCannonPartChanged -= AlignCannonParts;
        //SaveView.OnSave -= SaveCurrentCannon;
    }

    private void AlignCannonParts()
    {
        StandAnchors standAnchors = standController.CurrentPartTransform.GetComponent<StandAnchors>();
        Vector3 distanceFromStandToWheels = wheelsController.CurrentPartTransform.position - standAnchors.WheelAnchor.position;
        standController.CurrentPartTransform.Translate(distanceFromStandToWheels);
        barrelController.CurrentPartTransform.position = standAnchors.BarrelAnchor.position;
    }

    private void GenerateRandomCannon()
    {
        barrelController.SetCannonPart(UnityEngine.Random.Range(0, barrelController.CannonParts.Count));
        standController.SetCannonPart(UnityEngine.Random.Range(0, standController.CannonParts.Count));
        wheelsController.SetCannonPart(UnityEngine.Random.Range(0, standController.CannonParts.Count));

        AlignCannonParts();
    }

    public void SaveData(SaveData saveData)
    {
        barrelController.SaveData(saveData);
        standController.SaveData(saveData);
        wheelsController.SaveData(saveData);
    }

    public void LoadData(SaveData save)
    {
        barrelController.LoadData(save);
        standController.LoadData(save);
        wheelsController.LoadData(save);
        AlignCannonParts();
    }
}


