using System;
using System.Collections;
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
	public bool hasChanged = false; // Boolean to control if the objet will be re-saved with the map.
	public bool isSelected = false; // Boolean that remembers if the object is selected.
	public List<string> tags = new List<string>(); // Quick selection of map objects and filtering within the new map object menu.

	[Header("References")]
	public GameObject modelNormal; // The normal model, visible by eyes in the typical spectrum.
	private Material[] modelMaterials; // The names of the materials used by the model.
	public Text mapReferenceSelector = null; // Connects the map object with its selector in the current map panel.
	public GameObject initiativeSelector = null; // Connects the map object with its selector in the initiate panel.

	[Header("Data")]
	public MapObjectData mapObjectData = new MapObjectData();

	private void Start() {
		// get the materials!
		this.modelMaterials = this.modelNormal.GetComponent<MeshRenderer>().materials;
		// Debug.Log("materials found: " + this.modelMaterials.Length);
		// Debug.Log("materials saved: " + this.mapObjectData.materials.Count);
		if (this.mapObjectData.materials.Count == 0) {
			// Debug.Log("Save the materials, we didn't know about them!");
			// if they had not been saved yet (usually on first initiation), save their names
			for (int i = 0; i < this.modelMaterials.Length; i++) {
				String mat = this.modelMaterials[i].name;
				// Debug.Log("mat[" + i + "]: '" + mat.Substring(0, mat.IndexOf(" ")) + "'");
				this.mapObjectData.materials.Add(mat.Substring(0, mat.IndexOf(" "))); // TEST: substring may be a problem if (instance) is not appended to all materials!
			}
			// Debug.Log("materials to be saved: " + Helper.PrintStringList(this.mapObjectData.materials));
			// re-save the object so we remember the materials!
			Helper.SaveMapObject(this); // TEST: This may cause issues on first initiation!!
		}
		else {
			// if they are already saved, compare one by one and assign the proper materials as required
			// Debug.Log("materials already set");
			Boolean sameLength = this.modelMaterials.Length == this.mapObjectData.materials.Count;
			// ... take into account a possible missmatch of list lengths!
			if (sameLength) {
				// since we have the same number of materials, assign the proper ones to the map object based on what was saved
				for (int i = 0; i < this.modelMaterials.Length; i++) {
					String mat = this.modelMaterials[i].name;
					mat = mat.Substring(0, mat.IndexOf(" "));
					if (mat != this.mapObjectData.materials[i]) {
						// TODO: assign the proper material
						// ...
					}
				}
			}
			else {
				// ...
			}
		}
	}

	private void Update() {}

	public void UpdateSpacialData() {
		// rotation: (eulerAngles.y, localEulerAngles.x, localEulerAngles.z)
		MapObjectSpacialData spacialData = new MapObjectSpacialData();
		spacialData.positionX = this.gameObject.transform.position.x;
		spacialData.positionY = this.gameObject.transform.position.z;
		spacialData.positionZ = this.gameObject.transform.position.y;
		spacialData.zRotation= this.gameObject.transform.eulerAngles.y;
		spacialData.frontPan = this.gameObject.transform.localEulerAngles.x;
		spacialData.sidePan = this.gameObject.transform.localEulerAngles.z;
		spacialData.scaleX = this.gameObject.transform.localScale.x;
		spacialData.scaleY = this.gameObject.transform.localScale.y;
		spacialData.scaleZ = this.gameObject.transform.localScale.z;
		if (mapObjectData.spatialData.ContainsKey(MapController.currentMapData.mapUid)) {
			mapObjectData.spatialData[MapController.currentMapData.mapUid] = spacialData;
		}
		else {
			mapObjectData.spatialData.Add(MapController.currentMapData.mapUid, spacialData);
		}
	}

	public void SetSpacialData(MapObjectSpacialData sd) {
		gameObject.transform.position = new Vector3(sd.positionX, sd.positionZ, sd.positionY);
		gameObject.transform.Rotate(new Vector3(0, sd.zRotation, 0), Space.World);
		gameObject.transform.Rotate(new Vector3(sd.frontPan, 0, sd.sidePan), Space.Self);
		gameObject.transform.localScale = new Vector3(sd.scaleX, sd.scaleY, sd.scaleZ);
	}

	public void ToggleSelection(int active = 0) {
		this.isSelected = (active == Constants.gameObjectActiveNoOverride ? !isSelected : (active == Constants.gameObjectActiveOverrideTrue));
		StartCoroutine(HighlightSelf());
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

	public IEnumerator HighlightSelf() {
		// This method changes all materials of a map object's model to their highlighted version.
        // Debug.Log("---> HighlightSelf(" + this.mapObjectData.objectName + ", " + this.isSelected + ")");
		Material[] mats = this.modelNormal.GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < this.mapObjectData.materials.Count; i++) {
            string mat = this.mapObjectData.materials[i];
            // Debug.Log("mat: " + mat);
            if (Materials.materialsDictionary.ContainsKey(mat)) {
                // Debug.Log(Materials.materialsDictionary[mat][0].name);
                // Debug.Log(Materials.materialsDictionary[mat][1].name);
                // Debug.Log("... changing material from " + this.modelNormal.GetComponent<MeshRenderer>().materials[i].name + " to (" + (this.isSelected ? 1 : 0) + "): " + Materials.materialsDictionary[mat][(this.isSelected ? 1 : 0)].name);
				mats[i] = Materials.materialsDictionary[mat][(this.isSelected ? 1 : 0)];
            }
			yield return new WaitForSeconds(GeneralSettings.yieldLoop);
        }
		this.modelNormal.GetComponent<MeshRenderer>().materials = mats;
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
