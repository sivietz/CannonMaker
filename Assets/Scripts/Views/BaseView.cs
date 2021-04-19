using UnityEngine;

public class BaseView : MonoBehaviour
{
    public virtual void DisplayView(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
