using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    SCENES nextScene;
    public static int j;
    // Spaceshipコンポーネント
    Spaceship spaceship;
    // 弾のPrefab
    public GameObject bullet;
    public static int s_count = 0;
    private Animator animator;
    public GameObject Players;
    public int trg = 0;
    IEnumerator Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();
        animator = GetComponent<Animator>();

        while (true)
        {


            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    void Update()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = 0;  //Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動の制限
        Move(direction);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (s_count < 1)
            {
                // 弾をプレイヤーと同じ位置/角度で作成

                // ショット音を鳴らす
                GetComponent<AudioSource>().Play();
                s_count = 1;
                animator.SetBool("change", false);  //プレイヤーの画像を変更
                Instantiate(bullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
            }
        }

        if (s_count == 0)
        {
            //ショットを撃った時の画像変更
            animator.SetBool("change", true);  //プレイヤーの画像を元に戻す
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            OnPressDecide();
        }

    }
    // 機体の移動
    void Move(Vector2 direction)
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // 移動量を加える
        pos += direction * spaceship.speed * Time.deltaTime;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "Enemy_Bullet")
        {
            // 弾の削除
            Destroy(c.gameObject);
        }

        // レイヤー名がBullet (Enemy)またはEnemyの場合は爆発

        if (layerName == "Enemy_Bullet" || layerName == "Enemy")
        {
            
            // 爆発する
            spaceship.Explosion();
                        
            // プレイヤーを削除
            Destroy(gameObject);
            trg++;
            Debug.Log(trg);
            //Instantiate(Players, new Vector2(0, 0), Quaternion.identity);

        }
    }

    private void Instantiate(object players)
    {
        throw new NotImplementedException();
    }

    void OnPressDecide()
    {
        Debug.Log(nextScene);
        SceneManage.SceneMove(nextScene);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
             Destroy(gameObject);
             GameObject.Find("Player");
            }
        }
    }