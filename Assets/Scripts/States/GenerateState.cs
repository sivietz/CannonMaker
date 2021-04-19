public class GenerateState : BaseState
{
    public override void EnterState()
    {
        CannonController.Instance.GenerateRandomCannon();
        stateController.TransitionToState(new CreateState());
    }

    public override void ExitState()
    {
    }
}
