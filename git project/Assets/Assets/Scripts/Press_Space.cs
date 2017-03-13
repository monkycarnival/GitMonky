using UnityEngine;
using System.Collections;

public class Press_Space : MonoBehaviour
{
    [SerializeField]
    SCENES nextScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPressDecide();
        }
    }

    void OnPressDecide()
    {

        Debug.Log(nextScene);
        SceneManage.SceneMove(nextScene);


    }
}
