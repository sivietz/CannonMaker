public class OpenState : BaseState
{
    public override void EnterState()
    {
        stateController.UIPanels.OpenView.OnSaveFileChosen += LoadChosenSaveFile;
        //SaveController.Instance.LoadFromJSON();
        foreach(var saveFile in SaveController.Instance.SaveDataCollection.saveDataList)
        {
            stateController.UIPanels.OpenView.CreateGridButton(saveFile.id);
        }
        stateController.UIPanels.OpenView.SubscribeButtonActions();
        stateController.UIPanels.OpenView.DisplayView(true);
    }

    public override void ExitState()
    {
        stateController.UIPanels.OpenView.DisplayView(false);
        stateController.UIPanels.OpenView.OnSaveFileChosen -= LoadChosenSaveFile;
        stateController.UIPanels.OpenView.UnsubscribeButtonActions();
    }

    private void LoadChosenSaveFile(int saveId)
    {
        stateController.TransitionToState(new LoadState(saveId));
    }
}
