using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData {
	public string mapName = "Not Set";
	public string mapUid = "00000000-0000-0000-0000-000000000000";
	public Dictionary<int, MapInfoItemData> mapInfoItems = new Dictionary<int, MapInfoItemData>();
	public Dictionary<string, int> axioms = new Dictionary<string, int>() {
		{"Magic", -1},
		{"Social", -1},
		{"Spirit", -1},
		{"Tech", -1},
	};
	public string mapType = "Plane of Existence";
	public List<string> mapObjectsInMap = new List<string>();
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

	public void AddMapObjectInMap(string uid) {
		if (!mapObjectsInMap.Contains(uid)) {
			mapObjectsInMap.Add(uid);
		}
		else {
			Debug.LogError("Map Object " + uid + " is already in the map.");
		}
	}
	public void RemoveMapObjectInMap(string uid) {
		if (mapObjectsInMap.Contains(uid)) {
			mapObjectsInMap.Remove(uid);
		}
		else {
			Debug.LogError("Map Object " + uid + " is not in the map.");
		}
	}

}
