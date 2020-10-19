using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void Start()
    {
        //PlayerPrefs.DeleteAll(); // for delete saving levels
    }
    public void Play()
    {
        int _savedLevel = PlayerPrefs.GetInt("SavingLevel");
        if (_savedLevel == 0)
        {
            SceneManager.LoadScene(_savedLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(_savedLevel);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
