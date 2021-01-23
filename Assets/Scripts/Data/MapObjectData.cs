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
	public string description = "";
	// Spatial Data
	public Dictionary<string, MapObjectSpacialData> spacialData = new Dictionary<string, MapObjectSpacialData>();
	// Map Object Parent(s)
	public bool isInGroup = false; // Boolean that remembers if the object is part of a group.
	// Map Object Children Group
	public List<string> mapObjectChildrenGroup = new List<string>();
	public bool isContainer = false; // Boolean to remember if the the item contains other map objects
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
		return "spatial data: (" + positionX + ", " + positionY + ", " + positionZ
			+ ") - (" + zRotation + ", " + frontPan + ", " + sidePan
			+ ") - (" + scaleX + ", " + scaleY + ", " + scaleZ + ")";
	}
}
