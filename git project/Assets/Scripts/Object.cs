using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour
{
    public int hp;
    public int point;
    //public int onShot = 0;

    // Spaceshipコンポーネント
    public Spaceship spaceship;

    void Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();
    }
/*
    void Update()
    {

        if (onShot == 1)
        {
            spaceship.Shot();
        }
    }
*/
    void OnTriggerEnter2D(Collider2D c)
    {

        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName == "Player_Bullet")
        {
            //FindObjectOfType<SCORE>().AddPoint(point);
            //FindObjectOfType<HISCORE>().AddPoint(point);
            // 弾の削除
            Destroy(c.gameObject);
            Player.s_count = 0;

            // 爆発
            //spaceship.Explosion();

            // エネミーの削除
            Destroy(gameObject);
        }
    }
}