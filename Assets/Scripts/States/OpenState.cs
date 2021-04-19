public class OpenState : BaseState
{
    private OpenView openView;
    public override void EnterState()
    {
        openView = stateController.AppViews.OpenView;
        openView.OnSaveChosen += LoadChosenSaveFile;
        foreach(var saveFile in SaveController.Instance.SaveDataCollection.saveDataList)
        {
            openView.CreateGridButton(saveFile.id);
        }
        openView.SubscribeButtonActions();
        openView.DisplayView(true);
    }

    public override void ExitState()
    {
        openView.DisplayView(false);
        openView.OnSaveChosen -= LoadChosenSaveFile;
        openView.UnsubscribeButtonActions();
    }

    private void LoadChosenSaveFile(int saveId)
    {
        stateController.TransitionToState(new LoadState(saveId));
    }
}
