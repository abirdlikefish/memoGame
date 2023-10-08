using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{

    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("1");
        }
    }

}

