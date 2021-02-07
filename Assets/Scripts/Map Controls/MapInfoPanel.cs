﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapInfoPanel : MonoBehaviour {
	private string mapUid = "";
	// UI
	public Button addMapInfoItemButton;
	public Dropdown mapTypeSelector;
	public GameObject mapInfoContainer;
	public Text mapLocationInWorld;
	public Button addCommonMapInfoComponentsButton;
	public GameObject mapItemPrefab;
	public InputField newMapItemIndexInput;

	private void Start() {
		// Create required data
		Helper.FillDropdown(mapTypeSelector, Localization.dropdowns["eng"]["Map Types"]);

		// Create listeners
		addMapInfoItemButton.onClick.AddListener(AddNewMapInfoItem);
		//addCommonMapInfoComponentsButton.onClick.AddListener(AddCommonMapInfoComponents);
		mapTypeSelector.onValueChanged.AddListener(delegate {
			MapController.currentMapData.mapType = Helper.GetDropdownSelectedText(mapTypeSelector);
		});
	}

	private void Update() {
		RefreshMapInfoPanel();
	}

	private void OnEnable() {
		if (!GameController.initiationFinished || (mapUid == MapController.currentMapData.mapUid)) {
			return;
		}
		Helper.SelectDropdownValue(mapTypeSelector, MapController.currentMapData.mapType);
		SetNewMapItemIndex();
		Helper.EmptyContainer(mapInfoContainer);
		mapUid = MapController.currentMapData.mapUid;
		BuildMapLocationInWorld();
		CreateMapInfoItems();
		SortMapInfoContainer();
		//RefreshMapInfoPanel();
	}

	private void SortMapInfoContainer() {
		Helper.SortSelector(mapInfoContainer, "map info item");
	}

	private void BuildMapLocationInWorld() {
		//Debug.Log("---> BuildMapLocationInWorld()");
		string loc = GameController.dictionaries.NameGet(mapUid);
		string par = MapController.mapTree[mapUid].parent;
		while (!string.IsNullOrEmpty(par)) {
			Debug.Log("parent: " + par);
			loc = GameController.dictionaries.NameGet(par) + " > " + loc;
			par = MapController.mapTree[par].parent;
		}
		mapLocationInWorld.text = loc;
	}

	private void CreateMapInfoItems() {
		//Debug.Log("---> CreateMapInfoItems()");
		foreach (KeyValuePair<int, MapInfoItemData> pair in MapController.currentMapData.mapInfoItems) {
			GameObject go = Instantiate(mapItemPrefab, mapInfoContainer.transform);
			go.GetComponent<MapInfoItem>().FillDisplayElements(pair.Key, pair.Value);
		}
	}

	private void AddNewMapInfoItem() {
		//Debug.Log("---> AddNewMapInfoItem()");
		int newIndex = 1;
		int.TryParse(newMapItemIndexInput.text, out newIndex);
		if (MapController.currentMapData.mapInfoItems.ContainsKey(newIndex)) {
			MoveMapInfoItemForward(newIndex);
		}
		MapController.currentMapData.mapInfoItems.Add(newIndex, new MapInfoItemData());
		GameObject go = Instantiate(mapItemPrefab, mapInfoContainer.transform);
		go.GetComponent<MapInfoItem>().FillDisplayElements(newIndex, new MapInfoItemData());
		SetNewMapItemIndex();
	}

	private void RefreshMapInfoPanel() {
		SortMapInfoContainer();
		for (int i = 0; i < mapInfoContainer.transform.childCount; i++) {
			MapInfoItem mii = mapInfoContainer.transform.GetChild(i).GetComponent<MapInfoItem>();
			mii.ResizeViewPanel();
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(mapInfoContainer.GetComponent<RectTransform>());
	}

	private void SetNewMapItemIndex() {
		List<int> keys = new List<int>(MapController.currentMapData.mapInfoItems.Keys);
		if (keys.Count > 0) {
			newMapItemIndexInput.text = (keys.Max() + 1).ToString();
		}
		else {
			newMapItemIndexInput.text = "1";
		}
	}

	private void MoveMapInfoItemForward(int index) {
		//Debug.Log("--->  MoveMapInfoItem(" + index + ")");
		int targetIndex = index + 1;
		if (MapController.currentMapData.mapInfoItems.ContainsKey(targetIndex)) {
			MoveMapInfoItemForward(targetIndex);
		}
		MapInfoItemData miid = new MapInfoItemData(MapController.currentMapData.mapInfoItems[index]);
		MapController.currentMapData.mapInfoItems.Remove(index);
		MapController.currentMapData.mapInfoItems.Add(targetIndex, miid);
		for (int i = 0; i < mapInfoContainer.transform.childCount; i++) {
			MapInfoItem mii = mapInfoContainer.transform.GetChild(i).GetComponent<MapInfoItem>();
			if (mii.index == index) {
				mii.index = targetIndex;
				mii.indexDisplay.text = targetIndex.ToString();
				break;
			}
		}
	}


}