using UnityEngine;

public class CannonController : MonoBehaviour, ISaveable
{
    [SerializeField]
    private CannonPartController barrelController;
    [SerializeField]
    private CannonPartController standController;
    [SerializeField]
    private CannonPartController wheelsController;

    private static CannonController instance;

    public static CannonController Instance { get { return instance; } }

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

    public void AlignCannonParts()
    {
        StandAnchors standAnchors = standController.CurrentPartTransform.GetComponent<StandAnchors>();
        Vector3 distanceFromStandToWheels = wheelsController.CurrentPartTransform.position - standAnchors.WheelAnchor.position;
        standController.CurrentPartTransform.Translate(distanceFromStandToWheels);
        barrelController.CurrentPartTransform.position = standAnchors.BarrelAnchor.position;
    }

    public void GenerateRandomCannon()
    {
        barrelController.SetRandomCannonPart();
        standController.SetRandomCannonPart();
        wheelsController.SetRandomCannonPart();
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

    public void SetNextCannonPart(CannonPartType cannonPartType)
    {
        switch (cannonPartType)
        {
            case CannonPartType.Barrel:
                barrelController.SetNextCannonPart();
                break;
            case CannonPartType.Stand:
                standController.SetNextCannonPart();
                break;
            case CannonPartType.Wheels:
                wheelsController.SetNextCannonPart();
                break;
        }
        AlignCannonParts();
    }

    public void SetPreviousCannonPart(CannonPartType cannonPartType)
    {
        switch (cannonPartType)
        {
            case CannonPartType.Barrel:
                barrelController.SetPreviousCannonPart();
                break;
            case CannonPartType.Stand:
                standController.SetPreviousCannonPart();
                break;
            case CannonPartType.Wheels:
                wheelsController.SetPreviousCannonPart();
                break;
        }
        AlignCannonParts();
    }
}
