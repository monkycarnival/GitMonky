using UnityEngine;
using System.Collections;
using UnityEngine.UI;//Text操作

public class HISCORE : MonoBehaviour
{
    private int score;
    private int highScore;
    private string key = "HIGH SCORE";
    // Use this for initialization
    void Start()
    {
        highScore = PlayerPrefs.GetInt(key, 5000);
        GetComponent<Text>().text = "" + highScore.ToString();
    }
    public void AddPoint(int point)
    {
        score = score + point;
    }
    // Update is called once per frame
    void Update()
    {
        //スコアの更新
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt(key, highScore);
            GetComponent<Text>().text = "" + highScore.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}


