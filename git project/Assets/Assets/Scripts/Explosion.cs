using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public float trigar=0;

    // Use this for initialization
    void Update () {
        Animator anim = GetComponent<Animator>();

        AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);

        if(animInfo.normalizedTime > 1.0f)
        {
            Destroy(gameObject);
            trigar++;

        }
    }
}
