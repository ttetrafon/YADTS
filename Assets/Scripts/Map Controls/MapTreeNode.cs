using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapTreeNode {
	public string uid = "";
	public string parent = "";
	public List<string> children = new List<string>();
	public int level = 0;

	public MapTreeNode() { }
	public MapTreeNode (string uuid) {
		this.uid = uuid;
	}
	public MapTreeNode(string uid, string parentUid) {
		// This constructor is used when creating a new map.
		Debug.Log("---> MapTreeNode(" + uid + ", " + parentUid +  ")");
		this.uid = uid;
		this.parent = parentUid;
		this.level = MapController.mapTree[parent].level + 1;
		SaveSelf();
	}
	public MapTreeNode(MapTreeNode that) {
		this.uid = that.uid;
		this.parent = that.parent;
		this.children = that.children;
		this.level = that.level;
	}

	public void AddChild(string childUid) {
		if (!children.Contains(childUid)) {
			children.Add(childUid);
			SortChildren();
			SaveSelf();
		}
	}

	public void RemoveChild(string childUid) {
		if (children.Contains(childUid)) {
			children.Remove(childUid);
			SortChildren();
			SaveSelf();
		}
	}

	public List<string> GetChildren() {
		SortChildren();
		UpdateSelf();
		return this.children;
	}

	private void SaveSelf() {
		Helper.SaveFile(MapController.treeNodesDirectory + uid + ".json", JsonObject.ToJson(this));
	}

	public void SetLevel(int newLevel) {
		this.level = newLevel;
		SaveSelf();
		for (int i = 0; i < this.children.Count; i++) {
			if (MapController.mapTree.ContainsKey(this.children[i])) {
				MapController.mapTree[this.children[i]].SetLevel(newLevel + 1);
			}
		}
	}

	public void DeleteSelf() {
		for (int i = 0; i < this.children.Count; i++) {
			if (MapController.mapTree.ContainsKey(this.children[i])) {
				MapController.mapTree[this.children[i]].DeleteSelf();
			}
		}
		DeleteMapScript.DeleteMapComponents(this.uid);
	}

	private void SortChildren() {
		children = children.OrderBy(uid => GameController.dictionaries.NameGet(uid)).ToList<string>();
	}

	public void UpdateSelf() {
		SortChildren();
		MapController.mapTree[this.uid] = this;
		SaveSelf();
	}

}
