using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : BaseView
{
    public Action OnCreateClicked;
    public Action OnOpenClicked;

    public void OnCreateButtonClicked()
    {
        OnCreateClicked.Invoke();
    }

    public void OnOpenButtonClicked()
    {
        OnOpenClicked.Invoke();
    }
}
