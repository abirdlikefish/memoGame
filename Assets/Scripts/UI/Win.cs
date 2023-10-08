using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI ;

public class Win : MonoBehaviour
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
