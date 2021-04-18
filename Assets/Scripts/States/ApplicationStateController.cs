using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationStateController : MonoBehaviour
{
    [SerializeField]
    private UIPanels uiPanels;

    private BaseState currentState;

    public UIPanels UIPanels => uiPanels;

    private void Start()
    {
        TransitionToState(new MenuState());
    }

    public void TransitionToState(BaseState state)
    {
        if(currentState != null)
        {
            currentState.ExitState();
        }
        currentState = state;
        if(currentState != null)
        {
            currentState.stateController = this;
            currentState.EnterState();
        }
    }
}
