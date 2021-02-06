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
	public Button mapInfoButton;

	// Map Objects
	public static List<MapObject> currentlySelectedObjects = new List<MapObject>(); // Holds a list of all currently selected map objects.
	public static Dictionary<string, MapObject> mapObjects = new Dictionary<string, MapObject>();
  	public float slowMovementModifier = 0.25f;
	private float xyMovementSensitivity = 0.5f;
	private float zMovementSensitivity = 0.5f;
	// private float arrowMovementSensitivity = 5.0f;
	private float rotationSensitivity = 5.0f;
	public GameObject moSpatialDataPanel;

	// Map Object Controls
	public Button magicAxiomButton;
	public Dropdown magicAxiomSelector;
	public Text magicAxiomDisplay;
	public Button socialAxiomButton;
	public Dropdown socialAxiomSelector;
	public Text socialAxiomDisplay;
	public Button spiritAxiomButton;
	public Dropdown spiritAxiomSelector;
	public Text spiritAxiomDisplay;
	public Button techAxiomButton;
	public Dropdown techAxiomSelector;
	public Text techAxiomDisplay;

	// Distance Tool
	public Button distanceMeasurementButton;
	private int distanceMeasurementStep = 0;
	private MapObject[] distanceMeasurementObjects = new MapObject[2];

	// Controls

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

    // Set the controls
    // moControls.MapController.MoveXY.performed += ctx => moMoveXY = ctx.ReadValue<Vector2>();
    // moControls.MapController.MoveXY.canceled += ctx => moMoveXY = Vector2.zero;
    // moControls.MapController.MoveZ.performed += ctx => moMoveZ = ctx.ReadValue<Vector2>().y;
    // moControls.MapController.MoveZ.canceled += ctx => moMoveZ = 0.0f;
    // moControls.MapController.RotateZ.performed += ctx => moRotateZ = ctx.ReadValue<Vector2>().x;
    // moControls.MapController.RotateZ.canceled += ctx => moRotateZ = 0.0f;
    // moControls.MapController.RotateFront.performed += ctx => moRotateFront = (-1) * ctx.ReadValue<Vector2>().y;
    // moControls.MapController.RotateFront.canceled += ctx => moRotateFront = 0.0f;
    // moControls.MapController.RotateSide.performed += ctx => moRotateSide = ctx.ReadValue<Vector2>().x;
    // moControls.MapController.RotateSide.canceled += ctx => moRotateSide = 0.0f;
    // moControls.MapController.MapObjectMovementEnded.performed += ctx => MapObjectMovementEnded();
    // moControls.MapController.CancelMapOperations.performed += ctx => CancelAllMapOperations();
  }

	private void OnEnable() {
		// moControls.MapController.Enable();
	}

	private void OnDisable() {
		// moControls.MapController.Disable();
	}

	private void Start() {
		//Debug.Log("===> MapController Start");
		// Set values.
		rootMapFile = treeNodesDirectory + rootMap + ".json";
		//Debug.Log("rootMapFile: " + rootMapFile);
		ConstructMapTree(rootMapFile);
		SetAxioms();
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
		magicAxiomButton.onClick.AddListener(delegate {
			magicAxiomSelector.gameObject.SetActive(!magicAxiomSelector.gameObject.activeSelf);
			magicAxiomDisplay.gameObject.SetActive(!magicAxiomDisplay.gameObject.activeSelf);
		});
		magicAxiomSelector.onValueChanged.AddListener(delegate {
			int value = -1;
			int.TryParse(magicAxiomSelector.options[magicAxiomSelector.value].text, out value);
			SetAxiom("Magic", value, instance.magicAxiomDisplay);
		});
		socialAxiomButton.onClick.AddListener(delegate {
			socialAxiomSelector.gameObject.SetActive(!socialAxiomSelector.gameObject.activeSelf);
			socialAxiomDisplay.gameObject.SetActive(!socialAxiomDisplay.gameObject.activeSelf);
		});
		socialAxiomSelector.onValueChanged.AddListener(delegate {
			int value = -1;
			int.TryParse(socialAxiomSelector.options[socialAxiomSelector.value].text, out value);
			SetAxiom("Social", value, instance.socialAxiomDisplay);
		});
		spiritAxiomButton.onClick.AddListener(delegate {
			spiritAxiomSelector.gameObject.SetActive(!spiritAxiomSelector.gameObject.activeSelf);
			spiritAxiomDisplay.gameObject.SetActive(!spiritAxiomDisplay.gameObject.activeSelf);
		});
		spiritAxiomSelector.onValueChanged.AddListener(delegate {
			int value = -1;
			int.TryParse(spiritAxiomSelector.options[spiritAxiomSelector.value].text, out value);
			SetAxiom("Spirit", value, instance.spiritAxiomDisplay);
		});
		techAxiomButton.onClick.AddListener(delegate {
			techAxiomSelector.gameObject.SetActive(!techAxiomSelector.gameObject.activeSelf);
			techAxiomDisplay.gameObject.SetActive(!techAxiomDisplay.gameObject.activeSelf);
		});
		techAxiomSelector.onValueChanged.AddListener(delegate {
			int value = -1;
			int.TryParse(techAxiomSelector.options[techAxiomSelector.value].text, out value);
			SetAxiom("Tech", value, instance.techAxiomDisplay);
		});

		// Finished Loading
		GameController.loadedMapController = true;
		PostLoad.FinishedInitialLoading();
	}

	private void Update() {
		if (!Helper.isUIActive()) {
			for (int i = 0; i < currentlySelectedObjects.Count; i++) {
				currentlySelectedObjects[i].transform.position += new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * InputController.moMoveXY.y * xyMovementSensitivity * MapObjectControlsShiftModifier();
				currentlySelectedObjects[i].transform.position += new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z) * InputController.moMoveXY.x * xyMovementSensitivity * MapObjectControlsShiftModifier();
				currentlySelectedObjects[i].transform.Translate(new Vector3(0, InputController.moMoveZ * zMovementSensitivity * MapObjectControlsShiftModifier(), 0));
				currentlySelectedObjects[i].transform.Rotate(new Vector3(0, InputController.moRotateZ * rotationSensitivity * MapObjectControlsShiftModifier()), Space.World);
				currentlySelectedObjects[i].transform.Rotate(new Vector3(InputController.moRotateFront, 0, InputController.moRotateSide) * rotationSensitivity * MapObjectControlsShiftModifier(), Space.Self);
			}
			UpdatePositionDiplay();
		}
	}

	public static void MapObjectClicked(MapObject mo) {
		// Debug.Log("---> MapObjectClicked called from " + mo.mapObjectData.objectName);
		// Distance tool selected
		if (instance.distanceMeasurementStep > 0) {
			if (instance.distanceMeasurementStep == 1) {
				instance.distanceMeasurementObjects[0] = mo;
				instance.distanceMeasurementStep = 2;
			}
			else {
				instance.distanceMeasurementObjects[1] = mo;
				float distance = Vector3.Distance(instance.distanceMeasurementObjects[0].gameObject.transform.position, instance.distanceMeasurementObjects[1].gameObject.transform.position);
				// Debug.Log("> distance: " + distance.ToString());
				instance.distanceMeasurementStep = 0;
				GameController.ChangeCursor();
			}
		}
		// Map object clicked
		else {
			// if (instance.moControls.MapController.Modifier_Shift.ReadValue<float>() > 0) {
			// 	mo.ToggleSelection();
			// 	ToggleMapObjectInSelection(mo);
			// }
			// else {
			// 	UnseslectAllMapObjects();
			// 	mo.ToggleSelection();
			// 	ToggleMapObjectInSelection(mo);
			// }
		}
	}

  private void MapObjectMovementEnded() {
    Debug.Log("---> MapObjectMovementEnded()");
    for (int i = 0; i < currentlySelectedObjects.Count; i++) {
      if (currentMapData.gridType != Constants.gridTypeNone) {
        SetGridPosition(currentlySelectedObjects[i]);
      }
      if (currentMapData.rotationStepFront + currentMapData.rotationStepSide + currentMapData.rotationStepVertical > 0) {
        SetRotation(currentlySelectedObjects[i]);
      }
      currentlySelectedObjects[i].UpdateSpacialData(currentlySelectedObjects[i].gameObject);
      Helper.SaveMapObject(currentlySelectedObjects[i]);
    }
  }

  private float MapObjectControlsShiftModifier() {
    // if (moControls.MapController.Modifier_Shift.ReadValue<float>() > 0) {
    //   return slowMovementModifier;
    // }
    return 1.0f;
  }

  private void CancelAllMapOperations() {
    // Distance tool
    distanceMeasurementStep = 0;
    GameController.ChangeCursor();
  }

	private void UpdatePositionDiplay() {

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

	public static void SetAxioms() {
		int magicAxiom = GetAxiom(currentMapData.mapUid, "Magic", instance.magicAxiomDisplay);
		Helper.SelectDropdownValue(instance.magicAxiomSelector, magicAxiom.ToString());
		int socialAxiom = GetAxiom(currentMapData.mapUid, "Social", instance.socialAxiomDisplay);
		Helper.SelectDropdownValue(instance.socialAxiomSelector, socialAxiom.ToString());
		int spiritAxiom = GetAxiom(currentMapData.mapUid, "Spirit", instance.spiritAxiomDisplay);
		Helper.SelectDropdownValue(instance.spiritAxiomSelector, spiritAxiom.ToString());
		int techAxiom = GetAxiom(currentMapData.mapUid, "Tech", instance.techAxiomDisplay);
		Helper.SelectDropdownValue(instance.techAxiomSelector, techAxiom.ToString());
	}

	private void SetAxiom(string axiom, int value, Text axiomDisplay) {
		currentMapData.axioms[axiom] = value;
		if (value < 0) {
			axiomDisplay.text = GetParentAxiom(currentMapData.mapUid, axiom).ToString();
		}
		else {
			axiomDisplay.text = value.ToString();
		}
	}

	private static int GetParentAxiom(string mapUid, string axiom) {
		int res;
		string parent = mapTree[mapUid].parent;
		if (string.IsNullOrEmpty(parent)) {
			return 10;
		}
		MapData md = LoadMapScript.GetMapData(parent);
		res = md.axioms[axiom];
		if (res < 0) {
			return GetParentAxiom(parent, axiom);
		}
		return res;
	}

	private static int GetAxiom(string mapUid, string axiom, Text axiomDisplay) {
		int res;
		res = currentMapData.axioms[axiom];
		if (res < 0) {
			axiomDisplay.text = GetParentAxiom(mapUid, axiom).ToString();
		}
		else {
			axiomDisplay.text = res.ToString();
		}
		return res;
	}

	public static void CleanMapObjects() {
		List<string> mos = new List<string>(mapObjects.Keys);
		for (int i = 0; i < mos.Count; i++) {
			Destroy(mapObjects[mos[i]].gameObject);
		}
		mapObjects = new Dictionary<string, MapObject>();
	}

	public static void RememberLastMap(string uid) {
		// Remember the map
		GameController.userData.lastMap = uid;
		Helper.SaveUserData();
	}

	public static void ToggleMapObjectInSelection(MapObject mo) {
		// Debug.Log("---> ToggleMapObjectInSelection(" + mo.mapObjectData.objectName + ")");
		if (currentlySelectedObjects.Contains(mo)) {
			currentlySelectedObjects.Remove(mo);
		}
		else {
			currentlySelectedObjects.Add(mo);
		}
		// Debug.Log("... " + currentlySelectedObjects.Count + " in selection");
	}

	public static void UnseslectAllMapObjects() {
		//Debug.Log("---> UnseslectAllMapObjects()");
		for (int i = 0; i < currentlySelectedObjects.Count; i++) {
			currentlySelectedObjects[i].ToggleSelection();
		}
		currentlySelectedObjects = new List<MapObject>();
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
      float targetRotationZ = QuantiseRotation(rotationZ, currentMapData.rotationStepVertical);;
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

}
