/*using UnityEngine;
using System.Collections;

public class CGame: MonoBehaviour
{
    // GUISkin
    public GUISkin skinBlock;
    // 点数
    private static int iScore;
    // 現在の残機。マイナスになるとゲームオーバー。
   private static int iLeft;
    // 面が開始する時点での残機(3回ミスが出来る)
    private static int INIT_LEFT = 2;

    // Use this for initialization
    void Start()
    {
        CGame.initGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void initGame()
    {
        iScore = 0;
        iLeft = INIT_LEFT;
    }

    void OnGUI()
    {
        GUIStyle stLabel = skinBlock.FindStyle("HUD Label");
        GUIStyle stLabelS = skinBlock.FindStyle("HUD LabelS");
        GUIStyle stNum = skinBlock.FindStyle("HUD Num");
        GUIStyle stNumS = skinBlock.FindStyle("HUD NumS");
        GUIStyle stzanki = skinBlock.FindStyle("zanki");
        float grid = Screen.height / 60f;
        float cx = Screen.width / 2f;
        // 残機
        GUI.Label(new Rect(cx + grid * 12+ 1, grid*3/2+ 1, grid * 4, 30), "" + iLeft, stzanki);
        GUI.Label(new Rect(cx + grid * 15 + 1, grid * 3 / 2+ 1, grid * 4, 30), "" + iLeft, stzanki);

    }

    public static void addScore(int add)
    {
        iScore += add;
    }

    public static bool decLeft()
    {
        if (iLeft <= 0)
        {
            return true;
        }
        iLeft--;
        return false;
    }
}*/