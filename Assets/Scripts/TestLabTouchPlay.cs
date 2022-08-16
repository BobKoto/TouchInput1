using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UIElements;

public class TestLabTouchPlay : MonoBehaviour
{
    //[SerializeField]   //These SerializeFields were for Swipe Detection...
    //private GameObject trail;
    //[SerializeField, Range(0f, 1f)]
    //float directionThreshold = .9f;
    //[SerializeField]
    //private float mimimumDistance = .2f;
    //[SerializeField]
    //private float maximumTime = 1f;
    private Animation leftFlipper, rightFlipper;
    public GameObject gOLeftFlipper, gORightFlipper, gORightFNoAnim, gOLeftFNoAnim;
    private Vector3 rightHome, rightExtended, leftHome, leftExtended, rightHomePosition, leftHomePosition;
    Coroutine rotationCoroutineRight, rotationCoroutineLeft;
    public float flipperSpeed = 600f;
    private float centerOfScreen, bottomOfScreen, topOfScreen;
    private Quaternion targetRotationLeft, targetRotationRight, targetHomeLeft, targetHomeRight;
    private Vector3 transformTargetRotationLeft, transformTargetRotationRight, transformTargetHomeLeft, transformTargetHomeRight;

    private InputManager inputManager;
    private Vector2 startPosition;
    bool leftFlipperOperating, rightFlipperOperating; //moving or extended with slowtapinteraction
    private Button newGameButton;
    private void Awake()
    {
        inputManager = InputManager.Instance;
    }
    private void OnEnable()
    {
        //inputManager.OnStartTouch += OperateFlippers;
        inputManager.OnLeftButtonPress += OperateLeftFlipper;
        inputManager.OnRightButtonPress += OperateRightFlipper;
        inputManager.OnTestLabButton += OperateTestLabButton;
        inputManager.OnTestLabButton2 += OperateTestLabButton2;
        inputManager.OnFirstTouch += DoFirstTouch;
        inputManager.OnSecondTouch += DoSecondTouch;

        //   inputManager.OnEndTouch += SwipeEnd;
    }
    private void OnDisable()
    {
        //inputManager.OnStartTouch -= OperateFlippers;
        inputManager.OnLeftButtonPress -= OperateLeftFlipper;
        inputManager.OnRightButtonPress -= OperateRightFlipper;
        inputManager.OnTestLabButton -= OperateTestLabButton;
        inputManager.OnTestLabButton2 -= OperateTestLabButton2;
        inputManager.OnFirstTouch -= DoFirstTouch;
        inputManager.OnSecondTouch -= DoSecondTouch;
        //   inputManager.OnEndTouch -= SwipeEnd;
    }
    private void Start()
    {
        leftFlipper = gOLeftFlipper.GetComponent<Animation>();
        rightFlipper = gORightFlipper.GetComponent<Animation>();

        rightHomePosition = new Vector3(0, 225, 0);
        leftHomePosition = new Vector3(0, 135, 0);
               
        rightExtended = new Vector3(0, 275, 0);  // was 60 
        leftExtended = new  Vector3(0, 85, 0);

        // targetRotationLeft = Quaternion.Euler(leftExtended);
        targetRotationLeft = Quaternion.Euler(leftExtended);
        targetRotationRight = Quaternion.Euler(rightExtended);
      //  transformTargetRotationRight = Transform.localEulerAngles   =  transformTargetRotationRight;
        targetHomeLeft = Quaternion.Euler(leftHomePosition);
        targetHomeRight = Quaternion.Euler(rightHomePosition);

       //Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 30;
        centerOfScreen = Screen.width / 2;
        topOfScreen = Screen.height;
      //  Debug.Log("TestLabTouchPlay started ");

    }
    private void FixedUpdate()
    {
        /*
        if (!rightFlipperOperating  && gORightFNoAnim.transform.localRotation != targetHomeRight) //Added check for rotations on 4/14/21 to solve "stuck extended" issue 
        {
            Debug.Log(" drag RightFlipper down");
            gORightFNoAnim.transform.localRotation = Quaternion.RotateTowards(gORightFNoAnim.transform.localRotation, targetHomeRight, 60);
        }  
        if (!leftFlipperOperating  && gOLeftFNoAnim.transform.localRotation != targetHomeLeft)
        {
            Debug.Log(" drag LeftFlipper down");
            gOLeftFNoAnim.transform.localRotation = Quaternion.RotateTowards(gOLeftFNoAnim.transform.localRotation, targetHomeLeft, 60);
        } */
    }
    private void OperateLeftFlipper()  //With animation
    {
        leftFlipper.Play();
      //  rightFlipper.Play();
    }
    private void OperateRightFlipper()
    {
     //   leftFlipper.Play();
        rightFlipper.Play();
    }
    private void DoFirstTouch(InputAction.CallbackContext context)
    {
       // Debug.Log("FirstTouch.." + "ctx " + context);
        var position = inputManager.FirstTouchPosition();
        if (position.x > 0 && position.y <  topOfScreen * .8 && position.y > topOfScreen * .2)    //touched & below top of screen & above bottom
        {
            if (position.x > centerOfScreen )  //Right side 
            {
               // Debug.Log("right side..." + position);
                if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Performed)  //added OR 4/25/21
                {
                   // Debug.Log("Right flipper started...");
                    rightFlipperOperating = true;
                    if (rotationCoroutineRight == null)
                        rotationCoroutineRight = StartCoroutine(RotationCoroutineRight(gORightFNoAnim.transform, targetRotationRight, false, false));
                }
                if (context.phase == InputActionPhase.Canceled)
                {
                    
                    //Debug.Log("Right flipper canceled...");
                    if (rotationCoroutineRight != null)
                    {
                        StopCoroutine(rotationCoroutineRight);
                        rotationCoroutineRight = null;
                    }
                    gORightFNoAnim.transform.localRotation = Quaternion.RotateTowards(gORightFNoAnim.transform.localRotation, targetHomeRight, 60);
                    rightFlipperOperating = false;
                }
            }
            else //Left side touched 
            { 
               // Debug.Log("left side..." + position);
                if (context.phase == InputActionPhase.Started  || context.phase == InputActionPhase.Performed)  //added OR 4/25/21
                {
                   // Debug.Log("Left flipper started...");
                    leftFlipperOperating = true;
                    if (rotationCoroutineLeft == null)
                        rotationCoroutineLeft = StartCoroutine(RotationCoroutineLeft(gOLeftFNoAnim.transform, targetRotationLeft, false, false));
                }
                if (context.phase == InputActionPhase.Canceled)
                {
                    
                   // Debug.Log("Left flipper canceled...");
                    if (rotationCoroutineLeft != null)
                    {
                        StopCoroutine(rotationCoroutineLeft);
                        rotationCoroutineLeft = null;
                    }
                    gOLeftFNoAnim.transform.localRotation = Quaternion.RotateTowards(gOLeftFNoAnim.transform.localRotation, targetHomeLeft, 60);
                    leftFlipperOperating = false;
                }
            }
        }
    }
    private void DoSecondTouch(InputAction.CallbackContext context)
    {
        var position = inputManager.SecondTouchPosition();
        // Debug.Log("SecondTouch.." + "ctx " + context);
        //if (position.x > centerOfScreen && rightFlipperOperating) return;
        //if (position.x < centerOfScreen && leftFlipperOperating) return;
        if (position.x > 0 && position.y < topOfScreen * .8 && position.y > topOfScreen * .2)    //touched & below top of screen & above bottom
        {
            if (position.x > centerOfScreen)  //Right side touched 
            {
                //  Debug.Log("right side..." + position);
                if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Performed)  //added OR 4/25/21
                {
                    //   Debug.Log("Right flipper started...");
                    rightFlipperOperating = true;
                    if (rotationCoroutineRight == null)
                        rotationCoroutineRight = StartCoroutine(RotationCoroutineRight(gORightFNoAnim.transform, targetRotationRight, false, false));
                }
                if (context.phase == InputActionPhase.Canceled)
                {

                    //   Debug.Log("Right flipper canceled...");
                    if (rotationCoroutineRight != null)
                    {
                        StopCoroutine(rotationCoroutineRight);
                        rotationCoroutineRight = null;
                    }
                    gORightFNoAnim.transform.localRotation = Quaternion.RotateTowards(gORightFNoAnim.transform.localRotation, targetHomeRight, 60);
                    rightFlipperOperating = false;
                }
            }
            else //Left side touched 
            {
                //  Debug.Log("left side..." + position);
                if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Performed)  //added OR 4/25/21
                {
                    //   Debug.Log("Left flipper started...");
                    leftFlipperOperating = true;
                    if (rotationCoroutineLeft == null)
                        rotationCoroutineLeft = StartCoroutine(RotationCoroutineLeft(gOLeftFNoAnim.transform, targetRotationLeft, false, false));
                }
                if (context.phase == InputActionPhase.Canceled)
                {

                    //   Debug.Log("Left flipper canceled...");
                    if (rotationCoroutineLeft != null)
                    {
                        StopCoroutine(rotationCoroutineLeft);
                        rotationCoroutineLeft = null;
                    }
                    gOLeftFNoAnim.transform.localRotation = Quaternion.RotateTowards(gOLeftFNoAnim.transform.localRotation, targetHomeLeft, 60);
                    leftFlipperOperating = false;
                }
            }
        }
    }
    private void OperateTestLabButton(InputAction.CallbackContext context)     //the M key and Button East for now -- the RIGHT flipper
    {
        switch (context.phase)
        {
            case InputActionPhase.Canceled:
                if (rotationCoroutineRight != null)
                {
                    StopCoroutine(rotationCoroutineRight);
                    rotationCoroutineRight = null;
                }
                 gORightFNoAnim.transform.localRotation = Quaternion.RotateTowards(gORightFNoAnim.transform.localRotation, targetHomeRight, 60);
                rightFlipperOperating = false;
                break;
            case InputActionPhase.Started:
                if (context.interaction is SlowTapInteraction)  //Gamer is holding button
                {
                        if (rotationCoroutineRight == null)
                            rotationCoroutineRight = StartCoroutine(RotationCoroutineRight(gORightFNoAnim.transform, targetRotationRight, false, false));
                    rightFlipperOperating = true;
                }
                break;
            case InputActionPhase.Performed:
               if (context.interaction is TapInteraction)  //Do the coroutine with justAFlip = true // Gamer only "tapped" button
               { //HERE is where we handle a single flipper button press.
                 //This Coroutine call will rotate flipper UP over time (in the While loop) THEN put flipper back to home/resting position //BUT what if NOT null?
                    if (rotationCoroutineRight == null)
                    {
                        rotationCoroutineRight = StartCoroutine(RotationCoroutineRight(gORightFNoAnim.transform, targetRotationRight, true, false));
                        rightFlipperOperating = true;
                    }
               }
               else
                if (context.interaction is SlowTapInteraction)  //Gamer released after holding (SlowTap). Just put flipper back to its home position (225) 
                {
                    gORightFNoAnim.transform.localRotation = Quaternion.RotateTowards(gORightFNoAnim.transform.localRotation, targetHomeRight, 60); //stalls?
                    rightFlipperOperating = false;
                    //if (rotationCoroutineRight == null)
                    //{
                    //    rotationCoroutineRight = StartCoroutine(RotationCoroutineRight(gORightFNoAnim.transform, targetHomeRight, true, true)); //TRY THIS -- yes, stalls too?
                    //}
                }
                break;
             default:  //Not sure what happened yet, or how we get here, but put flipper to rest
                gORightFNoAnim.transform.localRotation = Quaternion.RotateTowards(gORightFNoAnim.transform.localRotation, targetHomeRight, 60);
                rightFlipperOperating = false;
                break;
        }
    }
    private IEnumerator RotationCoroutineRight(Transform flipper, Quaternion targetRotationParameter, bool justAFlip, bool slowTapEnded)  //RIGHT
    {
       // Debug.Log("Enter coroutine... justAFlip is " + justAFlip  + "  slowTapEnded is " + slowTapEnded);
        if (!slowTapEnded)
        {
          while (Quaternion.Dot(flipper.localRotation, targetRotationParameter) < 1f)  //Swing the flipper upward across frames
                                                                                      //if flipper is fully extended this does nothing... 
          {   //rotate flipper upwards here 
          // Debug.Log("In While of coroutine... justAFlip is " + justAFlip + "  slowTapEnded is " + slowTapEnded);
            flipper.localRotation = Quaternion.RotateTowards(flipper.localRotation, targetRotationParameter, flipperSpeed * Time.fixedDeltaTime);
            yield return null;
          }
        }
         if (justAFlip)    // put the flipper back to home position AFTER above while loop is done OR if slowTapEnded is true
            flipper.localRotation = Quaternion.RotateTowards(flipper.localRotation, targetHomeRight, 50);
        // Debug.Log("Exit coroutine... justAFlip is " + justAFlip + "  slowTapEnded is " + slowTapEnded);
         rotationCoroutineRight = null; //purpose ????  Mark as Not Running
    }
    private void OperateTestLabButton2(InputAction.CallbackContext context)     //the C key and Button West for now  -- the LEFT flipper
    {
        switch (context.phase)
        {
            case InputActionPhase.Canceled:
                //  Debug.Log("INPUT CANCELED...");
                if (rotationCoroutineLeft != null)
                {
                    //  Debug.Log("Stopping COR");
                    StopCoroutine(rotationCoroutineLeft);
                    rotationCoroutineLeft = null;
                }
                gOLeftFNoAnim.transform.localRotation = Quaternion.RotateTowards(gOLeftFNoAnim.transform.localRotation, targetHomeLeft, 60);
                leftFlipperOperating = false;
                break;
            case InputActionPhase.Started:
                if (context.interaction is SlowTapInteraction)
                {
                                                                       //  if (rotationCoroutineLeft == null) // purpose????
                    {
                        if (rotationCoroutineLeft == null)
                            rotationCoroutineLeft = StartCoroutine(RotationCoroutineLeft(gOLeftFNoAnim.transform, targetRotationLeft, false, false));
                        leftFlipperOperating = true;
                    }
                }
                break;
            case InputActionPhase.Performed:
                if (context.interaction is TapInteraction)
                    {
                       if (rotationCoroutineLeft == null)
                        rotationCoroutineLeft = StartCoroutine(RotationCoroutineLeft(gOLeftFNoAnim.transform, targetRotationLeft, true, false )); //true for justAFlip
                       leftFlipperOperating = true;
                    }
                else
                if (context.interaction is SlowTapInteraction)  //Gamer released after holding (SlowTap). Just put flipper back to its home position 
                {
                    
                    //if (rotationCoroutineLeft == null)
                    //    rotationCoroutineLeft = StartCoroutine(RotationCoroutineLeft(gOLeftFNoAnim.transform, targetRotationLeft, true, true));
                   gOLeftFNoAnim.transform.localRotation = Quaternion.RotateTowards(gOLeftFNoAnim.transform.localRotation, targetHomeLeft,60);
                   leftFlipperOperating = false;
                }
                    //             Debug.Log("Just Press...left");   //HERE is where we need to handle just a press (singular flip)
                   
                break;
            default:   //Not sure what happened yet, or how we get here, but put flipper to rest
                gOLeftFNoAnim.transform.localRotation = Quaternion.RotateTowards(gOLeftFNoAnim.transform.localRotation, targetHomeLeft, 60);
                leftFlipperOperating = false;
                break;
        }
    }
    private IEnumerator RotationCoroutineLeft(Transform flipper, Quaternion targetRotationParameter, bool justAFlip, bool slowTapEnded)  //LEFT
    {
        if (!slowTapEnded)
        {
            while (Quaternion.Dot(flipper.localRotation, targetRotationParameter) < 1f)  //Swing the flipper upward across frames
            {  //rotate flipper upwards here 
                flipper.localRotation = Quaternion.RotateTowards(flipper.localRotation, targetRotationParameter, flipperSpeed * Time.fixedDeltaTime);
                yield return null;
            }
        }
        if (justAFlip)    // put the flipper back to home position        
            flipper.localRotation = Quaternion.RotateTowards(flipper.localRotation, targetHomeLeft, 50);
        rotationCoroutineLeft = null;
                                                                                                        //  rotationCoroutineLeft = null; //purpose????
    }
    public void OnButtonQuitPressed()   //This is NOT using InputManager - canvas button OnClick
    {
        Application.Quit(); //"Resets" but leaves ON Android Phone
    }
    //public void OnButtonNewGamePressed()   //This is NOT using InputManager - canvas button OnClick
    //{
    //    Debug.Log("NewGame pressed.... " + ScoreKeeper.gameOver);
    //    if (ScoreKeeper.gameOver) 
    //        ScoreKeeper.StartNewGame();
    //}
    //private IEnumerator RotationCoroutineRight(Transform flipper, Quaternion targetRotationParameter, bool justAFlip)  //
    //{
    //    while (Quaternion.Dot(flipper.transform.rotation, targetRotationParameter) < 1f)  //targetrotparm is "targetRotationRight = Quaternion.Euler(rightExtended)"
    //                                                                                      // rightExtended is "rightExtended = new Vector3(0, 275, 0)"
    //    {   //rotate here 
    //        flipper.transform.rotation = Quaternion.RotateTowards(flipper.transform.rotation, targetRotationParameter, rotationSpeed * Time.fixedDeltaTime);
    //        // Do we need  to " Adjust our position to preserve the relationship to the pivot." here?
    //        yield return null;
    //    }
    //    rotationCoroutineRight = null;
    //    if (justAFlip) //gORightFNoAnim.transform.Rotate(rightHome);  //change to Quaternion
    //        gORightFNoAnim.transform.rotation = Quaternion.RotateTowards(gORightFNoAnim.transform.rotation, targetHomeRight, 50);
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
