using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapController : MonoBehaviour {
	public static MapController instance = null;
	// General
	public static string rootMap = "MAP00000-TREE-ROOT-0000-000000000000";
	public static string rootMapFile;
	public static MapData currentMapData = new MapData(rootMap);
	public static string treeNodesDirectory;
	public static string mapDirectory;
	public static string mapObjectsDirectory;
	//public static string currentMap = rootMap;
	public static Dictionary<string, MapTreeNode> mapTree = new Dictionary<string, MapTreeNode>();
	[SerializeField] private Button mapInfoButton;

	// Map Objects
	[SerializeField] private Button mapObjectInfoButton;
	public static List<MapObject> currentlySelectedObjects = new List<MapObject>(); // Holds a list of all currently selected map objects.
	public static Dictionary<string, MapObject> mapObjects = new Dictionary<string, MapObject>();
	public GameObject moSpatialDataPanel;

	[Header("Map Tools")]
	[SerializeField] private Button distanceMeasurementButton;
	private int distanceMeasurementStep = 0;
	private MapObject[] distanceMeasurementObjects = new MapObject[2];


	/////////////////////
	///   LIFECYCLE   ///
	/////////////////////
	private void Awake() {
		//Debug.Log("===> MapController Awake");
		if (instance == null) {
			instance = this;
		}
		// Assign the references.
		treeNodesDirectory = GameController.saveFolder + "map tree hierarchy" + "/";
		//Debug.Log("treeNodesDirectory: " + treeNodesDirectory);
		mapDirectory = GameController.saveFolder + "maps" + "/";
		//Debug.Log("mapDirectory: " + mapDirectory);
		mapObjectsDirectory = GameController.saveFolder + "map objects" + "/";
		//Debug.Log("mapObjectsDirectory: " + mapObjectsDirectory);
	}

	private void Start() {
		//Debug.Log("===> MapController Start");
		// Set values.
		rootMapFile = treeNodesDirectory + rootMap + ".json";
		//Debug.Log("rootMapFile: " + rootMapFile);
		ConstructMapTree(rootMapFile);
		//Debug.Log("initial map: " + currentMapData.mapUid);

		// Add listeners.
		distanceMeasurementButton.onClick.AddListener(delegate {
			if (distanceMeasurementStep == 0) {
				GameController.ChangeCursor("distance");
				distanceMeasurementStep = 1;
			}
			else {
				GameController.ChangeCursor();
				distanceMeasurementStep = 0;
			}
		});
		mapInfoButton.onClick.AddListener(delegate {
			MainMenu.TogglePanel("MapInfo");
		});
		mapObjectInfoButton.onClick.AddListener(delegate {
			MainMenu.TogglePanel("MapObject");
		});

		// Finished Loading
		moSpatialDataPanel.SetActive(false);
		GameController.loadedMapController = true;
		PostLoad.FinishedInitialLoading();
	}

	private void Update() {
		if (!Helper.isUIActive()) {
			if (SpatialDataController.instance != null && SpatialDataController.instance.gameObject.activeSelf) {
				SpatialDataController.PopulateSpatialData();
			}
		}
	}

	// public static void MapObjectClicked(MapObject mo) {
		// Debug.Log("---> MapObjectClicked called from " + mo.mapObjectData.objectName);
		// Distance tool selected
		// if (instance.distanceMeasurementStep > 0) {
		// 	if (instance.distanceMeasurementStep == 1) {
		// 		instance.distanceMeasurementObjects[0] = mo;
		// 		instance.distanceMeasurementStep = 2;
		// 	}
		// 	else {
		// 		instance.distanceMeasurementObjects[1] = mo;
		// 		float distance = Vector3.Distance(instance.distanceMeasurementObjects[0].gameObject.transform.position, instance.distanceMeasurementObjects[1].gameObject.transform.position);
		// 		// Debug.Log("> distance: " + distance.ToString());
		// 		instance.distanceMeasurementStep = 0;
		// 		GameController.ChangeCursor();
		// 	}
		// }
	// }

	private void CancelAllMapOperations() {
		// Distance tool
		distanceMeasurementStep = 0;
		GameController.ChangeCursor();
	}


	////////////////////////
	///   MO SELECTION   ///
	////////////////////////
	public static void CleanMapObjects() {
		List<string> mos = new List<string>(mapObjects.Keys);
		for (int i = 0; i < mos.Count; i++) {
			Destroy(mapObjects[mos[i]].gameObject);
		}
		mapObjects = new Dictionary<string, MapObject>();
	}

  	public static void DeleteSelectedMapObjects() {
		instance.StartCoroutine(instance.DeleteMapObjectsLoop());
    	currentlySelectedObjects = new List<MapObject>();
    	SaveCurrentMap();
  	}

	private IEnumerator DeleteMapObjectsLoop() {
		for (int i = currentlySelectedObjects.Count - 1; i >=0; i--) {
			currentlySelectedObjects[i].DeleteSelf();
			yield return null;
		}
	}

	public static void ToggleMapObjectInSelection(MapObject mo) {
		// Debug.Log("---> ToggleMapObjectInSelection(" + mo.mapObjectData.objectName + ")");
		// add/remove the mo from the selection list
		if (currentlySelectedObjects.Contains(mo)) {
			currentlySelectedObjects.Remove(mo);
		}
		else {
			currentlySelectedObjects.Add(mo);
		}
		// Debug.Log("... " + currentlySelectedObjects.Count + " in selection");
		// toggle the spatial data panel
		if (MapController.currentlySelectedObjects.Count > 0) {
			instance.moSpatialDataPanel.SetActive(true);
      		SpatialDataController.PopulateSpatialData();
    	}
    	else {
      		SpatialDataController.CancelRename();
      		instance.moSpatialDataPanel.SetActive(false);
    	}
	}

	public static void UnseslectAllMapObjects() {
		//Debug.Log("---> UnseslectAllMapObjects()");
		for (int i = 0; i < currentlySelectedObjects.Count; i++) {
			currentlySelectedObjects[i].ToggleSelection();
		}
		currentlySelectedObjects = new List<MapObject>();
		instance.moSpatialDataPanel.SetActive(false);
	}


	///////////////////////
	///   MO MOVEMENT   ///
	///////////////////////
	public static void MapObjectMovementEnded(MapObject mo) {
		// Debug.Log("---> MapObjectMovementEnded()");
		if (currentMapData.gridType != Constants.gridTypeNone) {
			instance.SetGridPosition(mo);
		}
		if (currentMapData.rotationStepFront + currentMapData.rotationStepSide + currentMapData.rotationStepVertical > 0) {
			instance.SetRotation(mo);
		}
		mo.UpdateSpacialData();
		Helper.SaveMapObject(mo);
	}

	private void SetGridPosition(MapObject mo) {
		// Debug.Log("---> SetGridPosition(" + mo.gameObject.name + ")");
		float gridX = mo.gameObject.transform.position.x, gridY = mo.gameObject.transform.position.y, gridZ = mo.gameObject.transform.position.z;
		// Get the closest integer for y.
		//Debug.Log("initial position: " + mo.gameObject.transform.position.ToString());
		gridY = (gridY - Mathf.Floor(gridY) < Mathf.Ceil(gridY) - gridY ? Mathf.Floor(gridY) : Mathf.Ceil(gridY));
		if (currentMapData.gridType == Constants.gridTypeHex) {
			//Debug.Log("... hex!");
			int z1 = Mathf.FloorToInt(gridZ);
			int z2 = Mathf.CeilToInt(gridZ);
			int zOdd = (z1 % 2 == 0 ? z2 : z1);
			int zEven = (z1 % 2 == 0 ? z1 : z2);
			//Debug.Log("z: " + gridZ + " -> " + zOdd + ", " + zEven);
			int lambda = Mathf.FloorToInt(gridX/3);
			float xOdd = 3 * lambda + 1.5f;
			float xEven = (xOdd < gridX ? 3 * lambda + 3 : 3 * lambda);
			//Debug.Log("x: " + gridX+ " -> " + xOdd + ", " + xEven);
			Vector2 point = new Vector2(gridX, gridZ);
			Vector2 odd = new Vector2(xOdd, zOdd);
			Vector2 even = new Vector2(xEven, zEven);
			//Debug.Log("point: " + point);
			float distanceOdd = Vector2.Distance(point, odd);
			float distanceEven = Vector2.Distance(point, even);
			//Debug.Log("odd centre: " + odd + " (" + distanceOdd + ")");
			//Debug.Log("even centre: " + even + " (" + distanceEven + ")");
			if (distanceOdd < distanceEven) {
				gridX = xOdd;
				gridZ = zOdd;
			}
			else {
				gridX = xEven;
				gridZ = zEven;
			}
			//Debug.Log("chosen centre: (" + gridX + ", " + gridZ + ")");
		}
		else {
			//Debug.Log("... square!");
			gridX = (gridX - Mathf.Floor(gridX) < Mathf.Ceil(gridX) - gridX ? Mathf.Floor(gridX) : Mathf.Ceil(gridX));
			gridZ = (gridZ - Mathf.Floor(gridZ) < Mathf.Ceil(gridZ) - gridZ ? Mathf.Floor(gridZ) : Mathf.Ceil(gridZ));
		}
		// Debug.Log("final position: " + (new Vector3(gridX, gridY, gridZ)).ToString());
		mo.gameObject.transform.position = new Vector3(gridX, gridY, gridZ);
	}

	private void SetRotation(MapObject mo) {
		if (currentMapData.rotationStepFront > 0) {
			float rotationFront = mo.gameObject.transform.localEulerAngles.x;
			float targetRotationFront = QuantiseRotation(rotationFront, currentMapData.rotationStepFront);
			mo.gameObject.transform.Rotate(new Vector3(targetRotationFront - rotationFront, 0, 0), Space.Self);
		}
		if (currentMapData.rotationStepSide > 0) {
			float rotationSide = mo.gameObject.transform.localEulerAngles.z;
			float targetRotationSide = QuantiseRotation(rotationSide, currentMapData.rotationStepSide);
			mo.gameObject.transform.Rotate(new Vector3(0, 0, targetRotationSide - rotationSide), Space.Self);
		}
		if (currentMapData.rotationStepVertical > 0) {
			float rotationZ = mo.gameObject.transform.eulerAngles.y;
			float targetRotationZ = QuantiseRotation(rotationZ, currentMapData.rotationStepVertical);
			mo.gameObject.transform.Rotate(new Vector3(0, targetRotationZ - rotationZ, 0), Space.World);
		}
	}

	private float QuantiseRotation(float angle, int quantum) {
		// Debug.Log("---> QuantiseRotation(" + angle + ", " + quantum + ")");
		float mod = Mathf.Floor(angle / quantum);
		// Debug.Log("mod: " + mod);
		if (mod == 0) {
			return angle;
		}
		float low = mod * quantum;
		float high = low + quantum;
		// Debug.Log(">>> " + low + " - " + high + " <<<");
		if ((angle - low) < (high - angle)) {
			// Debug.Log("returning " + low);
			return low;
		}
		else {
			// Debug.Log("returning " + high);
			return high;
		}
	}


	///////////////////
	///   GENERAL   ///
	///////////////////
	public static void ConstructMapTree(string rootMapFile) {
		//Debug.Log("---> ConstructMapTree()");
		mapTree = new Dictionary<string, MapTreeNode>();
		MapTreeNode rootMapTreeNode = new MapTreeNode(rootMap);
		if (File.Exists(rootMapFile)) {
			//Debug.Log("Reading the root map!");
			rootMapTreeNode = (MapTreeNode)JsonObject.FromJson(rootMapTreeNode, Helper.ReadFile(rootMapFile));
		}
		else {
			//Debug.Log("Root map not found: creating new node!");
			Helper.SaveFile(rootMapFile, JsonObject.ToJson(rootMapTreeNode));
		}
		mapTree.Add(rootMapTreeNode.uid, rootMapTreeNode);
		ReadChildTreeNodes(rootMapTreeNode.uid);
	}

	private static void ReadChildTreeNodes(string uuid) {
		//Debug.Log("---> ReadChildTreeNodes(" + uuid + ")");
		List<string> children = mapTree[uuid].GetChildren();
		//Debug.Log("... has " + children.Count + " children!");
		//Debug.Log(Helper.PrintStringList(children));
		for (int i = 0; i < children.Count; i++) {
			MapTreeNode node = new MapTreeNode();
			//Debug.Log(uuid + " child: " + (i + 1));
			string filename = treeNodesDirectory + children[i] + ".json";
			if (File.Exists(filename)) {
				node = (MapTreeNode)JsonObject.FromJson(node, Helper.ReadFile(filename));
				mapTree.Add(node.uid, node);
				ReadChildTreeNodes(node.uid);
			}
			else {
				Helper.SaveFile(filename, JsonObject.ToJson(node));
				// TODO: Fix errors in the children/parent relationships... Especially missing links!
			}
		}
	}

	public static void RememberLastMap(string uid) {
		// Remember the map
		GameController.userData.lastMap = uid;
		Helper.SaveUserData();
	}

	public static void SaveCurrentMap() {
		//Debug.Log("---> SaveCurrentMap()");
		// Update the current map data into the currentMapData object wherever required.

		// Save the files.
		Helper.SaveCurrentMap();
		mapTree[currentMapData.mapUid].UpdateSelf();
		// Finish
		MainMenu.CloseMenus();
	}

}
