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

	// Data
  	public static Vector3 selectedMoPositions = Vector3.zero;


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
			if (input != 0) {
				float diff = input - selectedMoPositions.x;
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
			if (input != 0) {
				float diff = input - selectedMoPositions.z;
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
			if (input != 0) {
				float diff = input - selectedMoPositions.y;
				StartCoroutine(ChangePosition(0, 0, diff));
			}
		});
		positionZPlus.onClick.AddListener(delegate{
			StartCoroutine(ChangePosition(0, 0, (MapController.currentMapData.gridType == Constants.gridTypeHex ? 1 : 1)));
		});
		positionZMinus.onClick.AddListener(delegate{
			StartCoroutine(ChangePosition(0, 0, (MapController.currentMapData.gridType == Constants.gridTypeHex ? -1 : -1)));
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
		instance.StartCoroutine(instance.PopulatePosition());
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


	////////////////////
	///   POSITION   ///
	////////////////////
	private IEnumerator PopulatePosition() {
		// Debug.Log("---> PopulatePosition()");
		int moCount = MapController.currentlySelectedObjects.Count;
		// Debug.Log("moCount: " + moCount);
		selectedMoPositions = Vector3.zero;
		// Debug.Log("selectedMoPositions (pre): " + selectedMoPositions);
		for (int i = 0; i < moCount; i++) {
			selectedMoPositions += MapController.currentlySelectedObjects[i].gameObject.transform.position;
			yield return new WaitForSeconds(GeneralSettings.yieldLoop);
		}
		// Debug.Log("selectedMoPositions (aft): " + selectedMoPositions);
		selectedMoPositions = selectedMoPositions / moCount;
		selectedMoPositions.x = (float) decimal.Round((decimal) selectedMoPositions.x, 2);
		selectedMoPositions.y = (float) decimal.Round((decimal) selectedMoPositions.y, 2);
		selectedMoPositions.z = (float) decimal.Round((decimal) selectedMoPositions.z, 2);
		positionXInput.text = selectedMoPositions.x.ToString();
		positionYInput.text = selectedMoPositions.z.ToString();
		positionZInput.text = selectedMoPositions.y.ToString();
		yield return new WaitForSeconds(GeneralSettings.yieldLoop);
	}

	private IEnumerator ChangePosition(float x, float y, float z) {
		for (int i = 0; i < MapController.currentlySelectedObjects.Count; i++) {
			Vector3 pos = MapController.currentlySelectedObjects[i].transform.position;
			pos += new Vector3(x, z, y);
			MapController.currentlySelectedObjects[i].transform.position = pos;
			yield return new WaitForSeconds(GeneralSettings.yieldLoop);
		}
		StartCoroutine(MapController.MapObjectMovementEnded());
		yield return new WaitForSeconds(GeneralSettings.yieldLoop);
	}

}
