using System.Collections;
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

    public List<GameObject> CannonParts => cannonParts;
    public CannonPartType CannonPartType => cannonPartType;
    public int CurrentPartId => currentPartId;

    public Transform CurrentPartTransform
    {
        get
        {
            return currentPartTransform;
        }
        set
        {
            currentPartTransform = value;
            cannonParts[currentPartId].transform.position = value.position;
            cannonParts[currentPartId].transform.rotation = value.rotation;
        }
    }

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

    public void LoadData(SaveData save)
    {
        foreach (var part in save.cannonParts)
        {
            if (part.cannonPartType == CannonPartType)
            {
                SetCannonPart(part.cannonPartId);
                break;
            }
        }
    }

    public void SaveData(SaveData saveData)
    {
        saveData.cannonParts.Add(new CannonPart(cannonPartType, currentPartId));
    }
}
