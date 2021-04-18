using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CannonPart
{
    public CannonPartType cannonPartType;
    public int cannonPartId;

    public CannonPart(CannonPartType cannonPartType, int cannonPartId)
    {
        this.cannonPartType = cannonPartType;
        this.cannonPartId = cannonPartId;
    }
}
