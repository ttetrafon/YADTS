using UnityEngine;

public class CameraControl : MonoBehaviour {
  public static CameraControl thisCamera;
  public static bool cameraBlock = false; // This should be set to 'true' when the mouse is over panels, so that the camera is not moved when it should not be affected.

  // Camera Controls
  // Controls cameraControls;
  public float cameraSpeed = 10.0f; // TODO: Make user changeable property.
  public float cameraSensitivity = 20.0f; // TODO: Make user changeable property.
  public float cameraMouseLookSensitivity = 0.3f; // TODO: Make user changeable property.

	private void Awake() {
    // Debug.Log("CameraControl.Awake()");
    if (!thisCamera) {
      thisCamera = this;
    }
  }

  private void Update() {
    if (!Helper.isUIActive() && !cameraBlock) {
      float modifier = InputController.CameraSpeedModifier();
      thisCamera.transform.Translate((InputController.camMove * Vector3.forward + InputController.camPan.x * Vector3.right + InputController.camPan.y * Vector3.up) * cameraSpeed * Time.deltaTime * modifier);
      thisCamera.transform.Rotate(new Vector3(InputController.camFrontPan - InputController.camMouseLook.y, 0, 0) * cameraSensitivity * Time.deltaTime * modifier, Space.Self);
      thisCamera.transform.Rotate(new Vector3(0, InputController.camTopRotate + InputController.camMouseLook.x, 0) * cameraSensitivity * Time.deltaTime * modifier, Space.World);
    }
  }

  public static void CameraFocusOn() {
    thisCamera.transform.LookAt(SpatialDataController.selectedMoPositions);
    // TODO: Move closer to the target?
   return;
  }


}
