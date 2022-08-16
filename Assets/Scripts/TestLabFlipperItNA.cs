using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLabFlipperItNA : MonoBehaviour
{
    //This script is attached to the individual flippers(capsules) themselves ONLY to apply force to ball 
      public float flipperForce = 75;
      private float rotationY;
  
    // Start is called before the first frame update
    void Start()
    {
        rotationY = transform.parent.rotation.eulerAngles.y;  //right flipper is 225 (275 extended)      left flipper is 135  (85 extended)
      //  Debug.Log(" rot Y = " + rotationY); //+  "... " + rotationY  + " " + theFlipper.rotation.eulerAngles.y);
      
    }
    void OnCollisionEnter(Collision ball)
    {
        if (gameObject.CompareTag("RightFlipper"))   //for the sake of clarity
        {
            var x = transform.parent.rotation.eulerAngles.y - rotationY;
          //  Debug.Log("xRight=  " + x  + "  rotEuler  " + transform.parent.rotation.eulerAngles.y) ;
            if (x >= 48 || x < 1) return;  //rotY is 225 so anything < 275 should be false  here  //flipper is at rest or fully extended
        }
        else 
        if (gameObject.CompareTag("LeftFlipper"))   //for the sake of clarity
        {
            var x = transform.parent.rotation.eulerAngles.y - rotationY;
          //  Debug.Log("xLeft=  " + x + " rotEuler  " + transform.parent.rotation.eulerAngles.y);
            if (x <= -48  || x > -1) return; //flipper is at rest or fully extended      //if not  smack that ball 
        }
        //otherwise the flipper is in motion... so we smack the ball -- but we want to smack it if we start motion too (OnCollisionStay?)
        Vector3 direction = ball.transform.position - transform.position;
        ball.rigidbody.AddForceAtPosition(direction.normalized * flipperForce, transform.position);  //smack the ball!
    }
    private void OnCollisionStay(Collision ball)
    {
       // Debug.Log("Ball is in collision with flipper ");  //Getting this once per frame ??? think so
        if (gameObject.CompareTag("RightFlipper"))   //for the sake of clarity
        {
            var x = transform.parent.rotation.eulerAngles.y - rotationY;
            //  Debug.Log("xRight=  " + x  + "  rotEuler  " + transform.parent.rotation.eulerAngles.y) ;
            if (x >= 48 || x < 1) return;  //rotY is 225 so anything < 275 should be false  here  //flipper is at rest or fully extended
        }
        else
      if (gameObject.CompareTag("LeftFlipper"))   //for the sake of clarity
        {
            var x = transform.parent.rotation.eulerAngles.y - rotationY;
            //  Debug.Log("xLeft=  " + x + " rotEuler  " + transform.parent.rotation.eulerAngles.y);
            if (x <= -48 || x > -1) return; //flipper is at rest or fully extended      //if not  smack that ball 
        }
        //otherwise the flipper is in motion... so we smack the ball -- but we want to smack it if we start motion too (OnCollisionStay?)
        Vector3 direction = ball.transform.position - transform.position;
        ball.rigidbody.AddForceAtPosition(direction.normalized * flipperForce, transform.position);  //smack the ball!
    }
}