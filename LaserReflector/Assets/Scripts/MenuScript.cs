using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void QuitScene()
    {
        Application.Quit();
    }

    public void SaveName(string _name)
    {
        PlayerPrefs.SetString("Player Name", _name);
    }
}
