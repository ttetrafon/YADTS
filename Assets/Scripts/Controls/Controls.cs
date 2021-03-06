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
            ""name"": ""MapMode"",
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
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""7e4527b0-c9e0-42a9-9447-f00c74f1465e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleMouse"",
                    ""type"": ""Button"",
                    ""id"": ""cef914b5-34e6-4e03-a5af-036bfcfb6dfe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouse"",
                    ""type"": ""Button"",
                    ""id"": ""b11f6a7a-795c-48cb-b8a1-e074bc610c3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delete"",
                    ""type"": ""Button"",
                    ""id"": ""cbfcb78c-9e5e-4476-9bcc-f550b76c910b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapObjectMoveXY"",
                    ""type"": ""Button"",
                    ""id"": ""3389ebc4-58c1-4171-956f-8ed17542b155"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapObjectMoveZ"",
                    ""type"": ""Button"",
                    ""id"": ""f736825e-e5c7-4531-a130-09cab2d16562"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapObjectRotationZ"",
                    ""type"": ""Button"",
                    ""id"": ""128e2465-717f-46f6-85be-e1f0f56e1b69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapObjectRotationFront"",
                    ""type"": ""Button"",
                    ""id"": ""e776f485-cf25-43a5-a9c6-07e0d78ffca9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapObjectRotationSide"",
                    ""type"": ""Button"",
                    ""id"": ""660538b6-093e-4510-82f4-a7a5aa25d316"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapObjectScale"",
                    ""type"": ""Button"",
                    ""id"": ""ff81da2d-79b2-444d-ac9d-288a6a443250"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""53900bab-1640-49c4-aba3-604b1c5b6016"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19276792-e41e-4ff9-a3ca-47856b85b519"",
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
                    ""id"": ""450e481a-64c0-465d-a2e4-b31e78a6cf3c"",
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
                    ""id"": ""17281e94-4dd2-487e-912a-cef717f7c7ca"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Delete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22e030d1-f9ff-4ae9-accd-e85ec3dfa2b5"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MapObjectMoveXY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa6b574e-25eb-4e47-b1fd-7906cf3e61e6"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MapObjectMoveZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""159bbb9d-8373-4059-90d9-e62122a36ee1"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MapObjectRotationZ"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62850bfc-7e01-400b-9f19-7720e3cc57a3"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MapObjectRotationFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86c38588-ea5c-4723-aa91-87ade7a7eaaa"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MapObjectRotationSide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a107e040-cf44-4363-844b-113e192d9258"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MapObjectScale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""5b3bcfed-715a-401f-8e83-728443d8d8cc"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""5cd14584-9cf2-4583-be88-577dd18d6ab3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""f6e374d1-87a1-420d-94b4-72412dc271eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""4acaad13-f3e0-4218-a6ff-79f3004210c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7bacc9bb-3ec0-4ede-beb2-40fc4fc4ee63"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bd0a7077-b7b6-4fb9-ad54-b1297758de54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2090fb88-e2e7-43ca-b234-5953031a8675"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""326aa394-c9ff-458c-9c1e-eb0031d96f14"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1b24a8c0-95bd-4aa6-9b6f-0629379046ae"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""94565e0c-4289-48ef-ba2e-100ebcc8aa50"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0ff7931e-921a-420e-83be-e0b668ea9386"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""668820b6-c724-4f90-82de-041dd4f0c70e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6b42a190-2b14-437b-8bb0-150dbd124925"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d2923468-d378-4ba3-9697-7ff51c311fb2"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4db96e6d-d365-42ff-b83e-73f5dc443bdf"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bc9cf688-3380-436f-b8ee-4eaeeb428b8f"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cf67db94-9fce-46b6-b215-8d9de314adab"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ff21d062-0cc2-4b7d-8a50-2f23845cab15"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a6550222-9a1b-47cd-8467-cf151d44dafd"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f99a2f5c-9291-45d0-beec-ad3697ace583"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d0d652cb-31f9-4501-94a8-b7becc4b4e3a"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""fb72230a-9322-4098-a520-e7aac4d8d5ac"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a6b72de2-8b09-487c-9e27-d824b388ce1e"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8f9a3f87-8520-4d82-adaf-b87dd08c5b59"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7e741f08-1a6e-426a-bbf1-37263381a212"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a864ccb8-505d-47a6-9f98-337e07be6d7f"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""96aa979c-ede4-4432-a98d-15684514b4c4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""61fdb42e-0dd6-4728-a759-2739d820391a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4477e0e-fe45-4a7f-a078-79692dba86dd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4ab3b5b3-cd8b-46a0-bd46-855ac459a798"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0f4f130-1c3b-4358-8317-b7efe691f2e3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a370b1d1-0986-4abf-8faf-a99e1023003d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""983dec6a-efc0-4024-b1fa-2983f3cc4af0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0e119c0f-1ad3-4f16-b886-8145f520731e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f03134a1-860e-47e8-9316-2b83c10262a2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1c75b583-a552-4496-b269-91a441539574"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bfbcc28-ac56-46ed-81aa-a9889ff7a920"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7098fd52-88e6-46cb-886f-31c50f366c4c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99b74499-6ec9-4148-b767-aa0dd987357f"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1a5e4c6-96e2-4e14-ba0c-29b2236aa1f3"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb629de8-ef1d-403a-8435-f125db6b0860"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02d866fb-c9f5-4518-86a5-b0c8f24ce1cb"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""beb21e49-74ce-4731-aafd-e36564f7df2d"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecdf8310-8978-45ec-beb7-c749674e4303"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71f2ff01-85e5-403e-a7d5-26dfca08b034"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46911a43-a9f9-46aa-bf9e-8d1edaf8c618"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7810b0f-bb58-41cf-9381-b41a3b57aa33"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c2f63de-5f29-41c3-bf77-78616226fcb8"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24a492d0-59c9-43ec-8089-356ab7c9770b"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
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
        m_Common_FastModifier = m_Common.FindAction("FastModifier", throwIfNotFound: true);
        m_Common_SlowModifier = m_Common.FindAction("SlowModifier", throwIfNotFound: true);
        m_Common_MousePosition = m_Common.FindAction("MousePosition", throwIfNotFound: true);
        // MapMode
        m_MapMode = asset.FindActionMap("MapMode", throwIfNotFound: true);
        m_MapMode_Pan = m_MapMode.FindAction("Pan", throwIfNotFound: true);
        m_MapMode_Move = m_MapMode.FindAction("Move", throwIfNotFound: true);
        m_MapMode_RotateZ = m_MapMode.FindAction("RotateZ", throwIfNotFound: true);
        m_MapMode_PanFront = m_MapMode.FindAction("PanFront", throwIfNotFound: true);
        m_MapMode_LookAt = m_MapMode.FindAction("LookAt", throwIfNotFound: true);
        m_MapMode_Click = m_MapMode.FindAction("Click", throwIfNotFound: true);
        m_MapMode_MiddleMouse = m_MapMode.FindAction("MiddleMouse", throwIfNotFound: true);
        m_MapMode_RightMouse = m_MapMode.FindAction("RightMouse", throwIfNotFound: true);
        m_MapMode_Delete = m_MapMode.FindAction("Delete", throwIfNotFound: true);
        m_MapMode_MapObjectMoveXY = m_MapMode.FindAction("MapObjectMoveXY", throwIfNotFound: true);
        m_MapMode_MapObjectMoveZ = m_MapMode.FindAction("MapObjectMoveZ", throwIfNotFound: true);
        m_MapMode_MapObjectRotationZ = m_MapMode.FindAction("MapObjectRotationZ", throwIfNotFound: true);
        m_MapMode_MapObjectRotationFront = m_MapMode.FindAction("MapObjectRotationFront", throwIfNotFound: true);
        m_MapMode_MapObjectRotationSide = m_MapMode.FindAction("MapObjectRotationSide", throwIfNotFound: true);
        m_MapMode_MapObjectScale = m_MapMode.FindAction("MapObjectScale", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
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
    private readonly InputAction m_Common_FastModifier;
    private readonly InputAction m_Common_SlowModifier;
    private readonly InputAction m_Common_MousePosition;
    public struct CommonActions
    {
        private @Controls m_Wrapper;
        public CommonActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseDelta => m_Wrapper.m_Common_MouseDelta;
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

    // MapMode
    private readonly InputActionMap m_MapMode;
    private IMapModeActions m_MapModeActionsCallbackInterface;
    private readonly InputAction m_MapMode_Pan;
    private readonly InputAction m_MapMode_Move;
    private readonly InputAction m_MapMode_RotateZ;
    private readonly InputAction m_MapMode_PanFront;
    private readonly InputAction m_MapMode_LookAt;
    private readonly InputAction m_MapMode_Click;
    private readonly InputAction m_MapMode_MiddleMouse;
    private readonly InputAction m_MapMode_RightMouse;
    private readonly InputAction m_MapMode_Delete;
    private readonly InputAction m_MapMode_MapObjectMoveXY;
    private readonly InputAction m_MapMode_MapObjectMoveZ;
    private readonly InputAction m_MapMode_MapObjectRotationZ;
    private readonly InputAction m_MapMode_MapObjectRotationFront;
    private readonly InputAction m_MapMode_MapObjectRotationSide;
    private readonly InputAction m_MapMode_MapObjectScale;
    public struct MapModeActions
    {
        private @Controls m_Wrapper;
        public MapModeActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pan => m_Wrapper.m_MapMode_Pan;
        public InputAction @Move => m_Wrapper.m_MapMode_Move;
        public InputAction @RotateZ => m_Wrapper.m_MapMode_RotateZ;
        public InputAction @PanFront => m_Wrapper.m_MapMode_PanFront;
        public InputAction @LookAt => m_Wrapper.m_MapMode_LookAt;
        public InputAction @Click => m_Wrapper.m_MapMode_Click;
        public InputAction @MiddleMouse => m_Wrapper.m_MapMode_MiddleMouse;
        public InputAction @RightMouse => m_Wrapper.m_MapMode_RightMouse;
        public InputAction @Delete => m_Wrapper.m_MapMode_Delete;
        public InputAction @MapObjectMoveXY => m_Wrapper.m_MapMode_MapObjectMoveXY;
        public InputAction @MapObjectMoveZ => m_Wrapper.m_MapMode_MapObjectMoveZ;
        public InputAction @MapObjectRotationZ => m_Wrapper.m_MapMode_MapObjectRotationZ;
        public InputAction @MapObjectRotationFront => m_Wrapper.m_MapMode_MapObjectRotationFront;
        public InputAction @MapObjectRotationSide => m_Wrapper.m_MapMode_MapObjectRotationSide;
        public InputAction @MapObjectScale => m_Wrapper.m_MapMode_MapObjectScale;
        public InputActionMap Get() { return m_Wrapper.m_MapMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapModeActions set) { return set.Get(); }
        public void SetCallbacks(IMapModeActions instance)
        {
            if (m_Wrapper.m_MapModeActionsCallbackInterface != null)
            {
                @Pan.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnPan;
                @Pan.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnPan;
                @Pan.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnPan;
                @Move.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMove;
                @RotateZ.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnRotateZ;
                @RotateZ.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnRotateZ;
                @RotateZ.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnRotateZ;
                @PanFront.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnPanFront;
                @PanFront.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnPanFront;
                @PanFront.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnPanFront;
                @LookAt.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnLookAt;
                @LookAt.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnLookAt;
                @LookAt.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnLookAt;
                @Click.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnClick;
                @MiddleMouse.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMiddleMouse;
                @MiddleMouse.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMiddleMouse;
                @RightMouse.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnRightMouse;
                @RightMouse.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnRightMouse;
                @RightMouse.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnRightMouse;
                @Delete.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnDelete;
                @Delete.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnDelete;
                @Delete.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnDelete;
                @MapObjectMoveXY.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectMoveXY;
                @MapObjectMoveXY.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectMoveXY;
                @MapObjectMoveXY.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectMoveXY;
                @MapObjectMoveZ.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectMoveZ;
                @MapObjectMoveZ.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectMoveZ;
                @MapObjectMoveZ.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectMoveZ;
                @MapObjectRotationZ.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationZ;
                @MapObjectRotationZ.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationZ;
                @MapObjectRotationZ.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationZ;
                @MapObjectRotationFront.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationFront;
                @MapObjectRotationFront.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationFront;
                @MapObjectRotationFront.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationFront;
                @MapObjectRotationSide.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationSide;
                @MapObjectRotationSide.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationSide;
                @MapObjectRotationSide.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectRotationSide;
                @MapObjectScale.started -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectScale;
                @MapObjectScale.performed -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectScale;
                @MapObjectScale.canceled -= m_Wrapper.m_MapModeActionsCallbackInterface.OnMapObjectScale;
            }
            m_Wrapper.m_MapModeActionsCallbackInterface = instance;
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
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @MiddleMouse.started += instance.OnMiddleMouse;
                @MiddleMouse.performed += instance.OnMiddleMouse;
                @MiddleMouse.canceled += instance.OnMiddleMouse;
                @RightMouse.started += instance.OnRightMouse;
                @RightMouse.performed += instance.OnRightMouse;
                @RightMouse.canceled += instance.OnRightMouse;
                @Delete.started += instance.OnDelete;
                @Delete.performed += instance.OnDelete;
                @Delete.canceled += instance.OnDelete;
                @MapObjectMoveXY.started += instance.OnMapObjectMoveXY;
                @MapObjectMoveXY.performed += instance.OnMapObjectMoveXY;
                @MapObjectMoveXY.canceled += instance.OnMapObjectMoveXY;
                @MapObjectMoveZ.started += instance.OnMapObjectMoveZ;
                @MapObjectMoveZ.performed += instance.OnMapObjectMoveZ;
                @MapObjectMoveZ.canceled += instance.OnMapObjectMoveZ;
                @MapObjectRotationZ.started += instance.OnMapObjectRotationZ;
                @MapObjectRotationZ.performed += instance.OnMapObjectRotationZ;
                @MapObjectRotationZ.canceled += instance.OnMapObjectRotationZ;
                @MapObjectRotationFront.started += instance.OnMapObjectRotationFront;
                @MapObjectRotationFront.performed += instance.OnMapObjectRotationFront;
                @MapObjectRotationFront.canceled += instance.OnMapObjectRotationFront;
                @MapObjectRotationSide.started += instance.OnMapObjectRotationSide;
                @MapObjectRotationSide.performed += instance.OnMapObjectRotationSide;
                @MapObjectRotationSide.canceled += instance.OnMapObjectRotationSide;
                @MapObjectScale.started += instance.OnMapObjectScale;
                @MapObjectScale.performed += instance.OnMapObjectScale;
                @MapObjectScale.canceled += instance.OnMapObjectScale;
            }
        }
    }
    public MapModeActions @MapMode => new MapModeActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
        void OnFastModifier(InputAction.CallbackContext context);
        void OnSlowModifier(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IMapModeActions
    {
        void OnPan(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotateZ(InputAction.CallbackContext context);
        void OnPanFront(InputAction.CallbackContext context);
        void OnLookAt(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnMiddleMouse(InputAction.CallbackContext context);
        void OnRightMouse(InputAction.CallbackContext context);
        void OnDelete(InputAction.CallbackContext context);
        void OnMapObjectMoveXY(InputAction.CallbackContext context);
        void OnMapObjectMoveZ(InputAction.CallbackContext context);
        void OnMapObjectRotationZ(InputAction.CallbackContext context);
        void OnMapObjectRotationFront(InputAction.CallbackContext context);
        void OnMapObjectRotationSide(InputAction.CallbackContext context);
        void OnMapObjectScale(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
    }
}
