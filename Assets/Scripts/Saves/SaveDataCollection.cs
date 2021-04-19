using System;
using System.Collections.Generic;

[Serializable]
public class SaveDataCollection
{
    public List<SaveData> saveDataList;

    public SaveDataCollection()
    {
        saveDataList = new List<SaveData>();
    }
}
