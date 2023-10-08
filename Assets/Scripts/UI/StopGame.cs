using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    bool isStop = false;
    public Image image;

    private void Awake() {
        image = GetComponent<Image>();
        image.enabled = false ;
    }

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if(isStop)
            {
                SceneManager.LoadScene("0");
            }
            else
            {
                Time.timeScale = 0f;
                isStop = true;
                image.enabled = true;
            }
        }
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if(isStop)
            {
                Time.timeScale = 1f;
                isStop = false;
                image.enabled = false;
            }
            else
            {
                return;
            }
        }
    }

}

