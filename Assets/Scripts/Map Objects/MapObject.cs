using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The MapObject class is the parent for all map objects that are used when creating maps, from the terrain, to creatures, to vehicles, and to effects.
/// </summary>
// public class MapObject: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
public class MapObject: MonoBehaviour {
	[Header("General")]
	public bool hasChanged = false; // Boolean to control if the objet will be resaved with the map.
	public bool isSelected = false; // Boolean that remembers if the object is selected.
	public List<string> tags = new List<string>(); // Quick selection of map objects and filtering within the new map object menu.

	[Header("References")]
	public GameObject modelNormal; // The normal model, visible by eyes in the typical spectrum.
	public GameObject selectionSphere; // The sphere that highlights an object when it is selected.
	public Text mapReferenceSelector = null; // Connects the map object with its selector in the current map panel.
	public GameObject initiativeSelector = null; // Connects the map object with its selector in the initiate panel.

	[Header("Data")]
	public MapObjectData mapObjectData = new MapObjectData();

	private void Awake() {

	}

	private void Update() {

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
		if (mapObjectData.spatialData.ContainsKey(MapController.currentMapData.mapUid)) {
			mapObjectData.spatialData[MapController.currentMapData.mapUid] = spacialData;
		}
		else {
			mapObjectData.spatialData.Add(MapController.currentMapData.mapUid, spacialData);
		}
	}

	public void SetSpacialData(MapObjectSpacialData sd) {
		gameObject.transform.position = new Vector3(sd.positionX, sd.positionY, sd.positionZ);
		gameObject.transform.Rotate(new Vector3(0, sd.zRotation, 0), Space.World);
		gameObject.transform.Rotate(new Vector3(sd.frontPan, 0, sd.sidePan), Space.Self);
		gameObject.transform.localScale = new Vector3(sd.scaleX, sd.scaleY, sd.scaleZ);
	}

	public void ToggleSelection(int active = 0) {
		isSelected = (active == Constants.gameObjectActiveNoOverride ? !isSelected : (active == Constants.gameObjectActiveOverrideTrue));
	}

	public void RenameSelf(string newName) {
		Debug.Log("---> RenameSelf(" + newName + ")");
		// change the name in map object data
		this.mapObjectData.objectName = newName;
		// change the name in the dictionary
		GameController.dictionaries.NameUpdate(this.mapObjectData.objectUuid, newName);
		// update names in selector references
		if (mapReferenceSelector) {
			// mapReferenceSelector.Rename();
		}
		if (initiativeSelector) {
			// initiativeSelector.Rename();
		}
		// update the file on disk
		Helper.SaveMapObject(this);
	}

	public void DeleteSelf() {
		// Remove from the current map's list of map objects.
		MapController.currentMapData.RemoveMapObjectInMap(mapObjectData.objectUuid);
		// Remove the location for the current map.
		mapObjectData.RemovedFromMap(MapController.currentMapData.mapUid);
		// Check if it is the last instance and, if not a creature or vehicle, remove the file itself and the names dictionary entry.
		if (mapObjectData.isLastInstace() && !mapObjectData.isCreatureOrVehicle()) {
			GameController.dictionaries.NameRemove(mapObjectData.objectUuid);
			string filename = MapController.mapObjectsDirectory + mapObjectData.objectUuid + ".json";
			if (File.Exists(filename)) {
				File.Delete(filename);
			}
			else {
				Debug.LogError(filename + " not found and was not removed...");
			}
		}
		// Remove the map object's references
		// ... map selector
		mapReferenceSelector = null;
		// ... initiative selector
		initiativeSelector = null;
		// ... and finally gameobject
		Destroy(this.gameObject);
	}

}
