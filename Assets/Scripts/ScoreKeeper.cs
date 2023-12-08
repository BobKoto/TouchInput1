using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;

public class ScoreKeeper : MonoBehaviour
{
    public static int scoreTotal, ballInPlay;
    public static int ballsPerGame = 3;
    private InputManager inputManager;
    [HideInInspector]
    public static bool gameOver = true;
    public static TextMeshProUGUI scoreText, ballInPlayText, gameOverText;
    private static Transform randomSpinnerCenter;
    private static Transform transformVortex1, transformDiscH2chess, transformSurfaceEye, transformEyeSphere, transform1, transform2;
    private static Vector3 v3Vortex1, v3SurfaceEye;
    private static bool randomSpinnerCenterUseMotor;
    private static GameObject gOrandomSpinnerCenter;
    private static Vector3 centerSpinnerHome;
    private static Quaternion  centerSpinnerRotation;
   // private Coroutine letSpinnerReset;
    private static  IEnumerator coroutine;
    private static ScoreKeeper scoreKeeper;
    public static Animation animDiscUnder1, vortex1, animDiscUnderchess;
    public static Material gameSurfaceMaterial, zollner2Material, cafeWallMaterial, opticalIllusion2Material;
    public static MeshRenderer meshRenderer;
    // public AudioSource backgroundAudio;
    public AudioSource audioInfoButtonOk;
    public AudioSource audioInfoButton;
    public AudioSource audioStartNewGame;
    public static AudioSource audioBackground;
    public AudioClip clipInfoButtonOk;
    public AudioClip clipInfoButton;
    public AudioClip clipStartNewGame;
    public AudioClip clipBackGround;


    private static  GameObject gameInfoPanel;
    GameObject rightFlipper, leftFlipper, shootButton; // items to respectively enable/disable when GameInfoPanel is disabled/enabled
    static GameObject pauseButton, newGameButton;
    // Start is called before the first frame update
    private void Awake()
    {
        inputManager = InputManager.Instance;
        
    }
    void Start()
    {
        ScoreKeeper scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        ballInPlayText = GameObject.Find("BallInPlay").GetComponent<TextMeshProUGUI>();
        gameOverText = GameObject.Find("GameOverLabel").GetComponent<TextMeshProUGUI>();
        randomSpinnerCenter = GameObject.Find("RandomSpinner1").GetComponent<Transform>();
        centerSpinnerHome = randomSpinnerCenter.position;
        centerSpinnerRotation = randomSpinnerCenter.rotation;
        gOrandomSpinnerCenter = GameObject.Find("RandomSpinner1");
        animDiscUnder1 = GameObject.Find("DiscUnderSpinner1").GetComponent<Animation>();
        vortex1 = GameObject.Find("Vortex1").GetComponent<Animation>();
        animDiscUnderchess = GameObject.Find("DiscH2chess").GetComponent<Animation>();

        meshRenderer = GameObject.Find("GameSurface").GetComponent<MeshRenderer>();
        gameSurfaceMaterial = meshRenderer.material;
        zollner2Material = Resources.Load<Material>("ZollnerMat");
        opticalIllusion2Material = Resources.Load<Material>("OpticalIllusion2");
       // Debug.Log("z2Mat..." + zollner2Material);
        
      //  Debug.Log("gSurface..." + gameSurfaceMaterial);

        // SetBackgroundAudio(true);

        coroutine = ResetSpinner(1.0f);

        audioInfoButton = GetComponent<AudioSource>();
        audioInfoButtonOk = GetComponent<AudioSource>();
        audioStartNewGame = GetComponent<AudioSource>();
        audioBackground = GetComponent<AudioSource>();
       
        gameInfoPanel = GameObject.Find("/Canvas/GameInfoPanel");
        if (gameInfoPanel) gameInfoPanel.SetActive(false);

        leftFlipper = GameObject.Find("/Canvas/LeftFlipper");
        rightFlipper = GameObject.Find("/Canvas/RightFlipper");
        shootButton = GameObject.Find("/Canvas/Shoot");
        pauseButton = GameObject.Find("/Canvas/PauseButton");
        newGameButton = GameObject.Find("/Canvas/NewGame");
        if (pauseButton) pauseButton.SetActive(false);
        transformDiscH2chess = GameObject.Find("DiscH2chess").GetComponent<Transform>();
        transformVortex1 = GameObject.Find("Vortex1").GetComponent<Transform>();
        transformSurfaceEye = GameObject.Find("SurfaceEye").GetComponent<Transform>();
     //   transformEyeSphere = GameObject.Find("EyeSphere").GetComponent<Transform>();
        //Debug.Log(" Vortex1 transform = " + transformVortex1.position);
        //Debug.Log(" DiscH2chess transform = " + transformDiscH2chess.position);
        //Debug.Log(" SurfaceEye transform = " + transformSurfaceEye.position);
        //     Debug.Log(" EyeSphere transform = " + transformEyeSphere.position);
        v3Vortex1 = new Vector3(transformVortex1.position.x, transformVortex1.position.y, transformVortex1.position.z);
        v3SurfaceEye = new Vector3(transformSurfaceEye.position.x, transformSurfaceEye.position.y, transformSurfaceEye.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void SetMotor(float setForce, float setTargetVelocity, bool motorOnOff)  //removed to solve spinner stalling -- made Child of Disc instead - cross fingers
    {
        var centerHinge = GameObject.Find("RandomSpinner1").GetComponent<HingeJoint>();
        var centerMotor = centerHinge.motor;
        centerMotor.force = setForce;
        centerMotor.targetVelocity = setTargetVelocity;
        centerMotor.freeSpin = false;
        centerHinge.motor = centerMotor;
        centerHinge.useMotor = motorOnOff;
       // centerHinge.useSpring = !motorOnOff;
    }

    public static void UpdateScore(int points)
    {
        scoreTotal += points;
        scoreText.text = scoreTotal.ToString("#,###");
    }
    public static void UpdateBallInPlay()  //and other stuff   
    {
        ballInPlay += 1;
        if (ballInPlay > ballsPerGame)  //END the Game
        {
            if (pauseButton) pauseButton.SetActive(false);
            if (newGameButton) newGameButton.SetActive(true);
            gameOverText.enabled = true;
            gameOver = true;
            audioBackground.Stop();  // audioB //HERE IS where we should try a getter/setter!????????

            SetMotor(0f, 0f, false);
        }
        else
        {
            ballInPlayText.text = ballInPlay.ToString();
            switch (ballInPlay)
            {
                case 1: meshRenderer.material = gameSurfaceMaterial; break;
                case 2:
                        transform1 = GameObject.Find("Vortex1").GetComponent<Transform>();
                        transform1.position = v3SurfaceEye;//swap positions 
                        transform2 = GameObject.Find("SurfaceEye").GetComponent<Transform>(); 
                        transform2.position = v3Vortex1; //swap positions 
                        meshRenderer.material = zollner2Material;
                        break;
                case 3:
                       transform1 = GameObject.Find("Vortex1").GetComponent<Transform>();
                       transform1.position = v3Vortex1; //swap to original
                       transform2 = GameObject.Find("SurfaceEye").GetComponent<Transform>();
                       transform2.position = v3SurfaceEye; //swap to original
                       meshRenderer.material = opticalIllusion2Material; break;
                default: meshRenderer.material = gameSurfaceMaterial; break;
            }
        }
    }
    public  void StartNewGame()   //WAS STATIC 
    {
        if (gameOver)   //only do this with no game active
        {
            if (gameInfoPanel)  gameInfoPanel.SetActive(false);
            meshRenderer.material = gameSurfaceMaterial;

            if (gOrandomSpinnerCenter) gOrandomSpinnerCenter.SetActive(true);

            gameOverText.enabled = false;
            if (newGameButton) newGameButton.SetActive(false);
            if (pauseButton) pauseButton.SetActive(true);
            gameOver = false;
            scoreTotal = 0;
            scoreText.text = scoreTotal.ToString();
            ballInPlay = 1;
            ballInPlayText.text = ballInPlay.ToString();
            audioStartNewGame.clip = clipStartNewGame;
            audioStartNewGame.Play();
            coroutine = WaitOnAudio(3);  //These 2 lines wait 3 seconds then start the background audio
            StartCoroutine(coroutine);
            //Screen.fullScreen = true;   //12/2/23 test to see what effect this has on handheld & desk/laptop in WebGL - not good...
        }
    }
    public void OnButtonOK()   //This is NOT using InputManager - canvas button OnClick
    {
        // Debug.Log("play ok..." + audioInfoButtonOk);
        audioInfoButtonOk.clip = clipInfoButtonOk;
        audioInfoButtonOk.loop = false;
        audioInfoButtonOk.Play();
        gameInfoPanel.SetActive(false);
        if (leftFlipper) leftFlipper.SetActive(true);
        if (rightFlipper) rightFlipper.SetActive(true);
        if (shootButton) shootButton.SetActive(true);
        if (!gameOver)
        {
            coroutine = WaitOnAudio(2);  //These 2 lines wait 2 seconds then start/restart the background audio
            StartCoroutine(coroutine);
        }  
    }
    public void OnButtonGameInfo()   //This is NOT using InputManager - canvas button OnClick
    {
        audioInfoButton.clip = clipInfoButton;
        audioInfoButton.loop = false;
        audioInfoButton.Play();
        gameInfoPanel.SetActive(true);
        if (leftFlipper) leftFlipper.SetActive(false);
        if (rightFlipper) rightFlipper.SetActive(false);
        if (shootButton) shootButton.SetActive(false);
    }
    public static void SetAnimation(Animation anim, bool play)  //Allow other scripts to start/stop animations
    {
        if (play)
        {
            anim.Play();
        }
        else
        {
            anim.Stop();
        }
    }
    public static void SetBackgroundAudio(bool play)
    {
       
        if (play)
        {
        // ScoreKeeper.backgroundAudio.Play(); //huh????
         //   Debug.Log("SetBackgroundAudio called...play = true"); YES we did get here but...
        }
        else
        {
        //    if (backgroundAudio != null)      backgroundAudio.Stop();
        }
    }
    public static IEnumerator ResetSpinner(float resetTime)
    {
        int i = 0;
        while (i < Application.targetFrameRate ) 
        {
            Debug.Log("reset Cor running...");
            i++;
            yield return new WaitForSeconds(resetTime);
        }
        gOrandomSpinnerCenter.SetActive(true);

    }
    IEnumerator WaitOnAudio(float waitTime)
    {
       // Debug.Log("waiting" + waitTime);
            yield return new WaitForSeconds(waitTime);
        audioBackground.clip = clipBackGround;
        audioBackground.loop = true;
        audioBackground.Play();

    }

    public static void NeedsToBeAccessedElsewhere(MonoBehaviour instance)
    {
        instance.StartCoroutine(ResetSpinner(1f));
    }
    private void OnEnable()
    {
        inputManager.OnNewGameButton += StartNewGame;
    }
    private void OnDisable()
    {
        inputManager.OnNewGameButton -= StartNewGame;
    }
}
