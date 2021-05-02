using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour {
  public static Controls controls;
  public static float fastCameraMultiplier = 25.0f; // TODO: Make user changeable property.
  public static float slowCameraMultiplier = 0.25f; // TODO: Make user changeable property.

  // Operational
  private String hoveringOverMo = null;
  private IEnumerator moMovementCoroutine = null;

  // Camera
  public static Vector2 camPan = Vector2.zero;
  public static float camMove = 0;
  public static float camFrontPan = 0;
  public static float camTopRotate = 0;
  public static Vector2 camMouseLook = Vector2.zero;

  // Map Objects
  public static bool moMoveXY = false;
	public static bool moMoveZ = false;
	// public static float moRotateZ = 0;
	// public static float moRotateFront = 0;
	// public static float moRotateSide = 0;
  public static float slowMovementModifier = 0.25f;
	public static float xyMovementSensitivity = 0.5f;
	public static float zMovementSensitivity = 0.5f;


  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
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
    controls.MapMode.Delete.performed += ctx => MapController.DeleteSelectedMapObjects();
    controls.MapMode.MapObjectMoveXY.performed += ctx => moMoveXY = true;
    controls.MapMode.MapObjectMoveXY.canceled += ctx => {
      moMoveXY = false;
      if (moMovementCoroutine == null) {
        moMovementCoroutine = MapObjectSpatialControlReleasedLoop();
      }
    };
    controls.MapMode.MapObjectMoveZ.performed += ctx => moMoveZ = true;
    controls.MapMode.MapObjectMoveZ.canceled += ctx => {
      moMoveZ = false;
      if (moMovementCoroutine == null) {
        moMovementCoroutine = MapObjectSpatialControlReleasedLoop();
      }
    };
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
    if (controls.MapMode.enabled && !Helper.isMouseOverUI()) {
      Ray ray = GameController.activeCamera.gameObject.GetComponent<Camera>().ScreenPointToRay(controls.Common.MousePosition.ReadValue<Vector2>());
			// Debug.Log(ray);
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo)) {
        // Debug.Log("Mouse over: " + hitInfo.transform.gameObject.name);
        MapObject mo = hitInfo.transform.gameObject.GetComponent<MapObject>();
        if ((this.hoveringOverMo == null) || (this.hoveringOverMo != mo.mapObjectData.objectUuid)) {
          this.hoveringOverMo = mo.mapObjectData.objectUuid;
          TooltipController.ShowMoTooltip(mo.mapObjectData.objectName);
        }
			}
      else {
        this.hoveringOverMo = null;
        TooltipController.HideMoTooltip();
      }
      if (controls.MapMode.MapObjectMoveXY.ReadValue<float>() > 0) {
        Debug.Log("... pressing x!");
      }
    }
  }


  ////////////////////
  ///   CONTROLS   ///
  ////////////////////
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
    if (controls.MapMode.MiddleMouse.ReadValue<float>() > 0) {
      camPan = delta;
    }
    else if (controls.MapMode.RightMouse.ReadValue<float>() > 0) {
      camMouseLook = 2.5f * delta;
    }
    else {
      camPan = Vector2.zero;
      camMouseLook = Vector2.zero;
    }
  }


  ////////////////////
  ///   MAP MODE   ///
  ////////////////////
	private void MapClick() {
		// Debug.Log("---> Map Click()");
    // Ignore the hits if we are over a UI element.
    if (Helper.isMouseOverUI()) {
      // Debug.Log("Over UI!!!");
      return;
    }

    // Use multiple targets to cycle the selection between the visible and hidden map objects.
    Ray ray = GameController.activeCamera.gameObject.GetComponent<Camera>().ScreenPointToRay(controls.Common.MousePosition.ReadValue<Vector2>());
    var layerMask = ~0;
    RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, layerMask);
    // Debug.Log(hits.Length + " object(s) hit!");
    if (hits.Length > 0) {
      Array.Sort(hits, delegate(RaycastHit hit1, RaycastHit hit2) { return hit1.distance.CompareTo(hit2.distance); } );
      MapObject mo = hits[0].transform.gameObject.GetComponent<MapObject>();
      // control selection based on Shift pressed
      if (controls.Common.FastModifier.ReadValue<float>() > 0) {
        mo.ToggleSelection();
        MapController.ToggleMapObjectInSelection(mo);
      }
      else {
        MapController.UnseslectAllMapObjects();
        mo.ToggleSelection();
        MapController.ToggleMapObjectInSelection(mo);
      }
    }
    else {
      MapController.UnseslectAllMapObjects();
      MainMenu.CloseMenus();
    }
  }

  private IEnumerator MapObjectSpatialControlReleasedLoop() {
    for (int i = 0; i < MapController.currentlySelectedObjects.Count; i++) {
      MapController.MapObjectMovementEnded(MapController.currentlySelectedObjects[i]);
    }
    yield return null;
  }


  /////////////////////
  ///   GAME MODE   ///
  /////////////////////

}
