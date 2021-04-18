using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveView : MonoBehaviour
{
    public static Action OnSave;

    public void OnSaveButtonClick()
    {
        OnSave?.Invoke();
        //Save.Instance.AddNewCannonToList
    }
}
