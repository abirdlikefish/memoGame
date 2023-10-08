using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI ;

public class Dead : MonoBehaviour
{

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Game End");
            Application.Quit();
        }
    }

}
