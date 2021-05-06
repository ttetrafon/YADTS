using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadMapScript : MonoBehaviour {
	public static LoadMapScript instance;
	[SerializeField] private Button loadMapButton;
	[SerializeField] private Dropdown mapSelectionDropdown;

	private void Awake() {
		// Debug.Log("LoadMapScript.Awake()");
		if (instance == null) {
			instance = this;
		}
	}

	private void Start() {
		// Add listeners
		loadMapButton.onClick.AddListener(delegate {
			string mapUid = Helper.ExtractUidFromDropdown(mapSelectionDropdown.options[mapSelectionDropdown.value].text);
			//Debug.Log("map to load: " + GameController.dictionaries.NameGet(mapUid) + " (" + mapUid + ")");
			LoadMap(mapUid);
		});
	}

	public static MapData GetMapData(string uid) {
		MapData loadedMapData = new MapData(uid);
		// Load the file
		string mapFilename = MapController.mapDirectory + uid + ".json";
		if (File.Exists(mapFilename)) {
			loadedMapData = (MapData)JsonObject.FromJson(loadedMapData, Helper.ReadFile(mapFilename));
		}
		else {
			Helper.SaveFile(mapFilename, JsonObject.ToJson(loadedMapData));
		}
		return loadedMapData;
	}


	public static void LoadMap(string uid) {
		// Debug.Log("---> LoadMap(" + uid + ")");
		// Clear previous map data
		MapController.UnseslectAllMapObjects();
		MapController.CleanMapObjects();
		// Load the map data
		MapData loadedMapData = GetMapData(uid);
		string mapName = GameController.dictionaries.NameGet(uid);
		MapController.currentMapData = loadedMapData;
		MainMenu.SetMapName(mapName);
		MapObjectMenuControls.SetMapConfigurationOptions();
		// Remember the map
		MapController.RememberLastMap(uid);
		// Close the menus, all went well up to this point
		MainMenu.CloseMenus();
		// Load map objects. (TODO: Do this in parallel if possible...)
		instance.StartCoroutine(instance.InstantiateMapObjects(loadedMapData.mapObjectsInMap));
	}

	private IEnumerator InstantiateMapObjects(Dictionary<string, List<string>> mos) {
		// Debug.Log("---> InstantiateMapObjects()");
		for (int j = 0; j < Localization.dropdowns["eng"]["Map Object Types"].Count; j++) {
			string type = Localization.dropdowns["eng"]["Map Object Types"][j];
			for (int i = 0; i < mos[type].Count; i++) {
				LoadMapObject(mos[type][i], type);
				yield return null;
			}
			yield return null;
		}
	}

	public static void LoadMapObject(string uid, string type) {
		//Debug.Log("---> LoadMap(" + uid + ")");
		MapObjectData mod = new MapObjectData();
		string filename = MapController.mapObjectsDirectory + type + "/" + uid + ".json";
		// Load map object data.
		if (File.Exists(filename)) {
			mod = (MapObjectData)JsonObject.FromJson(mod, Helper.ReadFile(filename));
		}
		else {
			Debug.LogWarning("Map Object " + filename + " could not be located.");
			return;
		}
		// Instantiate the map object and populate its properties.
		GameObject newGameObject;
		if (MapObjectMenuControls.mapObjectPrefabs.ContainsKey(mod.prefabName)) {
			newGameObject = Instantiate(MapObjectMenuControls.mapObjectPrefabs[mod.prefabName]);
		}
		else {
			Debug.LogWarning("Map Object based on prefab " + mod.prefabName + " cannot be instantiated. The prefab could not be found.");
			return;
		}
		newGameObject.name = mod.objectUuid;
		//Debug.Log("... spacial data: " + Helper.PrintDictionaryStringSpatialData(mod.spacialData));
		//Debug.Log("... current map: " + MapController.currentMapData.mapUid);
		MapObject loadedMapObject = newGameObject.GetComponent<MapObject>();
		if (mod.spatialData.ContainsKey(MapController.currentMapData.mapUid)) {
			//Debug.Log(mod.spacialData[MapController.currentMapData.mapUid].ToString());
			loadedMapObject.SetSpacialData(mod.spatialData[MapController.currentMapData.mapUid]);
		}
		loadedMapObject.mapObjectData = mod;
    loadedMapObject.InitialiseMaterials();
		MapController.mapObjects.Add(uid, loadedMapObject);
	}

}
