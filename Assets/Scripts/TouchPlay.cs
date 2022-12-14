using System.Collections;
using UnityEngine;


public class TouchPlay : MonoBehaviour
{
    //[SerializeField]
    //private GameObject trail;
    //[SerializeField, Range(0f, 1f)]
    //float directionThreshold = .9f;
    //[SerializeField]
    //private float mimimumDistance = .2f;
    //[SerializeField]
    //private float maximumTime = 1f;
    private Animation leftFlipper, rightFlipper;
    public GameObject gOLeftFlipper, gORightFlipper, gORightHinge;
    private InputManager inputManager;
    private Vector2 startPosition;
    HingeJoint rightHinge;


    //private Vector2 endPosition;
    //private float startTime;
    //private float endTime;

    //private Coroutine coroutine;
    private void Awake()
    {
        inputManager = InputManager.Instance;
    }
    private void OnEnable()
    {
        inputManager.OnStartTouch += OperateFlippers;
     //   inputManager.OnEndTouch += SwipeEnd;
    }
    private void OnDisable()
    {
        inputManager.OnStartTouch -= OperateFlippers;
     //   inputManager.OnEndTouch -= SwipeEnd;
    }
    private void Start()
    {
        leftFlipper = gOLeftFlipper.GetComponent<Animation>();
        rightFlipper = gORightFlipper.GetComponent<Animation>();
        rightHinge =  gORightHinge.GetComponent<HingeJoint>();

        JointSpring hingeSpring = rightHinge.spring;
        hingeSpring.spring = 10;
        hingeSpring.damper = 3;
        hingeSpring.targetPosition = 70;
        rightHinge.spring = hingeSpring;
        rightHinge.useSpring = true;
    }
    private void OperateFlippers(Vector2 position, float time)
    {
        startPosition = position; //Use later to bias flippers
      //  Debug.Log("touch pos ..." + startPosition);
        leftFlipper.Play();
        rightFlipper.Play();
        //startTime = time;
        //trail.SetActive(true); //make trail 4get last touch - see SwipeEnd(...)
        //trail.transform.position = position;
        //coroutine = StartCoroutine("Trail");
      //  OperateHinge();
    }
    private void OperateHinge ()   // this is config stuff   DOH!
    {
       // Debug.Log("Operate Hinge...");
        JointSpring hingeSpring = rightHinge.spring;
        hingeSpring.spring = 10;
        hingeSpring.damper = 3;
        hingeSpring.targetPosition = 70;
        rightHinge.spring = hingeSpring;
        rightHinge.useSpring = true;
    }
    // NEW: to use hinge joint in place of animations for flippers
    //void Start()
    //{
    //    HingeJoint hinge = GetComponent<HingeJoint>();

    //    // Make the spring reach shoot for a 70 degree angle.
    //    // This could be used to fire off a catapult.

    //    JointSpring hingeSpring = hinge.spring;
    //    hingeSpring.spring = 10;
    //    hingeSpring.damper = 3;
    //    hingeSpring.targetPosition = 70;
    //    hinge.spring = hingeSpring;
    //    hinge.useSpring = true;
    //}
    //private IEnumerator Trail()
    //{
    //    while (true)
    //    {
    //        trail.transform.position = inputManager.PrimaryPosition();
    //        yield return null;
    //    }
    //}
    //private void SwipeEnd(Vector2 position, float time)
    //{
    //    trail.SetActive(false);  //see SwipeStart(...) for why we  have to toggle Active
    //    StopCoroutine(coroutine);

    //    endPosition = position;
    //    endTime = time;
    //    //  DetectSwipe();  //nice for debugging/picking up and acting on Swipes
    //}
    //private void DetectSwipe()
    //{
    //    if (Vector3.Distance(startPosition, endPosition) >= mimimumDistance && (endTime - startTime) <= maximumTime)
    //    {
    //        Debug.Log("Swipe Detected");
    //        Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
    //        Debug.Log("Start pos  " + startPosition + "  End pos  " + endPosition);
    //        Vector3 direction = endPosition - startPosition;
    //        Vector2 direction2D = new Vector2(direction.x, direction.y).normalized; //normalized to get direction only
    //        SwipeDirection(direction2D);
    //    }
    //}
    //private void SwipeDirection(Vector2 direction)
    //{
    //    if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
    //    {
    //        Debug.Log("Swipe UP");
    //    }
    //    else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
    //    {
    //        Debug.Log("Swipe DOWN");
    //    }
    //    else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
    //    {
    //        Debug.Log("Swipe LEFT");
    //    }
    //    else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
    //    {
    //        Debug.Log("Swipe RIGHT");
    //    }
    //}
}
