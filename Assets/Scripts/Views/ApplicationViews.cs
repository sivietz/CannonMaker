using UnityEngine;

public class ApplicationViews : MonoBehaviour
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
