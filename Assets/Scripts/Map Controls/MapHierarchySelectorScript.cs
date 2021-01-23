using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapHierarchySelectorScript : MonoBehaviour {
	private Dropdown selector;
	private string levelIndicator = "| ";

	private void Awake() {
		selector = this.GetComponent<Dropdown>();
	}

	private void OnEnable() {
		//Debug.Log("A MapHierarchySelector is Enabled!");
		selector.ClearOptions();
		string multiverse = ConstructName(MapController.rootMap);
		selector.AddOptions(new List<string>() { multiverse });
		BuildMapMenu(MapController.rootMap);
		if (selector.gameObject.activeSelf) {
			//Debug.Log("current map: " + MapController.currentMapData.mapUid);
			Helper.SelectDropdownValue(selector, MapController.currentMapData.mapUid);
		}
	}

	private void BuildMapMenu(string map) {
		if (!GameController.loadedGameController) {
			return;
		}
		//Debug.Log("---> BuildMapMenu(" + map + ")");
		List<string> children = MapController.mapTree[map].GetChildren();
		//Debug.Log(GameController.dictionaries.NameGet(map) + " has " + children.Count + " children...");
		for (int i = 0; i < children.Count; i++) {
			MapTreeNode node = MapController.mapTree[children[i]];
			//Debug.Log("child node:" + node.uid + " -> " + GameController.dictionaries.NameGet(node.uid));
			selector.AddOptions(new List<string>() { string.Concat(Enumerable.Repeat(levelIndicator, node.level)) + ConstructName(node.uid) });
			BuildMapMenu(children[i]);
		}
	}

	private string ConstructName(string uid) {
		return GameController.dictionaries.NameGet(uid) + " [" + uid + "]";
	}

}
