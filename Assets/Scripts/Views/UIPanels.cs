using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanels : MonoBehaviour
{
    [SerializeField]
    private MenuView menuView;
    [SerializeField]
    private OpenView openView;
    [SerializeField]
    private CreateView createView;

    public MenuView MenuView => menuView;
    public OpenView OpenView => openView;
    public CreateView CreateView => createView;
}
