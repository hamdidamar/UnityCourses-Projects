using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public void OpenChapter(string _chapterName)
    {
        Application.LoadLevel(_chapterName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

