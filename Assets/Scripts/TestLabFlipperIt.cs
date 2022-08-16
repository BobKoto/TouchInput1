using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLabFlipperIt : MonoBehaviour
{
    //private Animation bumperAnim;
    public float flipperForce = 750;
    public Animation flipperAnim;

    // Start is called before the first frame update
    void Start()
    {
        // bumperAnim = gameObject.GetComponent<Animation>();
        // bumperAnim.playAutomatically = false;
    }
    void OnCollisionEnter(Collision ball)
    {
        //Debug.Log("Flipper Hit...");  //bumperAnim.Play();
        if (!flipperAnim.isPlaying) return;                                          //otherwise smack that ball
        Vector3 direction = ball.transform.position - transform.position;
        ball.rigidbody.AddForceAtPosition(direction.normalized * flipperForce, transform.position);
    }
}
