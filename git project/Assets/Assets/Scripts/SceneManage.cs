using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum SCENES
{
    TITLE = 0,
    GALAXIAN,
    TESTROOM
}

static public class SceneManage
{


    static public void SceneMove(SCENES NextScene)
    {

        SceneManager.LoadScene((int)NextScene);

    }
}
