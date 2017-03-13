using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    // 移動スピード
    public float speed;

    // 弾を撃つ間隔
    public float shotDelay;

    // 弾のPrefab
    public GameObject bullet;

    // プレイヤーのPrefab
    public Transform player;

    // 弾を撃つかどうか
    public int canShot = 0; //0で撃たない 1で撃つ

    //敵が弾を撃ってくる感覚
    public int time = 0;

    // 爆発のPrefab
    public GameObject explosion;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // 爆発の作成
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

}