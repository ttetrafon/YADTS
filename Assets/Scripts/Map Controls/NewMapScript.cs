using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class NewMapScript : MonoBehaviour {
	public Button createNewMapButton;
	public InputField newMapNameInput;
	public Dropdown parentDropdown;

	private void Start() {
		// Create listeners
		createNewMapButton.onClick.AddListener(CreateNewMap);
	}

	private void CreateNewMap() {
		string newMapName = newMapNameInput.text;
		if (string.IsNullOrEmpty(newMapName)) {
			Debug.LogError("Empty name when creating new map...");
			// TODO: Notify the user that the operation failed... (Text Chat: System Tab)
			return;
		}
		// Clear out the previous map lists.
		MapController.CleanMapObjects();
		MapController.currentlySelectedObjects = new List<MapObject>();
		// Create and assign new map data.
		string newUid = Helper.GenerateUid();
		GameController.dictionaries.NameAdd(newUid, newMapName);
		// ... map tree node
		string nodeParent = Helper.ExtractMapUidFromMapDropdown(parentDropdown.options[parentDropdown.value].text);
		MapTreeNode mapTreeNode = new MapTreeNode(newUid, nodeParent);
		MapController.mapTree[nodeParent].AddChild(newUid);
		MapController.mapTree.Add(newUid, mapTreeNode);
		// ... map data
		MapController.currentMapData = new MapData(newUid);
		MapController.currentMapData.mapName = newMapName;
		Helper.SaveFile(MapController.mapDirectory + newUid + ".json", JsonObject.ToJson(MapController.currentMapData));
		Debug.Log("Creating map: " + GameController.dictionaries.NameGet(MapController.currentMapData.mapUid) + " (" + MapController.currentMapData.mapUid + ")");
		// Display the name.
		MainMenu.SetMapName(newMapName);
		// Finish
		MapController.RememberLastMap(newUid);
		MainMenu.CloseMenus();
	}

}
