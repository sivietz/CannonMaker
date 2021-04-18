using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : BaseState
{
    private int saveToLoadId;

    public LoadState(int saveId)
    {
        saveToLoadId = saveId;
    }

    public override void EnterState()
    {
        SaveController.Instance.LoadSingleSaveData(saveToLoadId);
        stateController.TransitionToState(new CreateState());
    }

    public override void ExitState()
    {
    }
}
