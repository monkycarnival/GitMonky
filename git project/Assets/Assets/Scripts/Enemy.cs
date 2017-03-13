using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int hp = 1;
    public int point = 60;

    // Spaceshipコンポーネント
    public Spaceship spaceship;

    IEnumerator Start()
    {

        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        // canShotがfalseの場合、ここでコルーチンを終了させる
        if (spaceship.canShot == 0)
        {
            yield break;
        }
        
        while (spaceship.canShot == 1)
        {
            spaceship.Shot();
            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }
        void OnTriggerEnter2D(Collider2D c)
    {
        hp = hp - 1;
        if (hp <= 0)
        {
            FindObjectOfType<SCORE>().AddPoint(point);
            FindObjectOfType<HISCORE>().AddPoint(point);
        }

        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName == "Player_Bullet" || layerName == "Player")
        {

            // 弾の削除
            Destroy(c.gameObject);
            Player.s_count = 0;

            // 爆発
            spaceship.Explosion();

            // エネミーの削除
            Destroy(gameObject);
        }
    }
}