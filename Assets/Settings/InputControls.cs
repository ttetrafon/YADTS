// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""10af5bc7-3c54-4d2a-9483-f5d8d11104a0"",
            ""actions"": [
                {
                    ""name"": ""Pan"",
                    ""type"": ""Value"",
                    ""id"": ""c9b9eac9-18b3-450c-bcd6-bb880c73e130"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7d5d0e0a-7656-4b78-a5a7-abf7b1044628"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateVertical"",
                    ""type"": ""Value"",
                    ""id"": ""b9e2a5a0-4176-4d59-8472-cc4213509868"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateFront"",
                    ""type"": ""Value"",
                    ""id"": ""762a5cac-6ca3-4c78-93c9-77b6a342968e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAt"",
                    ""type"": ""Button"",
                    ""id"": ""d707441f-7604-41d4-9bf9-425d4d5f4cc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""6f41e6fb-4c32-4299-8f3e-c8d8fe1c79c6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlowCameraModifier"",
                    ""type"": ""Button"",
                    ""id"": ""15e9c677-9c93-44da-af19-75a01ace4b2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FastCameraModifier"",
                    ""type"": ""Button"",
                    ""id"": ""a0aa9f20-245b-461b-9d50-743804ce7256"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""numpad"",
                    ""id"": ""39e889ce-c245-44f6-ad09-b9c08519bfe7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""688319a1-5cbd-496e-b526-d845069cf4d4"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a046ac46-61ef-47fc-9218-42627ed2c540"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""626f1f8c-1bc8-435e-b2d5-3c434a1b9a4f"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""811bffeb-1b35-4a01-b281-6a50dbb07383"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""mouse"",
                    ""id"": ""031f7d3a-5a93-418b-9979-bd34345aeee8"",
                    ""path"": ""Custom"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Multiplier"",
                    ""id"": ""9acc5f46-efaf-4c81-b158-8c941aa6b98d"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""c4bb1741-b1d4-4258-aa95-1b0720e6f79f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""numpad"",
                    ""id"": ""7efdd9f6-3f2b-4f74-86b8-c56d3ad9935b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4a0400a0-b3d4-421a-9ec0-0fbad62c55f5"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7b8caa06-55bf-4ccc-b68c-ae7d63713a20"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4f40edf3-34b1-47e2-a7d4-57d2af4d20da"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""LookAt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""numpad"",
                    ""id"": ""ad3cb087-f186-440c-8b06-4241c2d1a508"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateFront"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""74771525-0e00-47fb-9cbd-1f08b13933a1"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""07140ba9-34b1-4272-b298-9fa7c9d8bbd4"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""numpad"",
                    ""id"": ""c8de137d-c43d-456f-9233-2e39c34d7c2f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f51e0581-816d-4276-866c-a50bda47c917"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""303f3fc2-0748-436a-ba8c-ac92a0ee8661"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""mouse"",
                    ""id"": ""72db6898-60ba-49b8-87b6-99dbf07843d9"",
                    ""path"": ""Custom"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""multiplier"",
                    ""id"": ""0456f449-80db-4b1c-b7fc-7ca589d5c507"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""stick"",
                    ""id"": ""f2420cb1-bd90-46dd-8baf-b1c5ed6ab11b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""467e0ce8-5f7f-4a4a-91ec-10edfa118e44"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""SlowCameraModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48b4da29-c8c7-458c-8e4a-61872867d7f6"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""FastCameraModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1e50309-1c5b-49d0-bcce-c041088f737b"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MapController"",
            ""id"": ""d3b37a24-12dd-4a4b-8f6d-33410be34a1b"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""e52e52e2-e1d1-431d-b3b4-c37684db1b4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a9ee2d42-6864-489b-8351-a3796692984f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Modifier_Shift"",
                    ""type"": ""Button"",
                    ""id"": ""9c24327d-641a-4aa8-a62c-e796d34d6c2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapObjectMovementEnded"",
                    ""type"": ""Button"",
                    ""id"": ""e1c3581c-378e-4331-b694-bf848510a217"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveXY"",
                    ""type"": ""Value"",
                    ""id"": ""4e7dfd80-14db-49ae-a41d-1f4ff11b01c7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveZ"",
                    ""type"": ""Value"",
                    ""id"": ""5cb5693e-1026-4553-8baa-cbc75290b514"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateZ"",
                    ""type"": ""Value"",
                    ""id"": ""eb9f0c3b-5b11-4117-b129-d399e6c5ab26"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateFront"",
                    ""type"": ""Value"",
                    ""id"": ""08ed697e-602d-4f9c-9fa4-715594a065db"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateSide"",
                    ""type"": ""Value"",
                    ""id"": ""ea614eda-288c-4773-91bf-1dfc0fcf279a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelMapOperations"",
                    ""type"": ""Button"",
                    ""id"": ""807672e6-af06-4b7d-aba8-8430b0bd9f4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""72945cea-6c02-409b-ade5-b258f7901bf0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63c3752f-a9a4-4377-9e3e-105854f3b8c6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5a85fe8-1a2b-46d3-adb3-4620db87cd03"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""Modifier_Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""x+mouse"",
                    ""id"": ""004e7418-f92b-4937-801c-83d02d209bd7"",
                    ""path"": ""Custom"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""MoveXY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Multiplier"",
                    ""id"": ""75d2fee0-0359-4324-93d0-0aacbd9a948d"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""ac132fb2-06cb-452a-9721-337a77b24769"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arrows"",
                    ""id"": ""d047b8d6-ad4b-4a69-9727-a79e757425b0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveXY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f9ca7f22-017c-4ed9-8e50-5498b72b8d5f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""74afd549-8483-4488-996f-625fc80e4aef"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81436101-35cd-4b04-baf5-f0827792aa0a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5c5161c6-d8b0-4206-b238-11760bae2123"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0b38646d-0de5-43f5-9159-5a90b88887a0"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""849d9e68-f9ec-4985-9dbf-11da3d302bbb"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""631f34f1-7e5e-4fe4-a41f-0ddaf8bd61c6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""135222f3-46c2-4555-bcb2-5bd9e74dc7b9"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5865037-a32d-49bb-81b5-1c756b769a05"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffe36870-b113-4dd7-bba9-4309254576dc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3b47985-aa12-4bae-a0e9-c83fae586ddf"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3b25ccd-46b7-4d46-9bc4-3a270e29b210"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3570788-180b-49ac-9151-61c703a2d58a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MapObjectMovementEnded"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ac8df33c-7e9d-4ad9-93be-a0ca92c48b34"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveZ"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""z+mouse"",
                    ""id"": ""b62e9bbb-edd7-4492-89c4-852377cab254"",
                    ""path"": ""Custom"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveZ"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Multiplier"",
                    ""id"": ""bb373671-c624-4fc5-a5c8-913714190700"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""394d4ea9-963c-4252-9ac1-191f4b886f88"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MoveZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""r+mouse"",
                    ""id"": ""8a7083a1-0b66-45bd-8d2f-3b3977e6915d"",
                    ""path"": ""Custom"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateZ"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Multiplier"",
                    ""id"": ""ed324619-6796-4adf-96f8-1adff0188dae"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""df8e8ab7-1c75-4f3d-b7c5-0607b1830200"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""f+mouse"",
                    ""id"": ""dc555ed0-eed8-47b6-a124-c1f00db3b72e"",
                    ""path"": ""Custom"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateFront"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Multiplier"",
                    ""id"": ""cdb93f5a-a468-4a2a-85ff-c5bdb0029fe1"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""0a5aeb1d-58c0-4d54-b63d-ed01dd44dfad"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""t+mouse"",
                    ""id"": ""95da67a3-a18e-44d9-bf7e-4e8a9ced84d2"",
                    ""path"": ""Custom"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateSide"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Multiplier"",
                    ""id"": ""226f1d8a-0b1b-4cc8-95fc-9a9e0975b0ea"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateSide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""bd5da038-fd1c-49bf-b0f2-83731e1d6b00"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""RotateSide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a95e3fcb-ac36-4b3a-8d00-1ed03a3f6b19"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""CancelMapOperations"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interface"",
            ""id"": ""7e9b272d-048c-46d4-969b-fb6e25f2d08d"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b83dfae7-e588-4792-968b-75548afb2737"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""623891d5-3f5f-4606-a2a6-cfcf7574c64a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard-Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard-Mouse"",
            ""bindingGroup"": ""Keyboard-Mouse"",
            ""devices"": []
        }
    ]
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Pan = m_Camera.FindAction("Pan", throwIfNotFound: true);
        m_Camera_Move = m_Camera.FindAction("Move", throwIfNotFound: true);
        m_Camera_RotateVertical = m_Camera.FindAction("RotateVertical", throwIfNotFound: true);
        m_Camera_RotateFront = m_Camera.FindAction("RotateFront", throwIfNotFound: true);
        m_Camera_LookAt = m_Camera.FindAction("LookAt", throwIfNotFound: true);
        m_Camera_MouseLook = m_Camera.FindAction("MouseLook", throwIfNotFound: true);
        m_Camera_SlowCameraModifier = m_Camera.FindAction("SlowCameraModifier", throwIfNotFound: true);
        m_Camera_FastCameraModifier = m_Camera.FindAction("FastCameraModifier", throwIfNotFound: true);
        // MapController
        m_MapController = asset.FindActionMap("MapController", throwIfNotFound: true);
        m_MapController_Select = m_MapController.FindAction("Select", throwIfNotFound: true);
        m_MapController_MousePosition = m_MapController.FindAction("MousePosition", throwIfNotFound: true);
        m_MapController_Modifier_Shift = m_MapController.FindAction("Modifier_Shift", throwIfNotFound: true);
        m_MapController_MapObjectMovementEnded = m_MapController.FindAction("MapObjectMovementEnded", throwIfNotFound: true);
        m_MapController_MoveXY = m_MapController.FindAction("MoveXY", throwIfNotFound: true);
        m_MapController_MoveZ = m_MapController.FindAction("MoveZ", throwIfNotFound: true);
        m_MapController_RotateZ = m_MapController.FindAction("RotateZ", throwIfNotFound: true);
        m_MapController_RotateFront = m_MapController.FindAction("RotateFront", throwIfNotFound: true);
        m_MapController_RotateSide = m_MapController.FindAction("RotateSide", throwIfNotFound: true);
        m_MapController_CancelMapOperations = m_MapController.FindAction("CancelMapOperations", throwIfNotFound: true);
        // Interface
        m_Interface = asset.FindActionMap("Interface", throwIfNotFound: true);
        m_Interface_MousePosition = m_Interface.FindAction("MousePosition", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Pan;
    private readonly InputAction m_Camera_Move;
    private readonly InputAction m_Camera_RotateVertical;
    private readonly InputAction m_Camera_RotateFront;
    private readonly InputAction m_Camera_LookAt;
    private readonly InputAction m_Camera_MouseLook;
    private readonly InputAction m_Camera_SlowCameraModifier;
    private readonly InputAction m_Camera_FastCameraModifier;
    public struct CameraActions
    {
        private @InputControls m_Wrapper;
        public CameraActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pan => m_Wrapper.m_Camera_Pan;
        public InputAction @Move => m_Wrapper.m_Camera_Move;
        public InputAction @RotateVertical => m_Wrapper.m_Camera_RotateVertical;
        public InputAction @RotateFront => m_Wrapper.m_Camera_RotateFront;
        public InputAction @LookAt => m_Wrapper.m_Camera_LookAt;
        public InputAction @MouseLook => m_Wrapper.m_Camera_MouseLook;
        public InputAction @SlowCameraModifier => m_Wrapper.m_Camera_SlowCameraModifier;
        public InputAction @FastCameraModifier => m_Wrapper.m_Camera_FastCameraModifier;
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
                @RotateVertical.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateVertical;
                @RotateVertical.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateVertical;
                @RotateVertical.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateVertical;
                @RotateFront.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateFront;
                @RotateFront.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateFront;
                @RotateFront.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateFront;
                @LookAt.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLookAt;
                @LookAt.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLookAt;
                @LookAt.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLookAt;
                @MouseLook.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseLook;
                @SlowCameraModifier.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnSlowCameraModifier;
                @SlowCameraModifier.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnSlowCameraModifier;
                @SlowCameraModifier.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnSlowCameraModifier;
                @FastCameraModifier.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnFastCameraModifier;
                @FastCameraModifier.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnFastCameraModifier;
                @FastCameraModifier.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnFastCameraModifier;
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
                @RotateVertical.started += instance.OnRotateVertical;
                @RotateVertical.performed += instance.OnRotateVertical;
                @RotateVertical.canceled += instance.OnRotateVertical;
                @RotateFront.started += instance.OnRotateFront;
                @RotateFront.performed += instance.OnRotateFront;
                @RotateFront.canceled += instance.OnRotateFront;
                @LookAt.started += instance.OnLookAt;
                @LookAt.performed += instance.OnLookAt;
                @LookAt.canceled += instance.OnLookAt;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @SlowCameraModifier.started += instance.OnSlowCameraModifier;
                @SlowCameraModifier.performed += instance.OnSlowCameraModifier;
                @SlowCameraModifier.canceled += instance.OnSlowCameraModifier;
                @FastCameraModifier.started += instance.OnFastCameraModifier;
                @FastCameraModifier.performed += instance.OnFastCameraModifier;
                @FastCameraModifier.canceled += instance.OnFastCameraModifier;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // MapController
    private readonly InputActionMap m_MapController;
    private IMapControllerActions m_MapControllerActionsCallbackInterface;
    private readonly InputAction m_MapController_Select;
    private readonly InputAction m_MapController_MousePosition;
    private readonly InputAction m_MapController_Modifier_Shift;
    private readonly InputAction m_MapController_MapObjectMovementEnded;
    private readonly InputAction m_MapController_MoveXY;
    private readonly InputAction m_MapController_MoveZ;
    private readonly InputAction m_MapController_RotateZ;
    private readonly InputAction m_MapController_RotateFront;
    private readonly InputAction m_MapController_RotateSide;
    private readonly InputAction m_MapController_CancelMapOperations;
    public struct MapControllerActions
    {
        private @InputControls m_Wrapper;
        public MapControllerActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_MapController_Select;
        public InputAction @MousePosition => m_Wrapper.m_MapController_MousePosition;
        public InputAction @Modifier_Shift => m_Wrapper.m_MapController_Modifier_Shift;
        public InputAction @MapObjectMovementEnded => m_Wrapper.m_MapController_MapObjectMovementEnded;
        public InputAction @MoveXY => m_Wrapper.m_MapController_MoveXY;
        public InputAction @MoveZ => m_Wrapper.m_MapController_MoveZ;
        public InputAction @RotateZ => m_Wrapper.m_MapController_RotateZ;
        public InputAction @RotateFront => m_Wrapper.m_MapController_RotateFront;
        public InputAction @RotateSide => m_Wrapper.m_MapController_RotateSide;
        public InputAction @CancelMapOperations => m_Wrapper.m_MapController_CancelMapOperations;
        public InputActionMap Get() { return m_Wrapper.m_MapController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapControllerActions set) { return set.Get(); }
        public void SetCallbacks(IMapControllerActions instance)
        {
            if (m_Wrapper.m_MapControllerActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnSelect;
                @MousePosition.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMousePosition;
                @Modifier_Shift.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnModifier_Shift;
                @Modifier_Shift.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnModifier_Shift;
                @Modifier_Shift.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnModifier_Shift;
                @MapObjectMovementEnded.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMapObjectMovementEnded;
                @MapObjectMovementEnded.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMapObjectMovementEnded;
                @MapObjectMovementEnded.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMapObjectMovementEnded;
                @MoveXY.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMoveXY;
                @MoveXY.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMoveXY;
                @MoveXY.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMoveXY;
                @MoveZ.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMoveZ;
                @MoveZ.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMoveZ;
                @MoveZ.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnMoveZ;
                @RotateZ.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateZ;
                @RotateZ.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateZ;
                @RotateZ.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateZ;
                @RotateFront.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateFront;
                @RotateFront.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateFront;
                @RotateFront.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateFront;
                @RotateSide.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateSide;
                @RotateSide.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateSide;
                @RotateSide.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnRotateSide;
                @CancelMapOperations.started -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnCancelMapOperations;
                @CancelMapOperations.performed -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnCancelMapOperations;
                @CancelMapOperations.canceled -= m_Wrapper.m_MapControllerActionsCallbackInterface.OnCancelMapOperations;
            }
            m_Wrapper.m_MapControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Modifier_Shift.started += instance.OnModifier_Shift;
                @Modifier_Shift.performed += instance.OnModifier_Shift;
                @Modifier_Shift.canceled += instance.OnModifier_Shift;
                @MapObjectMovementEnded.started += instance.OnMapObjectMovementEnded;
                @MapObjectMovementEnded.performed += instance.OnMapObjectMovementEnded;
                @MapObjectMovementEnded.canceled += instance.OnMapObjectMovementEnded;
                @MoveXY.started += instance.OnMoveXY;
                @MoveXY.performed += instance.OnMoveXY;
                @MoveXY.canceled += instance.OnMoveXY;
                @MoveZ.started += instance.OnMoveZ;
                @MoveZ.performed += instance.OnMoveZ;
                @MoveZ.canceled += instance.OnMoveZ;
                @RotateZ.started += instance.OnRotateZ;
                @RotateZ.performed += instance.OnRotateZ;
                @RotateZ.canceled += instance.OnRotateZ;
                @RotateFront.started += instance.OnRotateFront;
                @RotateFront.performed += instance.OnRotateFront;
                @RotateFront.canceled += instance.OnRotateFront;
                @RotateSide.started += instance.OnRotateSide;
                @RotateSide.performed += instance.OnRotateSide;
                @RotateSide.canceled += instance.OnRotateSide;
                @CancelMapOperations.started += instance.OnCancelMapOperations;
                @CancelMapOperations.performed += instance.OnCancelMapOperations;
                @CancelMapOperations.canceled += instance.OnCancelMapOperations;
            }
        }
    }
    public MapControllerActions @MapController => new MapControllerActions(this);

    // Interface
    private readonly InputActionMap m_Interface;
    private IInterfaceActions m_InterfaceActionsCallbackInterface;
    private readonly InputAction m_Interface_MousePosition;
    public struct InterfaceActions
    {
        private @InputControls m_Wrapper;
        public InterfaceActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Interface_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Interface; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InterfaceActions set) { return set.Get(); }
        public void SetCallbacks(IInterfaceActions instance)
        {
            if (m_Wrapper.m_InterfaceActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_InterfaceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public InterfaceActions @Interface => new InterfaceActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard-Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface ICameraActions
    {
        void OnPan(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotateVertical(InputAction.CallbackContext context);
        void OnRotateFront(InputAction.CallbackContext context);
        void OnLookAt(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnSlowCameraModifier(InputAction.CallbackContext context);
        void OnFastCameraModifier(InputAction.CallbackContext context);
    }
    public interface IMapControllerActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnModifier_Shift(InputAction.CallbackContext context);
        void OnMapObjectMovementEnded(InputAction.CallbackContext context);
        void OnMoveXY(InputAction.CallbackContext context);
        void OnMoveZ(InputAction.CallbackContext context);
        void OnRotateZ(InputAction.CallbackContext context);
        void OnRotateFront(InputAction.CallbackContext context);
        void OnRotateSide(InputAction.CallbackContext context);
        void OnCancelMapOperations(InputAction.CallbackContext context);
    }
    public interface IInterfaceActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
