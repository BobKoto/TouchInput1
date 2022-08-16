using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLabBumpIt : MonoBehaviour
{
    private Animation bumperAnim;
    private AudioSource bumperAudio;
    private GameObject goThisHolder;
    public float bumpForce = 500;

    // Start is called before the first frame update
    void Start()
    {
        bumperAnim = gameObject.GetComponent<Animation>();
        goThisHolder = GameObject.Find("Bumpers");
        bumperAudio = goThisHolder.GetComponent<AudioSource>();

        // bumperAnim.playAutomatically = false;
    }
    void OnCollisionEnter(Collision ball)
    {
        bumperAnim.Play();
        bumperAudio.Play(0);

        Vector3 direction = ball.transform.position - transform.position;
       /* if (!ball.rigidbody.freezeRotation)
        {
            //This locks the RigidBody so that it does not move in the Y axis.  // Possible problem
            ball.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;  // REALLY BAD idea for a slanted pinball surface?
        }  */
        ball.rigidbody.AddForceAtPosition(direction.normalized * bumpForce, transform.position);

    }
}