public class MenuState : BaseState
{
    private MenuView menuView;
    public override void EnterState()
    {
        menuView = stateController.AppViews.MenuView;
        menuView.OnOpenButton += OpenButtonClicked;
        menuView.OnCreateButton += CreateButtonClicked;
        SaveController.Instance.LoadFromJSON();
        stateController.AppViews.MenuView.DisplayView(true);
    }

    public override void ExitState()
    {
        menuView.OnOpenButton -= OpenButtonClicked;
        menuView.OnCreateButton -= CreateButtonClicked;
        menuView.DisplayView(false);
    }

    private void OpenButtonClicked()
    {
        stateController.TransitionToState(new OpenState());
    }

    private void CreateButtonClicked()
    {
        stateController.TransitionToState(new GenerateState());
    }
}
