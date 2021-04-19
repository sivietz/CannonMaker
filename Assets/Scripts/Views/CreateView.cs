using System;
using System.Collections.Generic;
using UnityEngine;

public class CreateView : BaseView
{
    [SerializeField]
    private List<CannonPartView> cannonPartViews;

    public Action<CannonPartType> OnPreviousButton;
    public Action<CannonPartType> OnNextButton;
    public Action OnSaveButton;
    public Action OnMenuButton;

    public void SubscribeToViewActions()
    {
        foreach (var view in cannonPartViews)
        {
            view.OnNextButtonClicked += OnNextButtonClicked;
            view.OnPreviousButtonClicked += OnPreviousButtonClicked;
        }
    }

    public void UnsubscribeToViewActions()
    {
        foreach (var view in cannonPartViews)
        {
            view.OnNextButtonClicked -= OnNextButtonClicked;
            view.OnPreviousButtonClicked -= OnPreviousButtonClicked;
        }
    }

    private void OnPreviousButtonClicked(CannonPartType cannonPartType)
    {
        OnPreviousButton?.Invoke(cannonPartType);
    }

    private void OnNextButtonClicked(CannonPartType cannonPartType)
    {
        OnNextButton?.Invoke(cannonPartType);
    }

    public void OnSaveButtonClicked()
    {
        OnSaveButton?.Invoke();
    }

    public void OnMenuButtonClicked()
    {
        OnMenuButton.Invoke();
    }
}
