using System;
using UnityEngine;

[Serializable]
public class CannonPart
{
    [SerializeField]
    private CannonPartType cannonPartType;
    [SerializeField]
    private int cannonPartId;

    public CannonPartType CannonPartType => cannonPartType;
    public int CannonPartId => cannonPartId;

    public CannonPart(CannonPartType cannonPartType, int cannonPartId)
    {
        this.cannonPartType = cannonPartType;
        this.cannonPartId = cannonPartId;
    }
}
