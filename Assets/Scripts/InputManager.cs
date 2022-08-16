//using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>     //MonoBehaviour
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    public delegate void LeftButtonPress();
    public event LeftButtonPress OnLeftButtonPress;
    public delegate void RightButtonPress();
    public event LeftButtonPress OnRightButtonPress;
   
    public delegate void TestLabButton(InputAction.CallbackContext context);
    public event TestLabButton OnTestLabButton;
    public delegate void TestLabButton2(InputAction.CallbackContext context);
    public event TestLabButton OnTestLabButton2;

    public delegate void ShootBallButton();
    public event ShootBallButton OnShootBallButton;

    public delegate void NewGameButton();
    public event NewGameButton OnNewGameButton;

    //New, to replace buttons with straight Touches - FirstTouch and SeconTouch - logic will have to sort out which flipper activates

    public delegate void FirstTouch(InputAction.CallbackContext context);
    public event FirstTouch OnFirstTouch;
    public delegate void SecondTouch(InputAction.CallbackContext context);
    public event SecondTouch OnSecondTouch;

    #endregion

    private PlayerControls playerControls;
    private Camera mainCamera;

    private void Awake()
    {
        playerControls = new PlayerControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        EnhancedTouchSupport.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
        EnhancedTouchSupport.Disable();
    }
    void Start()
    {
        // Subscribe to Events
        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);

        playerControls.Touch.LeftButtonPress.performed += ctx => DoLeftButtonPress(ctx);
        playerControls.Touch.RightButtonPress.performed += ctx => DoRightButtonPress(ctx);

        playerControls.Touch.TestLabButton.started += ctx => DoTestLabButton(ctx);
        playerControls.Touch.TestLabButton.performed += ctx => DoTestLabButton(ctx);
        playerControls.Touch.TestLabButton.canceled += ctx => DoTestLabButton(ctx);

        playerControls.Touch.TestLabButton2.started += ctx => DoTestLabButton2(ctx);
        playerControls.Touch.TestLabButton2.performed += ctx => DoTestLabButton2(ctx);
        playerControls.Touch.TestLabButton2.canceled += ctx => DoTestLabButton2(ctx);

        playerControls.Touch.ShootBallButton.performed += ctx => DoShootBall(ctx);
        playerControls.Touch.NewGameButton.performed += ctx => DoNewGame(ctx);

        playerControls.Touch.FirstTouch.started += ctx => DoFirstTouch(ctx);
        playerControls.Touch.FirstTouch.performed += ctx => DoFirstTouch(ctx);
        playerControls.Touch.FirstTouch.canceled += ctx => DoFirstTouch(ctx);
        
        playerControls.Touch.SecondTouch.started += ctx => DoSecondTouch(ctx);
        playerControls.Touch.SecondTouch.performed += ctx => DoSecondTouch(ctx);
        playerControls.Touch.SecondTouch.canceled += ctx => DoSecondTouch(ctx);
       // Debug.Log("InputManager started");

    }
    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
            OnStartTouch(Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
            OnEndTouch(Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }
    public Vector2 PrimaryPosition()    //for Trailer 
    {
        return Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
    private void DoLeftButtonPress(InputAction.CallbackContext  context)
    {
        if (OnLeftButtonPress != null)
            OnLeftButtonPress();
    }
    private void DoRightButtonPress(InputAction.CallbackContext context)
    {
        if (OnRightButtonPress != null)
            OnRightButtonPress();
    }
    private void DoTestLabButton(InputAction.CallbackContext context)
    {
        if (OnTestLabButton != null)
            OnTestLabButton(context);
    }
    private void DoTestLabButton2(InputAction.CallbackContext context)
    {
        if (OnTestLabButton2 != null)
            OnTestLabButton2(context);
    }
  
    private void DoFirstTouch(InputAction.CallbackContext context)
    {
        if (OnFirstTouch != null)
            OnFirstTouch(context);
    }
    public Vector2 FirstTouchPosition()
    {
        return playerControls.Touch.FirstTouchPosition.ReadValue<Vector2>();
    }
   
    private void DoSecondTouch(InputAction.CallbackContext context)
    {
        if (OnSecondTouch != null)
            OnSecondTouch(context);
    }
     public Vector2 SecondTouchPosition()
     {
        return playerControls.Touch.SecondTouchPosition.ReadValue<Vector2>();
     }
    private void DoShootBall(InputAction.CallbackContext context)
    {
        if (OnShootBallButton != null)
            OnShootBallButton();
    }
    private void DoNewGame(InputAction.CallbackContext context)
    {
        if (OnNewGameButton != null)
            OnNewGameButton();
    }
}
