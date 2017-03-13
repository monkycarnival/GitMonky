using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 10;

    void Start()
    {
        // ローカル座標のY軸方向に移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        Player.s_count = 0;
    }
}
