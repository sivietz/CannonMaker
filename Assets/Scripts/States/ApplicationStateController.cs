using UnityEngine;

public class ApplicationStateController : MonoBehaviour
{
    [SerializeField]
    private ApplicationViews appViews;

    private BaseState currentState;

    public ApplicationViews AppViews => appViews;

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
