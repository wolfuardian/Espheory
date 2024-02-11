//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Gameplay/Input/GameInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""515def80-2939-46f8-b09d-128827227315"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""455bb10a-7e69-4ad1-a346-2eb67e32b587"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""Button"",
                    ""id"": ""962f67b7-1467-4e35-8b9c-2fc576ef06b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""6e59c279-9a6e-44e7-ab5f-1b303f93f8e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""69ff55a9-ea54-464b-97b3-912d30e06ff0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveVertical"",
                    ""type"": ""Value"",
                    ""id"": ""180be205-58dc-467c-b35c-8d2ee73c8a2e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PointerDelta"",
                    ""type"": ""Value"",
                    ""id"": ""1cd3710e-cddd-4658-8aa7-b588312d9f45"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pointer"",
                    ""type"": ""Value"",
                    ""id"": ""18cef54f-f938-4c1e-9f92-f320ab491371"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""NextDollyLevel"",
                    ""type"": ""Button"",
                    ""id"": ""81584ec2-45f3-4c22-b9fb-db1291d93b27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""feb33151-4e42-46be-96f8-3bab332eb5ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnAround"",
                    ""type"": ""Button"",
                    ""id"": ""823ccb02-ad9e-4b1c-bfe7-80bbd825ebfb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockOnTarget"",
                    ""type"": ""Button"",
                    ""id"": ""e5c963f3-a1b5-427d-b756-f36c1c35009c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UnlockTarget"",
                    ""type"": ""Button"",
                    ""id"": ""d71bd470-e01b-4590-ba8d-b90e232cfdff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextTarget"",
                    ""type"": ""Button"",
                    ""id"": ""ef29aae0-92e1-4bf8-9d64-368c4f495358"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PrevTarget"",
                    ""type"": ""Button"",
                    ""id"": ""7dd01b23-9cf6-443c-91db-fcdf6fc0f641"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d5788563-028b-4fca-aed6-c19a97679199"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PointerDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90d40fb3-392b-4e7f-a971-dd62e7d02625"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""NextDollyLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""726cdbd5-fbfb-4847-86be-66437a559773"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94fb2ce2-903f-4414-8ad3-225d07ab195a"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""TurnAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e68f74b-2b21-411e-8108-ece56750a309"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""LockOnTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d3dcdfd-26a2-499a-b7d5-b79b37fcb124"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""UnlockTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72b1b5a1-2e29-4e92-ab47-7b0efc15273a"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""NextTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66130fb5-57cf-4972-b418-23cdd028af22"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PrevTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b51776ab-cc10-4869-bd28-847c3754a593"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PrevTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e23176dc-36ca-46d7-a198-5b4142fa900d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""641a1c6f-06e6-4942-bd7c-6bf5be9d7026"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7fd4a9c2-f526-43de-89ca-44df0708fc65"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""ce19ff97-2918-44fd-b441-177db6ad249a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""244d453a-20d9-4712-9d85-0aa699d02c2a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""411f0a3f-5c20-420a-8a9d-b90e5e1ac240"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b26f6a32-1d96-4ec4-9f72-f2f97b5e5bc7"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2e062c79-b911-4827-bef6-482054201f76"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3fdb121f-99a2-49da-bc81-c097fd79520c"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""42993bc6-d40e-4bec-9eae-7b0d602418f3"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MoveVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ac0d7d8e-7a5f-473c-bbfb-18466ccd9ed7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ae8b5a6-3870-4255-95a5-af9787f6b699"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""NS"",
            ""bindingGroup"": ""NS"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Select = m_Player.FindAction("Select", throwIfNotFound: true);
        m_Player_LookAround = m_Player.FindAction("LookAround", throwIfNotFound: true);
        m_Player_MoveForward = m_Player.FindAction("MoveForward", throwIfNotFound: true);
        m_Player_MoveHorizontal = m_Player.FindAction("MoveHorizontal", throwIfNotFound: true);
        m_Player_MoveVertical = m_Player.FindAction("MoveVertical", throwIfNotFound: true);
        m_Player_PointerDelta = m_Player.FindAction("PointerDelta", throwIfNotFound: true);
        m_Player_Pointer = m_Player.FindAction("Pointer", throwIfNotFound: true);
        m_Player_NextDollyLevel = m_Player.FindAction("NextDollyLevel", throwIfNotFound: true);
        m_Player_Dodge = m_Player.FindAction("Dodge", throwIfNotFound: true);
        m_Player_TurnAround = m_Player.FindAction("TurnAround", throwIfNotFound: true);
        m_Player_LockOnTarget = m_Player.FindAction("LockOnTarget", throwIfNotFound: true);
        m_Player_UnlockTarget = m_Player.FindAction("UnlockTarget", throwIfNotFound: true);
        m_Player_NextTarget = m_Player.FindAction("NextTarget", throwIfNotFound: true);
        m_Player_PrevTarget = m_Player.FindAction("PrevTarget", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Select;
    private readonly InputAction m_Player_LookAround;
    private readonly InputAction m_Player_MoveForward;
    private readonly InputAction m_Player_MoveHorizontal;
    private readonly InputAction m_Player_MoveVertical;
    private readonly InputAction m_Player_PointerDelta;
    private readonly InputAction m_Player_Pointer;
    private readonly InputAction m_Player_NextDollyLevel;
    private readonly InputAction m_Player_Dodge;
    private readonly InputAction m_Player_TurnAround;
    private readonly InputAction m_Player_LockOnTarget;
    private readonly InputAction m_Player_UnlockTarget;
    private readonly InputAction m_Player_NextTarget;
    private readonly InputAction m_Player_PrevTarget;
    public struct PlayerActions
    {
        private @GameInput m_Wrapper;
        public PlayerActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Player_Select;
        public InputAction @LookAround => m_Wrapper.m_Player_LookAround;
        public InputAction @MoveForward => m_Wrapper.m_Player_MoveForward;
        public InputAction @MoveHorizontal => m_Wrapper.m_Player_MoveHorizontal;
        public InputAction @MoveVertical => m_Wrapper.m_Player_MoveVertical;
        public InputAction @PointerDelta => m_Wrapper.m_Player_PointerDelta;
        public InputAction @Pointer => m_Wrapper.m_Player_Pointer;
        public InputAction @NextDollyLevel => m_Wrapper.m_Player_NextDollyLevel;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @TurnAround => m_Wrapper.m_Player_TurnAround;
        public InputAction @LockOnTarget => m_Wrapper.m_Player_LockOnTarget;
        public InputAction @UnlockTarget => m_Wrapper.m_Player_UnlockTarget;
        public InputAction @NextTarget => m_Wrapper.m_Player_NextTarget;
        public InputAction @PrevTarget => m_Wrapper.m_Player_PrevTarget;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
            @LookAround.started += instance.OnLookAround;
            @LookAround.performed += instance.OnLookAround;
            @LookAround.canceled += instance.OnLookAround;
            @MoveForward.started += instance.OnMoveForward;
            @MoveForward.performed += instance.OnMoveForward;
            @MoveForward.canceled += instance.OnMoveForward;
            @MoveHorizontal.started += instance.OnMoveHorizontal;
            @MoveHorizontal.performed += instance.OnMoveHorizontal;
            @MoveHorizontal.canceled += instance.OnMoveHorizontal;
            @MoveVertical.started += instance.OnMoveVertical;
            @MoveVertical.performed += instance.OnMoveVertical;
            @MoveVertical.canceled += instance.OnMoveVertical;
            @PointerDelta.started += instance.OnPointerDelta;
            @PointerDelta.performed += instance.OnPointerDelta;
            @PointerDelta.canceled += instance.OnPointerDelta;
            @Pointer.started += instance.OnPointer;
            @Pointer.performed += instance.OnPointer;
            @Pointer.canceled += instance.OnPointer;
            @NextDollyLevel.started += instance.OnNextDollyLevel;
            @NextDollyLevel.performed += instance.OnNextDollyLevel;
            @NextDollyLevel.canceled += instance.OnNextDollyLevel;
            @Dodge.started += instance.OnDodge;
            @Dodge.performed += instance.OnDodge;
            @Dodge.canceled += instance.OnDodge;
            @TurnAround.started += instance.OnTurnAround;
            @TurnAround.performed += instance.OnTurnAround;
            @TurnAround.canceled += instance.OnTurnAround;
            @LockOnTarget.started += instance.OnLockOnTarget;
            @LockOnTarget.performed += instance.OnLockOnTarget;
            @LockOnTarget.canceled += instance.OnLockOnTarget;
            @UnlockTarget.started += instance.OnUnlockTarget;
            @UnlockTarget.performed += instance.OnUnlockTarget;
            @UnlockTarget.canceled += instance.OnUnlockTarget;
            @NextTarget.started += instance.OnNextTarget;
            @NextTarget.performed += instance.OnNextTarget;
            @NextTarget.canceled += instance.OnNextTarget;
            @PrevTarget.started += instance.OnPrevTarget;
            @PrevTarget.performed += instance.OnPrevTarget;
            @PrevTarget.canceled += instance.OnPrevTarget;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
            @LookAround.started -= instance.OnLookAround;
            @LookAround.performed -= instance.OnLookAround;
            @LookAround.canceled -= instance.OnLookAround;
            @MoveForward.started -= instance.OnMoveForward;
            @MoveForward.performed -= instance.OnMoveForward;
            @MoveForward.canceled -= instance.OnMoveForward;
            @MoveHorizontal.started -= instance.OnMoveHorizontal;
            @MoveHorizontal.performed -= instance.OnMoveHorizontal;
            @MoveHorizontal.canceled -= instance.OnMoveHorizontal;
            @MoveVertical.started -= instance.OnMoveVertical;
            @MoveVertical.performed -= instance.OnMoveVertical;
            @MoveVertical.canceled -= instance.OnMoveVertical;
            @PointerDelta.started -= instance.OnPointerDelta;
            @PointerDelta.performed -= instance.OnPointerDelta;
            @PointerDelta.canceled -= instance.OnPointerDelta;
            @Pointer.started -= instance.OnPointer;
            @Pointer.performed -= instance.OnPointer;
            @Pointer.canceled -= instance.OnPointer;
            @NextDollyLevel.started -= instance.OnNextDollyLevel;
            @NextDollyLevel.performed -= instance.OnNextDollyLevel;
            @NextDollyLevel.canceled -= instance.OnNextDollyLevel;
            @Dodge.started -= instance.OnDodge;
            @Dodge.performed -= instance.OnDodge;
            @Dodge.canceled -= instance.OnDodge;
            @TurnAround.started -= instance.OnTurnAround;
            @TurnAround.performed -= instance.OnTurnAround;
            @TurnAround.canceled -= instance.OnTurnAround;
            @LockOnTarget.started -= instance.OnLockOnTarget;
            @LockOnTarget.performed -= instance.OnLockOnTarget;
            @LockOnTarget.canceled -= instance.OnLockOnTarget;
            @UnlockTarget.started -= instance.OnUnlockTarget;
            @UnlockTarget.performed -= instance.OnUnlockTarget;
            @UnlockTarget.canceled -= instance.OnUnlockTarget;
            @NextTarget.started -= instance.OnNextTarget;
            @NextTarget.performed -= instance.OnNextTarget;
            @NextTarget.canceled -= instance.OnNextTarget;
            @PrevTarget.started -= instance.OnPrevTarget;
            @PrevTarget.performed -= instance.OnPrevTarget;
            @PrevTarget.canceled -= instance.OnPrevTarget;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    private int m_NSSchemeIndex = -1;
    public InputControlScheme NSScheme
    {
        get
        {
            if (m_NSSchemeIndex == -1) m_NSSchemeIndex = asset.FindControlSchemeIndex("NS");
            return asset.controlSchemes[m_NSSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
        void OnMoveForward(InputAction.CallbackContext context);
        void OnMoveHorizontal(InputAction.CallbackContext context);
        void OnMoveVertical(InputAction.CallbackContext context);
        void OnPointerDelta(InputAction.CallbackContext context);
        void OnPointer(InputAction.CallbackContext context);
        void OnNextDollyLevel(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnTurnAround(InputAction.CallbackContext context);
        void OnLockOnTarget(InputAction.CallbackContext context);
        void OnUnlockTarget(InputAction.CallbackContext context);
        void OnNextTarget(InputAction.CallbackContext context);
        void OnPrevTarget(InputAction.CallbackContext context);
    }
}
