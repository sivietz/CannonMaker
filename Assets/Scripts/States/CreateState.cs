public class CreateState : BaseState
{
    private CreateView createView;
    public override void EnterState()
    {
        MaterialColorController.Instance.SetUp();
        createView = stateController.AppViews.CreateView;
        createView.OnNextButton += SetNextCannonPart;
        createView.OnPreviousButton += SetPreviousCannonPart;
        createView.OnSaveButton += SaveButtonClicked;
        createView.OnMenuButton += MenuButtonClicked;
        createView.SubscribeToViewActions();
        createView.DisplayView(true);
    }

    public override void ExitState()
    {
        createView.DisplayView(false);
        createView.OnNextButton -= SetNextCannonPart;
        createView.OnPreviousButton -= SetPreviousCannonPart;
        createView.OnSaveButton -= SaveButtonClicked;
        createView.OnMenuButton -= MenuButtonClicked;
        createView.UnsubscribeToViewActions();
    }

    private void SetNextCannonPart(CannonPartType cannonPartType)
    {
        CannonController.Instance.SetNextCannonPart(cannonPartType);
    }

    private void SetPreviousCannonPart(CannonPartType cannonPartType)
    {
        CannonController.Instance.SetPreviousCannonPart(cannonPartType);
    }

    private void SaveButtonClicked()
    {
        SaveController.Instance.SaveToJSON();
        SaveController.Instance.SaveScreenshot();
    }

    private void MenuButtonClicked()
    {
        stateController.TransitionToState(new MenuState());
    }
}
