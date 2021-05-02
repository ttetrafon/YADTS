using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpatialDataController : MonoBehaviour {
	public static SpatialDataController instance = null;

	// UI
	[Header("Name")]
	[SerializeField] private Text moNameLabel;
	[SerializeField] private Button renameMapObjectButton;
	[SerializeField] private InputField moNameInput;
	[SerializeField] private Button cancelRenameButton;
	[Header("Position")]
	[SerializeField] private InputField positionXInput;
	[SerializeField] private Button positionXPlus;
	[SerializeField] private Button positionXMinus;
	[SerializeField] private InputField positionYInput;
	[SerializeField] private Button positionYPlus;
	[SerializeField] private Button positionYMinus;
	[SerializeField] private InputField positionZInput;
	[SerializeField] private Button positionZPlus;
	[SerializeField] private Button positionZMinus;
	[Header("Position")]
	[SerializeField] private InputField scaleXInput;
	[SerializeField] private Button scaleXPlus;
	[SerializeField] private Button scaleXMinus;
	[SerializeField] private InputField scaleYInput;
	[SerializeField] private Button scaleYPlus;
	[SerializeField] private Button scaleYMinus;
	[SerializeField] private InputField scaleZInput;
	[SerializeField] private Button scaleZPlus;
	[SerializeField] private Button scaleZMinus;
	[Header("Rotation")]
	[SerializeField] private InputField rotationZInput;
	[SerializeField] private Button rotaionZPlus;
	[SerializeField] private Button rotaionZMinus;
	[SerializeField] private InputField rotationFrontInput;
	[SerializeField] private Button rotaionFrontPlus;
	[SerializeField] private Button rotaionFrontMinus;
	[SerializeField] private InputField rotationSideInput;
	[SerializeField] private Button rotaionSidePlus;
	[SerializeField] private Button rotaionSideMinus;

	// Data
	[Header("Data")]
	public static Vector3 selectedMoPositions = Vector3.zero;
	public static Vector3 selectedMoRotation = Vector3.zero;
	public static Vector3 selectedMoScales = Vector3.zero;


	/////////////////////
	///   LIFECYCLE   ///
	/////////////////////
	private void Awake() {
		// Debug.Log("SpatialDataController awake!");
		if (instance == null) { instance = this; }

		// Listeners
		moNameInput.onEndEdit.AddListener(delegate { FinishRename(); });
		renameMapObjectButton.onClick.AddListener(StartRename);
		cancelRenameButton.onClick.AddListener(CancelRename);
		positionXInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(positionXInput.text, out input);
			float diff = input - selectedMoPositions.x;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangePosition(diff, 0, 0));
			}
		});
		positionXPlus.onClick.AddListener(delegate{
			StartCoroutine(ChangePosition((MapController.currentMapData.gridType == Constants.gridTypeHex ? 3 : 1), 0, 0));
		});
		positionXMinus.onClick.AddListener(delegate{
			StartCoroutine(ChangePosition((MapController.currentMapData.gridType == Constants.gridTypeHex ? -3f : -1), 0, 0));
		});
		positionYInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(positionYInput.text, out input);
			float diff = input - selectedMoPositions.z;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangePosition(0, diff, 0));
			}
		});
		positionYPlus.onClick.AddListener(delegate{
			StartCoroutine(ChangePosition(0, (MapController.currentMapData.gridType == Constants.gridTypeHex ? 2 : 1), 0));
		});
		positionYMinus.onClick.AddListener(delegate{
			StartCoroutine(ChangePosition(0, (MapController.currentMapData.gridType == Constants.gridTypeHex ? -2 : -1), 0));
		});
		positionZInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(positionZInput.text, out input);
			float diff = input - selectedMoPositions.y;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangePosition(0, 0, diff));
			}
		});
		positionZPlus.onClick.AddListener(delegate{
			StartCoroutine(ChangePosition(0, 0, (MapController.currentMapData.gridType == Constants.gridTypeHex ? 1 : 1)));
		});
		positionZMinus.onClick.AddListener(delegate{
			StartCoroutine(ChangePosition(0, 0, (MapController.currentMapData.gridType == Constants.gridTypeHex ? -1 : -1)));
		});
		scaleXInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(scaleXInput.text, out input);
			float diff = input - selectedMoScales.x;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangeScale(diff, 0, 0));
			}
		});
		scaleXPlus.onClick.AddListener(delegate {
			StartCoroutine(ChangeScale(1, 0, 0));
		});
		scaleXMinus.onClick.AddListener(delegate {
			StartCoroutine(ChangeScale(-1, 0, 0));
		});
		scaleYInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(scaleYInput.text, out input);
			float diff = input - selectedMoScales.z;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangeScale(0, diff, 0));
			}
		});
		scaleYPlus.onClick.AddListener(delegate {
			StartCoroutine(ChangeScale(0, 1, 0));
		});
		scaleYMinus.onClick.AddListener(delegate {
			StartCoroutine(ChangeScale(0, -1, 0));
		});
		scaleZInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(scaleZInput.text, out input);
			float diff = input - selectedMoScales.y;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangeScale(0, 0, diff));
			}
		});
		scaleZPlus.onClick.AddListener(delegate {
			StartCoroutine(ChangeScale(0, 0, 1));
		});
		scaleZMinus.onClick.AddListener(delegate {
			StartCoroutine(ChangeScale(1, 0, -1));
		});
		rotationZInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(rotationZInput.text, out input);
			float diff = input - selectedMoRotation.x;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangeRotation(diff, 0, 0));
			}
		});
		rotaionZPlus.onClick.AddListener(delegate {
			int step = MapController.currentMapData.rotationStepVertical;
			StartCoroutine(ChangeRotation(step > 0 ? step : 1, 0, 0));
		});
		rotaionZMinus.onClick.AddListener(delegate {
			int step = MapController.currentMapData.rotationStepVertical;
			StartCoroutine(ChangeRotation(step > 0 ? -step : -1, 0, 0));
		});
		rotationFrontInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(rotationFrontInput.text, out input);
			float diff = input - selectedMoRotation.y;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangeRotation(0, diff, 0));
			}
		});
		rotaionFrontPlus.onClick.AddListener(delegate {
			int step = MapController.currentMapData.rotationStepFront;
			StartCoroutine(ChangeRotation(0, step > 0 ? step : 1, 0));
		});
		rotaionFrontMinus.onClick.AddListener(delegate {
			int step = MapController.currentMapData.rotationStepFront;
			StartCoroutine(ChangeRotation(0, step > 0 ? -step : -1, 0));
		});
		rotationSideInput.onEndEdit.AddListener(delegate {
			float input = 0;
			float.TryParse(rotationSideInput.text, out input);
			float diff = input - selectedMoRotation.z;
			if (diff != 0 && SpatialDataController.instance.gameObject.activeSelf) {
				StartCoroutine(ChangeRotation(0, 0, diff));
			}
		});
		rotaionSidePlus.onClick.AddListener(delegate {
			int step = MapController.currentMapData.rotationStepSide;
			StartCoroutine(ChangeRotation(0, 0, step > 0 ? step : 1));
		});
		rotaionSideMinus.onClick.AddListener(delegate {
			int step = MapController.currentMapData.rotationStepSide;
			StartCoroutine(ChangeRotation(0, 0, step > 0 ? -step : -1));
		});
	}

	private void OnEnable() {
		moNameLabel.gameObject.SetActive(true);
		moNameInput.gameObject.SetActive(false);
	}


	/////////////////
	///   PANEL   ///
	/////////////////
	public static void PopulateSpatialData() {
		// Debug.Log("---> PopulateSpatialData()");
		// Debug.Log("selected mo count: " + MapController.currentlySelectedObjects.Count);
		instance.PopulateName();
		instance.StartCoroutine(instance.PopulateData());
	}


	////////////////
	///   NAME   ///
	////////////////
	private void PopulateName() {
		if (MapController.currentlySelectedObjects.Count == 1) {
			moNameLabel.text = MapController.currentlySelectedObjects[0].mapObjectData.objectName;
			moNameLabel.fontStyle = FontStyle.Bold;
			renameMapObjectButton.gameObject.SetActive(true);
		}
		else {
			moNameLabel.text = "Multiple Objects";
			moNameLabel.fontStyle = FontStyle.Italic;
			renameMapObjectButton.gameObject.SetActive(false);
		}
	}

	private void StartRename() {
		moNameLabel.gameObject.SetActive(false);
		moNameInput.gameObject.SetActive(true);
		moNameInput.text = MapController.currentlySelectedObjects[0].mapObjectData.objectName;
	}

	private void FinishRename() {
		string newName = moNameInput.text;
		if ((newName != "") && (newName != MapController.currentlySelectedObjects[0].mapObjectData.objectName)) {
			MapController.currentlySelectedObjects[0].RenameSelf(newName);
			moNameLabel.text = newName;
		}
		moNameInput.gameObject.SetActive(false);
		moNameLabel.gameObject.SetActive(true);
	}

	public static void CancelRename() {
		if (MapController.currentlySelectedObjects.Count == 0) {
			return;
		}
		instance.moNameInput.text = MapController.currentlySelectedObjects[0].mapObjectData.objectName;
		instance.moNameInput.gameObject.SetActive(false);
		instance.moNameLabel.gameObject.SetActive(true);
	}


	////////////////
	///   DATA   ///
	////////////////
	private IEnumerator PopulateData() {
		// Debug.Log("---> PopulateData()");
		int moCount = MapController.currentlySelectedObjects.Count;
		// Debug.Log("moCount: " + moCount);
		selectedMoPositions = Vector3.zero;
		selectedMoRotation = Vector3.zero;
		selectedMoScales = Vector3.zero;
		// Debug.Log("selectedMoPositions (pre): " + selectedMoPositions);
		for (int i = 0; i < moCount; i++) {
			Transform tr = MapController.currentlySelectedObjects[i].transform;
			selectedMoPositions += tr.position;
			selectedMoScales += tr.localScale;
			selectedMoRotation.x += tr.eulerAngles.y;
			selectedMoRotation.y += tr.localEulerAngles.x;
			selectedMoRotation.z += tr.localEulerAngles.z;
			yield return null;
		}
		// Debug.Log("selectedMoPositions (aft): " + selectedMoPositions);
		if (moCount > 0) {
			selectedMoPositions = selectedMoPositions / moCount;
			selectedMoPositions.x = (float) decimal.Round((decimal) selectedMoPositions.x, 2);
			selectedMoPositions.y = (float) decimal.Round((decimal) selectedMoPositions.y, 2);
			selectedMoPositions.z = (float) decimal.Round((decimal) selectedMoPositions.z, 2);
			selectedMoRotation = selectedMoRotation / moCount;
			selectedMoRotation.x = (float) decimal.Round((decimal) selectedMoRotation.x, 2);
			selectedMoRotation.y = (float) decimal.Round((decimal) selectedMoRotation.y, 2);
			selectedMoRotation.z = (float) decimal.Round((decimal) selectedMoRotation.z, 2);
			selectedMoScales = selectedMoScales / moCount;
			selectedMoScales.x = (float) decimal.Round((decimal) selectedMoScales.x, 2);
			selectedMoScales.y = (float) decimal.Round((decimal) selectedMoScales.y, 2);
			selectedMoScales.z = (float) decimal.Round((decimal) selectedMoScales.z, 2);
		}
		positionXInput.text = selectedMoPositions.x.ToString();
		positionYInput.text = selectedMoPositions.z.ToString();
		positionZInput.text = selectedMoPositions.y.ToString();
		rotationZInput.text = selectedMoRotation.x.ToString();
		rotationFrontInput.text = selectedMoRotation.y.ToString();
		rotationSideInput.text = selectedMoRotation.z.ToString();
		scaleXInput.text = selectedMoScales.x.ToString();
		scaleYInput.text = selectedMoScales.z.ToString();
		scaleZInput.text = selectedMoScales.y.ToString();
	}

	private IEnumerator ChangePosition(float x, float y, float z) {
		for (int i = 0; i < MapController.currentlySelectedObjects.Count; i++) {
			Vector3 pos = MapController.currentlySelectedObjects[i].transform.position;
			pos += new Vector3(x, z, y);
			MapController.currentlySelectedObjects[i].transform.position = pos;
			MapController.MapObjectMovementEnded(MapController.currentlySelectedObjects[i]);
			yield return null;
		}
		if (SpatialDataController.instance.gameObject.activeSelf) {
			SpatialDataController.PopulateSpatialData();
		}
	}

	private IEnumerator ChangeRotation(float z, float front, float side) {
		for (int i = 0; i < MapController.currentlySelectedObjects.Count; i++) {
			MapController.currentlySelectedObjects[i].transform.Rotate(new Vector3(0, z, 0), Space.World);
			MapController.currentlySelectedObjects[i].transform.Rotate(new Vector3(front, 0, side), Space.Self);
			MapController.MapObjectMovementEnded(MapController.currentlySelectedObjects[i]);
			yield return null;
		}
		if (SpatialDataController.instance.gameObject.activeSelf) {
			SpatialDataController.PopulateSpatialData();
		}
	}

	private IEnumerator ChangeScale(float x, float y, float z) {
		for (int i = 0; i < MapController.currentlySelectedObjects.Count; i++) {
			Vector3 scale = MapController.currentlySelectedObjects[i].transform.localScale;
			scale += new Vector3(x, z, y);
			MapController.currentlySelectedObjects[i].transform.localScale = scale;
			MapController.MapObjectMovementEnded(MapController.currentlySelectedObjects[i]);
			yield return null;
		}
		if (SpatialDataController.instance.gameObject.activeSelf) {
			SpatialDataController.PopulateSpatialData();
		}
	}


}
