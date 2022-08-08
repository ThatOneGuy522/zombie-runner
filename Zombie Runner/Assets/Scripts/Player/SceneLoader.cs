using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadScene()
    {
        Debug.Log("button pressed");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
