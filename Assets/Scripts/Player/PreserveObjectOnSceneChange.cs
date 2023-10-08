using UnityEngine;

public class PreserveObjectOnSceneChange : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}