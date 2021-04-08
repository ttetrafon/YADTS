using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour {
  public static Controls controls;
  public static float fastCameraMultiplier = 25.0f; // TODO: Make user changeable property.
  public static float slowCameraMultiplier = 0.25f; // TODO: Make user changeable property.

  // Camera
  public static Vector2 camPan = Vector2.zero;
  public static float camMove = 0;
  public static float camFrontPan = 0;
  public static float camTopRotate = 0;
  public static Vector2 camMouseLook = Vector2.zero;

  // Map Objects
  public static Vector2 moMoveXY = Vector2.zero;
	public static float moMoveZ = 0;
	public static float moRotateZ = 0;
	public static float moRotateFront = 0;
	public static float moRotateSide = 0;

  private void Awake() {
    controls = new Controls();
    controls.Common.MouseDelta.performed += ctx => MouseDelta(ctx.ReadValue<Vector2>());
    controls.MapMode.Click.performed += ctx => MapClick();
    controls.MapMode.Pan.performed += ctx => camPan = ctx.ReadValue<Vector2>();
    controls.MapMode.Pan.canceled += ctx => camPan = Vector2.zero;
    controls.MapMode.Move.performed += ctx => camMove = ctx.ReadValue<float>();
    controls.MapMode.Move.canceled += ctx => camMove = 0.0f;
    controls.MapMode.PanFront.performed += ctx => camFrontPan = ctx.ReadValue<float>();
    controls.MapMode.PanFront.canceled += ctx => camFrontPan = 0;
    controls.MapMode.RotateZ.performed += ctx => camTopRotate = ctx.ReadValue<float>();
    controls.MapMode.RotateZ.canceled += ctx => camTopRotate = 0;
    controls.MapMode.LookAt.performed += ctx => CameraControl.CameraFocusOn();
  }

  private void OnEnable() {
    controls.Common.Enable();
    controls.MapMode.Enable();
  }

  private void OnDisable() {
    controls.Common.Disable();
    controls.MapMode.Disable();
  }

  private void Update() {
    // Custom implementation of camera's raycast (purpose is to replicate IPointer functionality that suits this program - IPointer always stops on the first hit).
    if (controls.MapMode.enabled) {
      Ray ray = GameController.activeCamera.gameObject.GetComponent<Camera>().ScreenPointToRay(controls.Common.MousePosition.ReadValue<Vector2>());
      RaycastHit[] hitInfo = new RaycastHit[100];
      var layerMask = ~0;
      int hits = Physics.RaycastNonAlloc(ray, hitInfo, Mathf.Infinity, layerMask);
      if (hits > 0) {
        Debug.Log(hits + " object(s) hit!");
      }
    }
  }

  public static void SwitchControlsMode(string mode) {
    // Debug.Log("---> SwitchControlsMode(" + mode + ")");
    switch(mode) {
      case "MapMode":
        // Debug.Log("... switching controls to MapMode!");
        controls.MapMode.Enable();
        controls.UI.Disable();
        break;
      case "UI":
        // Debug.Log("... switching controls to UI!");
        controls.UI.Enable();
        controls.MapMode.Disable();
        break;
    }
  }

  public static float CameraSpeedModifier() {
    // Returns the modifier for camera speed, based on input.
    if (controls.Common.SlowModifier.ReadValue<float>() > 0) {
      return slowCameraMultiplier;
    }
    else if (controls.Common.FastModifier.ReadValue<float>() > 0) {
      return fastCameraMultiplier;
    }
    else {
      return 1.0f;
    }
  }

  private void MouseDelta(Vector2 delta) {
    if (Helper.isUIActive()) {
      return;
    }
    if (controls.Common.MiddleMouse.ReadValue<float>() > 0) {
      camPan = delta;
    }
    else if (controls.Common.RightMouse.ReadValue<float>() > 0) {
      camMouseLook = 2.5f * delta;
    }
    else {
      camPan = Vector2.zero;
      camMouseLook = Vector2.zero;
    }
  }

	private void MapClick() {
		// Debug.Log("---> Map Click()");
		if (!EventSystem.current.IsPointerOverGameObject()) {
			// Debug.Log("... not over GUI!");
			Ray ray = GameController.activeCamera.gameObject.GetComponent<Camera>().ScreenPointToRay(controls.Common.MousePosition.ReadValue<Vector2>());
			// Debug.Log(ray);
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo)) {
			// 	MapObjectClicked(hitInfo.transform.parent.gameObject.GetComponent<MapObject>());
			}
			else {
			// 	UnseslectAllMapObjects();
			}
			// No target and no tool
			// if (distanceMeasurementStep == 0) {
			// 	MainMenu.CloseMenus();
			// }
    	// Activate the Spatial Data Panel if objects are selected.
			// if (currentlySelectedObjects.Count > 0) {
			// 	moSpatialDataPanel.SetActive(true);
			// 	SpatialDataController.PopulateSpatialData();
			// }
			// else {
			// 	SpatialDataController.CancelRename();
			// 	moSpatialDataPanel.SetActive(false);
			// }
		}
	}

}
