using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private Vector3 startingPosition; //, startingCenterOfMass;
    private Quaternion startingRotation;
    private Rigidbody rb;
    private Quaternion ballRotation;
    Quaternion rbRotationOff = Quaternion.identity; //stop fucking spinning
    private Transform transformDiscArcimboldo;
    private int localBallInPlay =1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = rb.position;
        startingRotation = rb.rotation;

        //  ballHome = new Vector3(3.062f, -.6f, -7.769f);
        //  ballRotation = new Quaternion(-6f, 0, 0, 0);
        //startingCenterOfMass = rb.worldCenterOfMass;
        //   Debug.Log(" ballReturnScript..TF.." + rb.transform.forward);
        transformDiscArcimboldo = GameObject.Find("DiscArcimboldo").GetComponent<Transform>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FrontWall"))
        {
        //     Debug.Log("Hit front wall...");
           
            rb.position = startingPosition;
            rb.rotation = startingRotation;
            ScoreKeeper.UpdateBallInPlay();
            ScoreKeeper.SetMotor(0f, 0f, false);
            ScoreKeeper.SetAnimation(ScoreKeeper.animDiscUnder1, false);
            ScoreKeeper.SetAnimation(ScoreKeeper.vortex1, false);
            ScoreKeeper.SetAnimation(ScoreKeeper.animDiscUnderchess, false);

            transformDiscArcimboldo.Rotate(180f, 0, 0);
            localBallInPlay += 1;
        //    Debug.Log("localball in play " + localBallInPlay);
            if (localBallInPlay > 3)
            {
             //   Debug.Log("now what?"); //this means ball 4 - start of NEXT game
            }
        }
        if (collision.gameObject.CompareTag("FrontStop"))  //IK we could just do an OR here
        {
            //    Debug.Log("Hit front STOP...");
            if (!rb) 
            Debug.Log("rb is false");
            rb.constraints = RigidbodyConstraints.FreezeAll;  //What now?
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.position = startingPosition; //Bounces ball???
            rb.rotation = startingRotation;  //works but poorly 
                   
        }
       
    }
}
