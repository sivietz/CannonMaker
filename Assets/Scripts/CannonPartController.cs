using System.Collections.Generic;
using UnityEngine;

public class CannonPartController : MonoBehaviour, ISaveable
{
    [SerializeField]
    private CannonPartType cannonPartType;
    [SerializeField]
    private List<GameObject> cannonParts;

    private Transform currentPartTransform;
    private int currentPartId;

    public CannonPartType CannonPartType => cannonPartType;
    public Transform CurrentPartTransform => currentPartTransform;

    public void SetNextCannonPart()
    {
        if (currentPartId < cannonParts.Count - 1)
        {
            currentPartId++;
        }
        else
        {
            currentPartId = 0;
        }
        SetCannonPart(currentPartId);
    }

    public void SetPreviousCannonPart()
    {
        if (currentPartId > 0)
        {
            currentPartId--;
        }
        else
        {
            currentPartId = cannonParts.Count - 1;
        }
        SetCannonPart(currentPartId);
    }

    public void SetCannonPart(int id)
    {
        foreach (var part in cannonParts)
        {
            part.SetActive(false);
        }
        cannonParts[id].SetActive(true);
        currentPartTransform = cannonParts[id].transform;
        currentPartId = id;
    }

    public void SetRandomCannonPart()
    {
        SetCannonPart(Random.Range(0, cannonParts.Count));
    }

    public void LoadData(SaveData save)
    {
        bool isPartAssigned = false;
        foreach (var part in save.cannonParts)
        {
            if (part.CannonPartType == CannonPartType)
            {
                SetCannonPart(part.CannonPartId);
                isPartAssigned = true;
                break;
            }
        }

        if (!isPartAssigned)
        {
            SetRandomCannonPart();
        }
    }

    public void SaveData(SaveData saveData)
    {
        saveData.cannonParts.Add(new CannonPart(cannonPartType, currentPartId));
    }
}
