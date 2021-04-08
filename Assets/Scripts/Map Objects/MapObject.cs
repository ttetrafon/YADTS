using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// The MapObject class is the parent for all map objects that are used when creating maps, from the terrain, to creatures, to vehicles, and to effects.
/// </summary>
public class MapObject: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	[Header("General")]
	public bool hasChanged = false; // Boolean to control if the objet will be resaved with the map.
	public bool isSelected = false; // Boolean that remembers if the object is selected.
	public bool isNameDisplayed = false; // Boolean to control the name visibility of a map object.
	public float distanceFromCamera = 0.0f;
	public List<string> tags = new List<string>(); // Quick selection of map objects and filtering within the new map object menu.

	[Header("References")]
	public GameObject modelNormal; // The normal model, visible by eyes in the typical spectrum.
	public TextMesh floatingName = null; // Reference to the in-game 3D floating text that holds the map object's name.
	public Text mapReferenceSelector = null; // Connects the map object with its selector in the current map panel.
	public GameObject initiativeSelector = null; // Connects the map object with its selector in the initiate panel.

	[Header("Data")]
	public MapObjectData mapObjectData = new MapObjectData();

	private void Awake() {
		// Get and display the object's name.
		if ((mapObjectData.objectName == "NaN") || (mapObjectData.objectName == "")) {
			mapObjectData.objectName = this.gameObject.name;
			if (floatingName != null) {
				floatingName.text = mapObjectData.objectName;
				floatingName.gameObject.SetActive(isNameDisplayed);
			}
		}
	}

	private void Update() {
		if (isNameDisplayed) {
			distanceFromCamera = Vector3.Distance(GameController.activeCamera.gameObject.transform.position, this.transform.position);
			// Control the Floating Text's orientation so that it faces the camera at all times, and its size based on camera distance.
			if (floatingName != null) { // Test so that if the floatingName is not assigned errors won't happen, since names will usually added only to important objects (like creatures or cities on a map).
				if (distanceFromCamera > 50) { // TODO: Make this number a setting.
					// hide the name if the camera if too far away
					floatingName.gameObject.SetActive(false);
				}
				else {
					if (!floatingName.gameObject.activeSelf) floatingName.gameObject.SetActive(true);
					// Face Direction
					floatingName.transform.LookAt(Camera.main.transform.position);
					floatingName.transform.Rotate(0, 180, 0);
					// Text Size
					floatingName.characterSize = adaptCharacterSize(distanceFromCamera);
				}
			}
		}
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData pd) {
        // Debug.Log("IPointerEnterHandler.OnPointerEnter: " + mapObjectData.objectName);
		TooltipController.ShowMoTooltip(mapObjectData.objectName);
    }

	void IPointerExitHandler.OnPointerExit(PointerEventData pd) {
        // Debug.Log("IPointerExitHandler.OnPointerExit: " + mapObjectData.objectName);
		TooltipController.HideMoTooltip();
    }

	private float adaptCharacterSize(float distance) {
		if (distance < 3) {
			return 0.1f;
		}
		else if (distance > 30) {
			return 0.3f;
		}
		else {
			return ((0.2f * distance) + 2.1f)/27;
		}
	}

	public void UpdateSpacialData(GameObject go) {
		// rotation: (eulerAngles.y, localEulerAngles.x, localEulerAngles.z)
		MapObjectSpacialData spacialData = new MapObjectSpacialData();
		spacialData.positionX = go.transform.position.x;
		spacialData.positionY = go.transform.position.y;
		spacialData.positionZ = go.transform.position.z;
		spacialData.zRotation= go.transform.eulerAngles.y;
		spacialData.frontPan = go.transform.localEulerAngles.x;
		spacialData.sidePan = go.transform.localEulerAngles.z;
		spacialData.scaleX = go.transform.localScale.x;
		spacialData.scaleY = go.transform.localScale.y;
		spacialData.scaleZ = go.transform.localScale.z;
		if (mapObjectData.spacialData.ContainsKey(MapController.currentMapData.mapUid)) {
			mapObjectData.spacialData[MapController.currentMapData.mapUid] = spacialData;
		}
		else {
			mapObjectData.spacialData.Add(MapController.currentMapData.mapUid, spacialData);
		}
	}

	public void SetSpacialData(MapObjectSpacialData sd) {
		gameObject.transform.position = new Vector3(sd.positionX, sd.positionY, sd.positionZ);
		gameObject.transform.Rotate(new Vector3(0, sd.zRotation, 0), Space.World);
		gameObject.transform.Rotate(new Vector3(sd.frontPan, 0, sd.sidePan), Space.Self);
		gameObject.transform.localScale = new Vector3(sd.scaleX, sd.scaleY, sd.scaleZ);
		// Invert the floating name's scale to keep all of them consistent.
		floatingName.gameObject.transform.localScale = new Vector3(
			(sd.scaleX != 0 ? 1 / sd.scaleX: 1),
			(sd.scaleY != 0 ? 1 / sd.scaleY : 1),
			(sd.scaleZ != 0 ? 1 / sd.scaleZ : 1)
		);
		// floatingName.gameObject.transform.position = new Vector3( // FIXME: Use the model's bounding box to calculate the floating text's position.
		// 	floatingName.gameObject.transform.position.x,
		// 	2.2f * (floatingName.gameObject.transform.position.y / sd.scaleY),
		// 	floatingName.gameObject.transform.position.z
		// );
	}

	public void ToggleSelection(int active = 0) {
		isSelected = (active == Constants.gameObjectActiveNoOverride ? !isSelected : (active == Constants.gameObjectActiveOverrideTrue));
		isNameDisplayed = isSelected;
		floatingName.gameObject.SetActive(isSelected);
	}

	public void RenameSelf(string newName) {
		Debug.Log("---> RenameSelf(" + newName + ")");

	}

}
