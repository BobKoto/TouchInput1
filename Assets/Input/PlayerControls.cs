// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""22d03797-5690-47a0-bdd6-a2c3bc7b478a"",
            ""actions"": [
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bb8fa5be-f661-4b99-ad95-27b80fe542ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9e538c51-6452-45ac-9043-4031e72f7773"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftButtonPress"",
                    ""type"": ""Button"",
                    ""id"": ""36f98f2d-0787-4c8e-a297-dd9ac1656ffe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightButtonPress"",
                    ""type"": ""Button"",
                    ""id"": ""5b9d7727-416e-480b-8c99-0b4e5474af7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TestLabButton"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3e85ed72-5613-41d9-9619-2a5d7470d53d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TestLabButton2"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c41d0032-704b-44e2-a383-a3f592f5d7b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootBallButton"",
                    ""type"": ""Button"",
                    ""id"": ""8ef3ff94-8569-404d-9f9e-c567b8fd29ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirstTouch"",
                    ""type"": ""Value"",
                    ""id"": ""4ab47169-5e39-4452-b63e-43ab3533cfea"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirstTouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""b06726cf-169d-4652-8ede-ca36a9c95292"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondTouch"",
                    ""type"": ""Value"",
                    ""id"": ""6b68b9b6-d664-4429-8224-ff45ca8f0fb9"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondTouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""47426c84-648a-4302-b9de-626f9d2b5ec2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NewGameButton"",
                    ""type"": ""Button"",
                    ""id"": ""d98d469a-e63b-4b84-9942-ea064ac7afee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""312e03b6-d632-43b9-b4ca-47c8de2fb4b3"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d932af11-cc60-45fa-ac2c-75af4ac02df0"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1822169f-1999-44d4-81a4-5f5ecd7702cb"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d64acae-7b03-472c-baf7-15f9b9d6cede"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ed0d830-9304-4339-bf19-9021b6f57f27"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebd67c88-59a0-4385-8f35-74d9763eb3c1"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72f4de45-f775-4b41-b95b-368f09caa51c"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": ""Tap,SlowTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestLabButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05c3ef0d-a6b2-45b0-ae68-1bfd624bf216"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Tap,SlowTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestLabButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8df0421a-cf40-461f-9317-38f71c43e831"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Tap,SlowTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestLabButton2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""300d8aa6-1dc3-4283-9311-272830c1b84e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Tap,SlowTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestLabButton2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86de82f8-345e-495f-a702-0f530fc0e3ef"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootBallButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac32f168-4520-4f6f-a8a0-19a85ba39499"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootBallButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f6e58db-538d-4415-8a8b-986068a79646"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8a3dc48-8636-4c9d-80c5-e1bc9ea611b2"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cbae150-5803-4a22-b661-6b5ebf47d0d7"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondTouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77397165-175d-4605-8507-2d7334f975cd"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstTouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""472db20f-9db7-40e6-9085-37121e0e8010"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NewGameButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38127b56-f65e-47aa-a406-3dbe4325c149"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NewGameButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_PrimaryContact = m_Touch.FindAction("PrimaryContact", throwIfNotFound: true);
        m_Touch_PrimaryPosition = m_Touch.FindAction("PrimaryPosition", throwIfNotFound: true);
        m_Touch_LeftButtonPress = m_Touch.FindAction("LeftButtonPress", throwIfNotFound: true);
        m_Touch_RightButtonPress = m_Touch.FindAction("RightButtonPress", throwIfNotFound: true);
        m_Touch_TestLabButton = m_Touch.FindAction("TestLabButton", throwIfNotFound: true);
        m_Touch_TestLabButton2 = m_Touch.FindAction("TestLabButton2", throwIfNotFound: true);
        m_Touch_ShootBallButton = m_Touch.FindAction("ShootBallButton", throwIfNotFound: true);
        m_Touch_FirstTouch = m_Touch.FindAction("FirstTouch", throwIfNotFound: true);
        m_Touch_FirstTouchPosition = m_Touch.FindAction("FirstTouchPosition", throwIfNotFound: true);
        m_Touch_SecondTouch = m_Touch.FindAction("SecondTouch", throwIfNotFound: true);
        m_Touch_SecondTouchPosition = m_Touch.FindAction("SecondTouchPosition", throwIfNotFound: true);
        m_Touch_NewGameButton = m_Touch.FindAction("NewGameButton", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_PrimaryContact;
    private readonly InputAction m_Touch_PrimaryPosition;
    private readonly InputAction m_Touch_LeftButtonPress;
    private readonly InputAction m_Touch_RightButtonPress;
    private readonly InputAction m_Touch_TestLabButton;
    private readonly InputAction m_Touch_TestLabButton2;
    private readonly InputAction m_Touch_ShootBallButton;
    private readonly InputAction m_Touch_FirstTouch;
    private readonly InputAction m_Touch_FirstTouchPosition;
    private readonly InputAction m_Touch_SecondTouch;
    private readonly InputAction m_Touch_SecondTouchPosition;
    private readonly InputAction m_Touch_NewGameButton;
    public struct TouchActions
    {
        private @PlayerControls m_Wrapper;
        public TouchActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryContact => m_Wrapper.m_Touch_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_Touch_PrimaryPosition;
        public InputAction @LeftButtonPress => m_Wrapper.m_Touch_LeftButtonPress;
        public InputAction @RightButtonPress => m_Wrapper.m_Touch_RightButtonPress;
        public InputAction @TestLabButton => m_Wrapper.m_Touch_TestLabButton;
        public InputAction @TestLabButton2 => m_Wrapper.m_Touch_TestLabButton2;
        public InputAction @ShootBallButton => m_Wrapper.m_Touch_ShootBallButton;
        public InputAction @FirstTouch => m_Wrapper.m_Touch_FirstTouch;
        public InputAction @FirstTouchPosition => m_Wrapper.m_Touch_FirstTouchPosition;
        public InputAction @SecondTouch => m_Wrapper.m_Touch_SecondTouch;
        public InputAction @SecondTouchPosition => m_Wrapper.m_Touch_SecondTouchPosition;
        public InputAction @NewGameButton => m_Wrapper.m_Touch_NewGameButton;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @PrimaryContact.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @LeftButtonPress.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnLeftButtonPress;
                @LeftButtonPress.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnLeftButtonPress;
                @LeftButtonPress.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnLeftButtonPress;
                @RightButtonPress.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnRightButtonPress;
                @RightButtonPress.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnRightButtonPress;
                @RightButtonPress.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnRightButtonPress;
                @TestLabButton.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTestLabButton;
                @TestLabButton.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTestLabButton;
                @TestLabButton.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTestLabButton;
                @TestLabButton2.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTestLabButton2;
                @TestLabButton2.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTestLabButton2;
                @TestLabButton2.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTestLabButton2;
                @ShootBallButton.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnShootBallButton;
                @ShootBallButton.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnShootBallButton;
                @ShootBallButton.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnShootBallButton;
                @FirstTouch.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstTouch;
                @FirstTouch.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstTouch;
                @FirstTouch.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstTouch;
                @FirstTouchPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstTouchPosition;
                @FirstTouchPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstTouchPosition;
                @FirstTouchPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstTouchPosition;
                @SecondTouch.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondTouch;
                @SecondTouch.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondTouch;
                @SecondTouch.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondTouch;
                @SecondTouchPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondTouchPosition;
                @SecondTouchPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondTouchPosition;
                @SecondTouchPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondTouchPosition;
                @NewGameButton.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnNewGameButton;
                @NewGameButton.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnNewGameButton;
                @NewGameButton.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnNewGameButton;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
                @LeftButtonPress.started += instance.OnLeftButtonPress;
                @LeftButtonPress.performed += instance.OnLeftButtonPress;
                @LeftButtonPress.canceled += instance.OnLeftButtonPress;
                @RightButtonPress.started += instance.OnRightButtonPress;
                @RightButtonPress.performed += instance.OnRightButtonPress;
                @RightButtonPress.canceled += instance.OnRightButtonPress;
                @TestLabButton.started += instance.OnTestLabButton;
                @TestLabButton.performed += instance.OnTestLabButton;
                @TestLabButton.canceled += instance.OnTestLabButton;
                @TestLabButton2.started += instance.OnTestLabButton2;
                @TestLabButton2.performed += instance.OnTestLabButton2;
                @TestLabButton2.canceled += instance.OnTestLabButton2;
                @ShootBallButton.started += instance.OnShootBallButton;
                @ShootBallButton.performed += instance.OnShootBallButton;
                @ShootBallButton.canceled += instance.OnShootBallButton;
                @FirstTouch.started += instance.OnFirstTouch;
                @FirstTouch.performed += instance.OnFirstTouch;
                @FirstTouch.canceled += instance.OnFirstTouch;
                @FirstTouchPosition.started += instance.OnFirstTouchPosition;
                @FirstTouchPosition.performed += instance.OnFirstTouchPosition;
                @FirstTouchPosition.canceled += instance.OnFirstTouchPosition;
                @SecondTouch.started += instance.OnSecondTouch;
                @SecondTouch.performed += instance.OnSecondTouch;
                @SecondTouch.canceled += instance.OnSecondTouch;
                @SecondTouchPosition.started += instance.OnSecondTouchPosition;
                @SecondTouchPosition.performed += instance.OnSecondTouchPosition;
                @SecondTouchPosition.canceled += instance.OnSecondTouchPosition;
                @NewGameButton.started += instance.OnNewGameButton;
                @NewGameButton.performed += instance.OnNewGameButton;
                @NewGameButton.canceled += instance.OnNewGameButton;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
        void OnLeftButtonPress(InputAction.CallbackContext context);
        void OnRightButtonPress(InputAction.CallbackContext context);
        void OnTestLabButton(InputAction.CallbackContext context);
        void OnTestLabButton2(InputAction.CallbackContext context);
        void OnShootBallButton(InputAction.CallbackContext context);
        void OnFirstTouch(InputAction.CallbackContext context);
        void OnFirstTouchPosition(InputAction.CallbackContext context);
        void OnSecondTouch(InputAction.CallbackContext context);
        void OnSecondTouchPosition(InputAction.CallbackContext context);
        void OnNewGameButton(InputAction.CallbackContext context);
    }
}
