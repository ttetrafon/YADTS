// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Common"",
            ""id"": ""3ac9331c-3d2b-4a20-b7c4-7de9a33e3088"",
            ""actions"": [
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""246eb042-e33c-4a4b-a53e-4bb3d58a5d01"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleMouse"",
                    ""type"": ""Button"",
                    ""id"": ""79a33da9-f2c9-41bb-b2d9-1ce8767cf5cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouse"",
                    ""type"": ""Button"",
                    ""id"": ""1d77381b-83f2-432f-9786-6a6d8e185a0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FastModifier"",
                    ""type"": ""Button"",
                    ""id"": ""dee9325b-2a19-45fe-98b6-e0454045c11d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlowModifier"",
                    ""type"": ""Button"",
                    ""id"": ""ae9f049f-1215-499a-be83-099aa61af66b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""344f59f0-e18d-498d-9739-e9521741dc71"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ba3173d-bd00-4410-857a-c5d2b0f61b2f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f4bd3b2-2d3b-4264-b6b2-3b441f88e088"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MiddleMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3ce51ad-1e15-48d7-a51d-8815c387cd70"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""RightMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45187e2e-a23e-41be-9885-bfd37f23a619"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""FastModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2e2d78d-b7a9-4ffb-aa63-79cd14e7bde4"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""SlowModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f60f0555-82d7-4f78-b435-881200cdf61d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""038cb53f-52c3-4927-95e7-a0283716362a"",
            ""actions"": [
                {
                    ""name"": ""Pan"",
                    ""type"": ""Value"",
                    ""id"": ""f3740503-d4aa-42c4-af8e-6a09375aec3d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5329efbf-907b-4d0b-b964-5e5acc361b69"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateZ"",
                    ""type"": ""Value"",
                    ""id"": ""27d9018a-6243-495b-bf81-45d08942372a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PanFront"",
                    ""type"": ""Value"",
                    ""id"": ""663f523c-d14a-4b30-8f06-57904550ee78"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAt"",
                    ""type"": ""Button"",
                    ""id"": ""0ced2612-e62e-4810-9b02-d2dcb545cb65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""numpad"",
                    ""id"": ""1bf21034-b6e8-45f5-8265-6728fca1f6d9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a042f55d-babb-4a60-bb94-996721de00b1"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2b053a00-2de2-436f-946a-5b60ff8db336"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4d2ca20f-22ea-4bc2-a520-300c26053b2b"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fc6cced3-f8a6-4d88-bd80-38ea1b9b0cd8"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1f96bd50-95bf-46ab-a637-24694d4ccb7c"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""numpad"",
                    ""id"": ""4d124eac-68b5-49c1-a5f3-eb08121465df"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8ad8d3b6-1a52-4e54-a8c3-0af309fcdfce"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""415341c8-63b5-4bd2-995f-4f7c1449cfe9"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""numpad"",
                    ""id"": ""17dcfbe4-4195-4bf9-98c3-9606bf1889fc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""RotateZ"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""08042f3c-c7a6-46cd-827a-ea6fde2c36b6"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""RotateZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""64bbec0d-addf-44bd-af34-ce3139cc138b"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""RotateZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""numpad"",
                    ""id"": ""b1ac5677-2aa1-4429-9082-c0eea5b33d95"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""PanFront"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""a36f0b56-8443-417b-9bdc-4ff1672ae4de"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""PanFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""ed7cfda8-46ba-48d2-91b8-d097e9ea6eef"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""PanFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4ec9b849-f9ad-415d-b6a7-5c3b62a17835"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""LookAt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Common
        m_Common = asset.FindActionMap("Common", throwIfNotFound: true);
        m_Common_MouseDelta = m_Common.FindAction("MouseDelta", throwIfNotFound: true);
        m_Common_MiddleMouse = m_Common.FindAction("MiddleMouse", throwIfNotFound: true);
        m_Common_RightMouse = m_Common.FindAction("RightMouse", throwIfNotFound: true);
        m_Common_FastModifier = m_Common.FindAction("FastModifier", throwIfNotFound: true);
        m_Common_SlowModifier = m_Common.FindAction("SlowModifier", throwIfNotFound: true);
        m_Common_MousePosition = m_Common.FindAction("MousePosition", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Pan = m_Camera.FindAction("Pan", throwIfNotFound: true);
        m_Camera_Move = m_Camera.FindAction("Move", throwIfNotFound: true);
        m_Camera_RotateZ = m_Camera.FindAction("RotateZ", throwIfNotFound: true);
        m_Camera_PanFront = m_Camera.FindAction("PanFront", throwIfNotFound: true);
        m_Camera_LookAt = m_Camera.FindAction("LookAt", throwIfNotFound: true);
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

    // Common
    private readonly InputActionMap m_Common;
    private ICommonActions m_CommonActionsCallbackInterface;
    private readonly InputAction m_Common_MouseDelta;
    private readonly InputAction m_Common_MiddleMouse;
    private readonly InputAction m_Common_RightMouse;
    private readonly InputAction m_Common_FastModifier;
    private readonly InputAction m_Common_SlowModifier;
    private readonly InputAction m_Common_MousePosition;
    public struct CommonActions
    {
        private @Controls m_Wrapper;
        public CommonActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseDelta => m_Wrapper.m_Common_MouseDelta;
        public InputAction @MiddleMouse => m_Wrapper.m_Common_MiddleMouse;
        public InputAction @RightMouse => m_Wrapper.m_Common_RightMouse;
        public InputAction @FastModifier => m_Wrapper.m_Common_FastModifier;
        public InputAction @SlowModifier => m_Wrapper.m_Common_SlowModifier;
        public InputAction @MousePosition => m_Wrapper.m_Common_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Common; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CommonActions set) { return set.Get(); }
        public void SetCallbacks(ICommonActions instance)
        {
            if (m_Wrapper.m_CommonActionsCallbackInterface != null)
            {
                @MouseDelta.started -= m_Wrapper.m_CommonActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_CommonActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_CommonActionsCallbackInterface.OnMouseDelta;
                @MiddleMouse.started -= m_Wrapper.m_CommonActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.performed -= m_Wrapper.m_CommonActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.canceled -= m_Wrapper.m_CommonActionsCallbackInterface.OnMiddleMouse;
                @RightMouse.started -= m_Wrapper.m_CommonActionsCallbackInterface.OnRightMouse;
                @RightMouse.performed -= m_Wrapper.m_CommonActionsCallbackInterface.OnRightMouse;
                @RightMouse.canceled -= m_Wrapper.m_CommonActionsCallbackInterface.OnRightMouse;
                @FastModifier.started -= m_Wrapper.m_CommonActionsCallbackInterface.OnFastModifier;
                @FastModifier.performed -= m_Wrapper.m_CommonActionsCallbackInterface.OnFastModifier;
                @FastModifier.canceled -= m_Wrapper.m_CommonActionsCallbackInterface.OnFastModifier;
                @SlowModifier.started -= m_Wrapper.m_CommonActionsCallbackInterface.OnSlowModifier;
                @SlowModifier.performed -= m_Wrapper.m_CommonActionsCallbackInterface.OnSlowModifier;
                @SlowModifier.canceled -= m_Wrapper.m_CommonActionsCallbackInterface.OnSlowModifier;
                @MousePosition.started -= m_Wrapper.m_CommonActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_CommonActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_CommonActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_CommonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @MiddleMouse.started += instance.OnMiddleMouse;
                @MiddleMouse.performed += instance.OnMiddleMouse;
                @MiddleMouse.canceled += instance.OnMiddleMouse;
                @RightMouse.started += instance.OnRightMouse;
                @RightMouse.performed += instance.OnRightMouse;
                @RightMouse.canceled += instance.OnRightMouse;
                @FastModifier.started += instance.OnFastModifier;
                @FastModifier.performed += instance.OnFastModifier;
                @FastModifier.canceled += instance.OnFastModifier;
                @SlowModifier.started += instance.OnSlowModifier;
                @SlowModifier.performed += instance.OnSlowModifier;
                @SlowModifier.canceled += instance.OnSlowModifier;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public CommonActions @Common => new CommonActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Pan;
    private readonly InputAction m_Camera_Move;
    private readonly InputAction m_Camera_RotateZ;
    private readonly InputAction m_Camera_PanFront;
    private readonly InputAction m_Camera_LookAt;
    public struct CameraActions
    {
        private @Controls m_Wrapper;
        public CameraActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pan => m_Wrapper.m_Camera_Pan;
        public InputAction @Move => m_Wrapper.m_Camera_Move;
        public InputAction @RotateZ => m_Wrapper.m_Camera_RotateZ;
        public InputAction @PanFront => m_Wrapper.m_Camera_PanFront;
        public InputAction @LookAt => m_Wrapper.m_Camera_LookAt;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Pan.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @Pan.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @Pan.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @Move.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @RotateZ.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateZ;
                @RotateZ.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateZ;
                @RotateZ.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateZ;
                @PanFront.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnPanFront;
                @PanFront.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnPanFront;
                @PanFront.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnPanFront;
                @LookAt.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLookAt;
                @LookAt.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLookAt;
                @LookAt.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLookAt;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pan.started += instance.OnPan;
                @Pan.performed += instance.OnPan;
                @Pan.canceled += instance.OnPan;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RotateZ.started += instance.OnRotateZ;
                @RotateZ.performed += instance.OnRotateZ;
                @RotateZ.canceled += instance.OnRotateZ;
                @PanFront.started += instance.OnPanFront;
                @PanFront.performed += instance.OnPanFront;
                @PanFront.canceled += instance.OnPanFront;
                @LookAt.started += instance.OnLookAt;
                @LookAt.performed += instance.OnLookAt;
                @LookAt.canceled += instance.OnLookAt;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface ICommonActions
    {
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnMiddleMouse(InputAction.CallbackContext context);
        void OnRightMouse(InputAction.CallbackContext context);
        void OnFastModifier(InputAction.CallbackContext context);
        void OnSlowModifier(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnPan(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotateZ(InputAction.CallbackContext context);
        void OnPanFront(InputAction.CallbackContext context);
        void OnLookAt(InputAction.CallbackContext context);
    }
}
