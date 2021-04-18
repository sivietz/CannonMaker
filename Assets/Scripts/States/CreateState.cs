public class CreateState : BaseState
{
    public override void EnterState()
    {
        stateController.UIPanels.CreateView.OnNextButtonClicked += SetNextCannonPart;
        stateController.UIPanels.CreateView.OnPreviousButtonClicked += SetPreviousCannonPart;
        stateController.UIPanels.CreateView.OnSaveButtonClicked += SaveClicked;
        stateController.UIPanels.CreateView.SubscribeToViewActions();
        stateController.UIPanels.CreateView.DisplayView(true);
    }

    public override void ExitState()
    {
        stateController.UIPanels.CreateView.DisplayView(false);
        stateController.UIPanels.CreateView.OnNextButtonClicked -= SetNextCannonPart;
        stateController.UIPanels.CreateView.OnPreviousButtonClicked -= SetPreviousCannonPart;
        stateController.UIPanels.CreateView.OnSaveButtonClicked -= SaveClicked;
        stateController.UIPanels.CreateView.UnsubscribeToViewActions();
    }

    private void SetNextCannonPart(CannonPartType cannonPartType)
    {
        CannonController.Instance.SetNextCannonPart(cannonPartType);
    }

    private void SetPreviousCannonPart(CannonPartType cannonPartType)
    {
        CannonController.Instance.SetPreviousCannonPart(cannonPartType);
    }

    private void SaveClicked()
    {
        SaveController.Instance.SaveToJSON();
    }
}
