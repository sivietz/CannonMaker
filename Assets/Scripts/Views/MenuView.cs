using System;
using UnityEngine;

public class MenuView : BaseView
{
    public Action OnCreateButton;
    public Action OnOpenButton;

    public void OnCreateButtonClicked()
    {
        OnCreateButton?.Invoke();
    }

    public void OnOpenButtonClicked()
    {
        OnOpenButton?.Invoke();
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
