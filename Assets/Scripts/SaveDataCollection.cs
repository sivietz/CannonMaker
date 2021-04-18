using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveDataCollection
{
    public List<SaveData> saveDataList;

    public SaveDataCollection()
    {
        saveDataList = new List<SaveData>();
    }
}
