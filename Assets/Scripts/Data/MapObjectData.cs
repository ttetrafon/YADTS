using System;
using System.Collections.Generic;

[Serializable]
public class MapObjectData {
	// Names
	public string objectName = "NaN"; // The name for the object that will appear ingame.
	public string objectType = "NaN"; // The type (effect, creature, item, vehicle, terrain) of the object.
	// Ids
	public string objectUuid = "";
	public string prefabName = "";
	// General Data
	public string owner = "GM";
	public string description = "";
	public List<string> materials = new List<string>();
	// Spatial Data
	public Dictionary<string, MapObjectSpacialData> spatialData = new Dictionary<string, MapObjectSpacialData>(); // Spatial data of mo for each map (based on uid).
	// Map Object Parent(s)
	public bool isInGroup = false; // Boolean that remembers if the object is part of a group.
	// Map Object Children Group
	public List<string> mapObjectChildrenGroup = new List<string>();
	public bool isContainer = false; // Boolean to remember if the the item contains other map objects.


	///////////////////
	///   METHODS   ///
	///////////////////
	public bool isCreatureOrVehicle() {
		return (objectType == "creature") || (objectType == "vehicle");
	}

	public bool isLastInstace() {
		return spatialData.Keys.Count == 0;
	}

	public void RemovedFromMap(string mapUid) {
		if (spatialData.ContainsKey(mapUid)) {
			spatialData.Remove(mapUid);
		}
	}

}

public class MapObjectSpacialData {
	public float positionX = 0;
	public float positionY = 0;
	public float positionZ = 0;
	public float zRotation = 0;
	public float frontPan = 0;
	public float sidePan = 0;
	public float scaleX = 1;
	public float scaleY = 1;
	public float scaleZ = 1;

	public override string ToString() {
		return "spatial data: position (" + positionX + ", " + positionY + ", " + positionZ
			+ "), rotation (" + zRotation + ", " + frontPan + ", " + sidePan
			+ "), scale (" + scaleX + ", " + scaleY + ", " + scaleZ + ")";
	}
}
