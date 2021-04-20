public class GenerateState : BaseState
{
    public override void EnterState()
    {
        CannonController.Instance.GenerateRandomCannon();
        MaterialColorController.Instance.SetDefaultCannonColors();
        stateController.TransitionToState(new CreateState());
    }

    public override void ExitState()
    {
    }
}
