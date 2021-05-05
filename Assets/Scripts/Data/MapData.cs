using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData {
	public string mapName = "Not Set";
	public string mapUid = "00000000-0000-0000-0000-000000000000";
	public Dictionary<int, MapInfoItemData> mapInfoItems = new Dictionary<int, MapInfoItemData>();
	public string mapType = "Plane of Existence";

	public Dictionary<string, List<string>> mapObjectsInMap = new Dictionary<string, List<string>>() {
		{"effect", new List<string>()},
		{"creature", new List<string>()},
		{"vehicle", new List<string>()},
		{"item", new List<string>()},
		{"terrain", new List<string>()}
	};
	public string gridType = Constants.gridTypeNone;
	public int rotationStepVertical = 0;
	public int rotationStepFront = 0;
	public int rotationStepSide = 0;

	public MapData() {
		this.mapUid = Helper.GenerateUid();
	}
	public MapData (String mapUid) {
		this.mapUid = mapUid;
	}

	public void AddMapObjectInMap(string uid, string type) {
		Debug.Log("---> AddMapObjectInMap(" + uid + ", " + type + ")");
		if (!mapObjectsInMap[type].Contains(uid)) {
			mapObjectsInMap[type].Add(uid);
		}
		else {
			Debug.LogError("Map Object '" + type + "/" + uid + "' is already in the map.");
		}
	}
	public void RemoveMapObjectInMap(string uid, string type) {
		Debug.Log("---> RemoveMapObjectInMap(" + uid + ", " + type + ")");
		if (mapObjectsInMap[type].Contains(uid)) {
			mapObjectsInMap[type].Remove(uid);
		}
		else {
			Debug.LogError("Map Object '" + type + "/" + uid + "' is not in the map.");
		}
	}

}
