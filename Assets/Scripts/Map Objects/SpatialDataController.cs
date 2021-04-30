using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpatialDataController : MonoBehaviour {
	public static SpatialDataController instance = null;

	// UI
	[SerializeField] private Text moNameLabel;
	[SerializeField] private Button renameMapObjectButton;
	[SerializeField] private InputField moNameInput;
	[SerializeField] private Button cancelRenameButton;

	// Data
  	public static Vector3 selectedMoPositions = Vector3.zero;

	private void Awake() {
		// Debug.Log("SpatialDataController awake!");
		if (instance == null) { instance = this; }

		// Listeners
		moNameInput.onEndEdit.AddListener(delegate { FinishRename(); });
		renameMapObjectButton.onClick.AddListener(StartRename);
		cancelRenameButton.onClick.AddListener(CancelRename);
	}

	private void OnEnable() {
		moNameLabel.gameObject.SetActive(true);
		moNameInput.gameObject.SetActive(false);
	}

	public static void PopulateSpatialData() {
		Debug.Log("---> PopulateSpatialData()");
		// Map object name
		// Debug.Log("selected mo count: " + MapController.currentlySelectedObjects.Count);
		if (MapController.currentlySelectedObjects.Count == 1) {
			instance.moNameLabel.text = MapController.currentlySelectedObjects[0].mapObjectData.objectName;
			instance.moNameLabel.fontStyle = FontStyle.Bold;
			instance.renameMapObjectButton.gameObject.SetActive(true);
		}
		else {
			instance.moNameLabel.text = "Multiple Objects";
			instance.moNameLabel.fontStyle = FontStyle.Italic;
			instance.renameMapObjectButton.gameObject.SetActive(false);
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

}
