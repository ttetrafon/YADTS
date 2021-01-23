using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpatialDataController : MonoBehaviour {
	public static SpatialDataController instance = null;

	// UI
	public Text moNameLabel;
	public InputField moNameInput;
	public Button cancelRenameButton;

	// Data
  public static Vector3 selectedMoPositions = Vector3.zero;

	private void Awake() {
		// Debug.Log("SpatialDataController awake!");
		if (instance == null) { instance = this; }

		// Listeners
		moNameInput.onEndEdit.AddListener(delegate {
			string newName = moNameInput.text;
			if ((newName != "") && (newName != MapController.currentlySelectedObjects[0].mapObjectData.objectName)) {
				MapController.currentlySelectedObjects[0].RenameSelf(newName);
				moNameLabel.text = newName;
			}
			moNameInput.gameObject.SetActive(false);
			moNameLabel.gameObject.SetActive(true);
		});
		cancelRenameButton.onClick.AddListener(CancelRename);
	}

	private void OnEnable() {
		moNameLabel.gameObject.SetActive(true);
		moNameInput.gameObject.SetActive(false);
	}

	public static void PopulateSpatialData() {
		// Debug.Log("---> PopulateSpatialData()");
		// Map object name
		// Debug.Log("selected mo count: " + MapController.currentlySelectedObjects.Count);
		if (MapController.currentlySelectedObjects.Count == 1) {
			instance.moNameLabel.text = MapController.currentlySelectedObjects[0].mapObjectData.objectName;
			instance.moNameLabel.fontStyle = FontStyle.Bold;
		}
		else {
			instance.moNameLabel.text = "Multiple Objects";
			instance.moNameLabel.fontStyle = FontStyle.Italic;
		}
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
