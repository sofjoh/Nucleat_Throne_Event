using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void goToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void quitTheApplication()
    {
        Application.Quit();
        Debug.Log("User quit the application");
    }
}
