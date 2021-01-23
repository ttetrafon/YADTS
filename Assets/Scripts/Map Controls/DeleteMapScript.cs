using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DeleteMapScript : MonoBehaviour {
	public Button deleteMapButton;
	public Toggle deleteChildrenToggle;

	private void OnEnable() {
		deleteChildrenToggle.isOn = false;
	}

	private void Start() {
		// Add listeners
		deleteMapButton.onClick.AddListener(DeleteMap);
	}

	private void DeleteMap() {
		Debug.Log("---> DeleteMap()");
		string mapUid = MapController.currentMapData.mapUid;
		if (mapUid == MapController.rootMap) {
			Debug.Log("Cannot remove root!");
			return;
		}
		MapTreeNode mapNode = MapController.mapTree[mapUid];
		// Delete the map itself and the tree node.
		DeleteMapComponents(mapUid);
		MapController.mapTree[mapNode.parent].RemoveChild(mapUid);
		// Delete the children maps (and nodes) ...
		List<string> children = mapNode.children;
		//Debug.Log("map children: " + Helper.PrintStringList(children));
		if (deleteChildrenToggle.isOn) {
			Debug.Log("... deleting child maps.");
			for (int i = 0; i < children.Count; i++) {
				MapController.mapTree[children[i]].DeleteSelf();
			}
		}
		// ... or add them to the parent.
		else {
			Debug.Log("... assigning child maps to parent.");
			for (int i = 0; i < children.Count; i++) {
				MapController.mapTree[mapNode.parent].AddChild(children[i]);
				MapController.mapTree[children[i]].SetLevel(mapNode.level);
			}
		}
		// Rebuild the Map Tree.
		MapController.ConstructMapTree(MapController.rootMapFile);
		// Load the root map.
		LoadMapScript.LoadMap(MapController.rootMap);
		MainMenu.CloseMenus();
	}

	public static void DeleteMapComponents(string mapUid, bool debug = false) {
		if (debug) { Debug.Log("---> DeleteMapComponents(" + mapUid + ")"); }
		string mapFile = MapController.mapDirectory + mapUid + ".json";
		if (File.Exists(mapFile)) {
			if (debug) { Debug.Log("... removing map file: " + mapFile); }
			File.Delete(mapFile);
		}
		string nodeFile = MapController.treeNodesDirectory + mapUid + ".json";
		if (File.Exists(nodeFile)) {
			if (debug) { Debug.Log("... removing node file: " + nodeFile); }
			File.Delete(nodeFile);
		}
		if (MapController.mapTree.ContainsKey(mapUid)) {
			if (debug) { Debug.Log("... removing node from tree: " + mapUid); }
			MapController.mapTree.Remove(mapUid);
		}
		GameController.dictionaries.NameRemove(mapUid, debug);
	}

}
