using System;
using UnityEngine;

public class CannonPartView : MonoBehaviour
{
    [SerializeField]
    private CannonPartType cannonPartType;

    public Action<CannonPartType> OnNextButtonClicked;
    public Action<CannonPartType> OnPreviousButtonClicked;

    public void OnNextButton()
    {
        OnNextButtonClicked.Invoke(cannonPartType);
    }

    public void OnPreviousButton()
    {
        OnPreviousButtonClicked.Invoke(cannonPartType);
    }
}
