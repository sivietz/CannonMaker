public abstract class BaseState
{
    public ApplicationStateController stateController;

    public abstract void EnterState();
    public abstract void ExitState();
}
