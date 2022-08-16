using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperIt : MonoBehaviour
{
    //private Animation bumperAnim;
    // Start is called before the first frame update
    void Start()
    {
       // bumperAnim = gameObject.GetComponent<Animation>();
        // bumperAnim.playAutomatically = false;
    }
    void OnCollisionEnter(Collision ball)
    {
        //Debug.Log("Flipper Hit...");  //bumperAnim.Play();

        Vector3 direction = ball.transform.position - transform.position;
        //if (!ball.rigidbody.freezeRotation)
        //{
        //    //This locks the RigidBody so that it does not move in the Y axis.
        //    ball.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        //}
        ball.rigidbody.AddForceAtPosition(direction.normalized * 25000, transform.position);

    }
}
