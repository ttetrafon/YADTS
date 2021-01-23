using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour {
  public static CameraControl thisCamera;
  public static bool cameraBlock = false; // This should be set to 'true' when the mouse is over panels, so that the camera is not moved when it should not be affected.

  // Camera Controls
  InputControls cameraControls;
  public float cameraSpeed = 10.0f; // TODO: Make user changeable property.
  public float cameraSensitivity = 20.0f; // TODO: Make user changeable property.
  public float cameraMouseLookSensitivity = 0.3f; // TODO: Make user changeable property.
  public static float fastCameraMultiplier = 25.0f; // TODO: Make user changeable property.
  public static float slowCameraMultiplier = 0.25f; // TODO: Make user changeable property.
  Vector3 camVelocity = Vector3.zero;
  Vector2 camPan = Vector2.zero;
  Vector2 camMouseLook = Vector2.zero;
  float camMove = 0;
  float camFrontPan = 0;
  float camTopRotate = 0;

	private void Awake() {
    if (!thisCamera) {
      thisCamera = this;
    }
    cameraControls = new InputControls();
    cameraControls.Camera.Pan.performed += ctx => camPan = (-1) * ctx.ReadValue<Vector2>();
    cameraControls.Camera.Pan.canceled += ctx => camPan = Vector2.zero;
    cameraControls.Camera.Move.performed += ctx => camMove = ctx.ReadValue<float>();
    cameraControls.Camera.Move.canceled += ctx => camMove = 0.0f;
    cameraControls.Camera.RotateFront.performed += ctx => camFrontPan = ctx.ReadValue<float>();
    cameraControls.Camera.RotateFront.canceled += ctx => camFrontPan = 0;
    cameraControls.Camera.RotateVertical.performed += ctx => camTopRotate = ctx.ReadValue<float>();
    cameraControls.Camera.RotateVertical.canceled += ctx => camTopRotate = 0;
    cameraControls.Camera.MouseLook.performed += ctx => camMouseLook = cameraMouseLookSensitivity * ctx.ReadValue<Vector2>();
    cameraControls.Camera.MouseLook.canceled += ctx => camMouseLook = Vector2.zero;
    cameraControls.Camera.LookAt.performed += ctx => CameraFocusOn();
  }

  private void OnEnable() {
    cameraControls.Camera.Enable();
  }

  private void OnDisable() {
    cameraControls.Camera.Disable();
  }

  private void OnPan(InputValue movementValue) {
    Debug.Log("---> OnPan()");
	  Vector2 movementVector = movementValue.Get<Vector2>();
  }

  private void Update() {
    if (!Helper.isUIActive() && !cameraBlock) {
      float modifier = CameraSpeedModifier();
      thisCamera.transform.Translate((camMove * Vector3.forward + camPan.x * Vector3.right + camPan.y * Vector3.up) * cameraSpeed * Time.deltaTime * modifier);
      thisCamera.transform.Rotate(new Vector3(camFrontPan - camMouseLook.y, 0, 0) * cameraSensitivity * Time.deltaTime * modifier, Space.Self);
      thisCamera.transform.Rotate(new Vector3(0, camTopRotate + camMouseLook.x, 0) * cameraSensitivity * Time.deltaTime * modifier, Space.World);
    }
  }

  private float CameraSpeedModifier() {
    if (cameraControls.Camera.SlowCameraModifier.ReadValue<float>() > 0) {
      return slowCameraMultiplier;
    }
    else if (cameraControls.Camera.FastCameraModifier.ReadValue<float>() > 0) {
      return fastCameraMultiplier;
    }
    else {
      return 1.0f;
    }
  }

  public static void CameraFocusOn() {
    // TODO: Use Quaternions to smooth over the rotation.
    thisCamera.transform.LookAt(SpatialDataController.selectedMoPositions);
   return;
  }


}
