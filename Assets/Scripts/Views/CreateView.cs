using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateView : BaseView
{
    [SerializeField]
    private List<CannonPartView> cannonPartViews;

    public Action<CannonPartType> OnPreviousButtonClicked;
    public Action<CannonPartType> OnNextButtonClicked;
    public Action OnSaveButtonClicked;

    public void SubscribeToViewActions()
    {
        foreach (var view in cannonPartViews)
        {
            view.OnNextButtonClicked += OnNextButton;
            view.OnPreviousButtonClicked += OnPreviousButton;
        }
    }

    public void UnsubscribeToViewActions()
    {
        foreach (var view in cannonPartViews)
        {
            view.OnNextButtonClicked -= OnNextButton;
            view.OnPreviousButtonClicked -= OnPreviousButton;
        }
    }

    private void OnPreviousButton(CannonPartType cannonPartType)
    {
        OnPreviousButtonClicked?.Invoke(cannonPartType);
    }

    private void OnNextButton(CannonPartType cannonPartType)
    {
        OnNextButtonClicked?.Invoke(cannonPartType);
    }

    public void OnSaveButton()
    {
        OnSaveButtonClicked?.Invoke();
    }
}
