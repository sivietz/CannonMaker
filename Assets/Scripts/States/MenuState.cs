public class MenuState : BaseState
{
    public override void EnterState()
    {
        stateController.UIPanels.MenuView.OnOpenClicked += OpenClicked;
        stateController.UIPanels.MenuView.OnCreateClicked += CreateClicked;
        SaveController.Instance.LoadFromJSON();
        stateController.UIPanels.MenuView.DisplayView(true);
    }

    public override void ExitState()
    {
        stateController.UIPanels.MenuView.OnOpenClicked -= OpenClicked;
        stateController.UIPanels.MenuView.OnCreateClicked -= CreateClicked;
        stateController.UIPanels.MenuView.DisplayView(false);
    }

    private void OpenClicked()
    {
        stateController.TransitionToState(new OpenState());
    }

    private void CreateClicked()
    {
        stateController.TransitionToState(new CreateState());
    }
}
