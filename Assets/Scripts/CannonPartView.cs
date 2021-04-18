using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPartView : MonoBehaviour
{
    [SerializeField]
    private CannonPartController cannonPartController;

    private int itemId = 0;
    private int maxItemCount;

    private void Start()
    {
        maxItemCount = cannonPartController.CannonParts.Count;
    }

    public void OnNextButton()
    {
        if(itemId < maxItemCount - 1)
        {
            itemId++;
        }
        else
        {
            itemId = 0;
        }
        cannonPartController.SetCannonPart(itemId);
        CannonController.OnCannonPartChanged?.Invoke();
    }

    public void OnPreviousButton()
    {
        if(itemId > 0)
        {
            itemId--;
        }
        else
        {
            itemId = maxItemCount - 1;
        }
        cannonPartController.SetCannonPart(itemId);
    }
}
