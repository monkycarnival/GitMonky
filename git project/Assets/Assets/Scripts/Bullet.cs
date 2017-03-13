using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 10;

    float Aim;

    public Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        Vector2 P1 = player.transform.position;
        Vector2 enemyPos = transform.position;
        Aim = GetAim(P1, enemyPos);
        SetVelocityForRigidbody2D(Aim, speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public float GetAim(Vector2 p2, Vector2 p1)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    public void SetVelocityForRigidbody2D(float direction, float speed)
    {
        Vector2 v;
        v.x = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        v.y = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
        GetComponent<Rigidbody2D>().velocity = v;
    }
}
