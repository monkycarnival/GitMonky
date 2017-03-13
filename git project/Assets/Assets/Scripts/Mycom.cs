using UnityEngine;
using System.Collections;

public class Mycom : MonoBehaviour
{
    public GameObject StarPrefab;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Proc());
    }
        IEnumerator Proc()
    {

        while (true)
        {
            float x = Random.Range(0, Screen.width);
            float y = Screen.height;
            Vector2 pos = new Vector2(x, y);
            pos = Camera.main.ScreenToWorldPoint(pos);
            CreateEnemy(pos);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    void CreateEnemy(Vector2 position)
    {
        Instantiate(StarPrefab, position, transform.rotation);
    }
}
