using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    
    public void OpenMenu(InputAction.CallbackContext context)
    {
        menu.SetActive(false);
    }
}
