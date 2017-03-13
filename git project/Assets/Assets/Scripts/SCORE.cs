using UnityEngine;
using System.Collections;
using UnityEngine.UI;//Text操作

public class SCORE : MonoBehaviour
{
    private int score;
    // Use this for initialization
    void Start()
    {
        score = 0;//初期設定
    }

    // Update is called once per frame
    void Update()
    {
        //スコアの更新
        GetComponent<Text>().text = score.ToString();
    }
    public void AddPoint(int point)
    {
        score = score + point;
    }
}


