using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;
// [DefaultExecutionOrder (5)]
public class TestLabShootBall1 : MonoBehaviour
{
    private Rigidbody rb;
  
    [SerializeField]
    private float thrust = 100;

    private InputManager inputManager;
    private Vector3 startingPosition, startingCenterOfMass, startingTransformForward;
    private Quaternion startingRotation;
    private bool shootPressed;
    public AudioSource beamWave;
   // public AudioSource backgroundAudio;
   // private Coroutine letBallReset;
    Quaternion rbRotationOff = Quaternion.Euler(0, 0, 0); //stop fucking spinning
                                                          // private float ballResetTime = .5f;
    private Vector3 ballHome;
    private Quaternion ballRotation, discRotationUp, discRotationDown;

    private Transform transformDiscArcimboldo, transformEye;
    

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = rb.position;
        startingRotation = rb.rotation;
        startingTransformForward = transform.forward;

        ballHome = new Vector3(3.062f, -.6f, -7.769f);
        ballRotation = new Quaternion(-6f, 0, 0, 0);

        beamWave = GetComponent<AudioSource>();
        // backgroundAudio = GetComponent<AudioSource>();
       // discRotationDown = new Quaternion(270f, 0f, 0f, 0); //The rotation on start  -- the basket
       // discRotationUp = new Quaternion(90f, 0f, 0f, 0);    // the face!
        transformDiscArcimboldo = GameObject.Find("DiscArcimboldo").GetComponent<Transform>();
        transformEye = GameObject.Find("Eye").GetComponent<Transform>();
        
    }
    private void FixedUpdate()
    {
        if (shootPressed) // && !ScoreKeeper.gameOver)
        {
            beamWave.Play(0);
            rb.AddForceAtPosition(Vector3.forward * thrust, rb.position, ForceMode.VelocityChange);
            shootPressed = false;
        }
    }
    void ShootBall()
    {
      
        if ((rb.IsSleeping() || rb.position == startingPosition) && !ScoreKeeper.gameOver)  //BTW also "shoots" a stuck ball back into play
        {
            rb.constraints = RigidbodyConstraints.None;
            shootPressed = true;
            ScoreKeeper.SetMotor(100f,100f,true);
            ScoreKeeper.SetAnimation(ScoreKeeper.animDiscUnder1,  true);
            ScoreKeeper.SetAnimation(ScoreKeeper.vortex1, true);
            ScoreKeeper.SetAnimation(ScoreKeeper.animDiscUnderchess, true);
            ScoreKeeper.SetBackgroundAudio(true);
            //   backgroundAudio.Play();
            //   Debug.Log("shootball.... try play");
            transformDiscArcimboldo.Rotate(180f, 0, 0);
            transformEye.Rotate(180f, 0, 0);
        }
    }
    private IEnumerator ResetBallRotation(float resetTime)
    {
        while (true)
        {
            Debug.Log("reset Cor running...");
        yield return new WaitForSeconds(resetTime);
        }

    }
    private void OnEnable()
    {
        inputManager.OnShootBallButton += ShootBall;
    }
    private void OnDisable()
    {
        inputManager.OnShootBallButton -= ShootBall;
    }

}
