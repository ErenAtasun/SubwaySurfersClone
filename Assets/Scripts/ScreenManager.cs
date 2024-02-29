using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    public void GoTo1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void QuitApp()
    {
        Application.Quit();
        
    }
}
