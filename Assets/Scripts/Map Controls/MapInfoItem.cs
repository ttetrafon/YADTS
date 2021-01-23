using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapInfoItem : MonoBehaviour {
	public int index = -1;
	// ui
	private GameObject parent;
	public GameObject viewMode;
	public GameObject textDisplayPanel;
	public TMP_Text textDisplay;
	public Text indexDisplay;
	public Button moveDownButton;
	public Button moveUpButton;
	public Image playerVisibleIndicator;
	public Button editButton;
	public GameObject editMode;
	public InputField positionInput;
	public Toggle moveAssociatedItemsToggle;
	public Toggle playerVisibleToggle;
	public Dropdown typeSelector;
	public InputField textInput;
	public Button confirmEditButton;
	public Button cancelEditButton;
	// info
	public TMP_StyleSheet stylesheet;

	private void Awake() {
		//Debug.Log("MapInfoItem.Awake()");
		parent = this.gameObject.transform.parent.gameObject;
		Helper.FillDropdown(typeSelector, Localization.dropdowns["eng"]["Text Format Choices"]);


		// Set listeners
		editButton.onClick.AddListener(delegate {
			FillEditElements();
			ToggleMode();
		});
		confirmEditButton.onClick.AddListener(delegate {
			UpdateInfo();
			ToggleMode();
		});
		cancelEditButton.onClick.AddListener(ToggleMode);
		moveDownButton.onClick.AddListener(delegate {
			MoveMapInfoItem(index, index + 1);
		});
		moveUpButton.onClick.AddListener(delegate {
			MoveMapInfoItem(index, index - 1);
		});
	}

	public void ToggleMode() {
		//Debug.Log("---> ToggleMode()");
		editMode.SetActive(!editMode.activeSelf);
		viewMode.SetActive(!viewMode.activeSelf);
		if (viewMode.activeSelf) {
			ResizeViewPanel();
		}
		// TODO: This forced layout rebuild is probably needed to a mistake in how the layout components in MapItemData is set...
		LayoutRebuilder.ForceRebuildLayoutImmediate(parent.GetComponent<RectTransform>());
	}

	private void UpdateInfo() {
		// text
		MapController.currentMapData.mapInfoItems[index].text = textInput.text;
		textDisplay.text = textInput.text;
		// type
		MapController.currentMapData.mapInfoItems[index].type = Helper.GetDropdownSelectedText(typeSelector);
		textDisplay.textStyle = stylesheet.GetStyle(Localization.tmpProStyleHashes[MapController.currentMapData.mapInfoItems[index].type]);
		// index
		bool indexChanged = MapController.currentMapData.mapInfoItems[index].Equals(Int32.Parse(positionInput.text));
		indexDisplay.text = positionInput.text;
		if (indexChanged) {
			//TODO: Sort MapController.currentMapData.mapInfoItems dictionary... maybe?
			Helper.SortSelector(parent, "map info item");
		}
		Helper.SaveCurrentMap();
	}

	public void FillDisplayElements(int ind, MapInfoItemData data) {
		index = ind;
		indexDisplay.text = index.ToString();
		textDisplay.text = data.text;
		textDisplay.textStyle = stylesheet.GetStyle(Localization.tmpProStyleHashes[MapController.currentMapData.mapInfoItems[index].type]);
		playerVisibleIndicator.gameObject.SetActive(data.playerVisibile);
	}

	private void FillEditElements() {
		positionInput.text = index.ToString();
		moveAssociatedItemsToggle.isOn = false;
		playerVisibleToggle.isOn = MapController.currentMapData.mapInfoItems[index].playerVisibile;
		textInput.text = MapController.currentMapData.mapInfoItems[index].text;
		Helper.SelectDropdownValue(typeSelector, MapController.currentMapData.mapInfoItems[index].type);
	}

	public void ResizeViewPanel() {
		//Debug.Log("---> ResizeViewPanel()");
		float y = textDisplay.textBounds.size.y;
		var marginsY = textDisplay.margin.y * 2;
		//Debug.Log("... x: " + textDisplay.textBounds.size.x + "; ... y: " + (y + marginsY).ToString());
		viewMode.GetComponent<RectTransform>().sizeDelta = new Vector2(100,  (y + marginsY > 35 ? y + marginsY : 45));
	}

	private void MoveMapInfoItem(int currentIndex, int targetIndex) {
		//Debug.Log("---> MoveMapInfoItem(" + currentIndex + " -> " + targetIndex + ")");
		bool targetExists = MapController.currentMapData.mapInfoItems.ContainsKey(targetIndex);
		MapInfoItemData currentItem = new MapInfoItemData(MapController.currentMapData.mapInfoItems[currentIndex]);
		MapInfoItemData targetItem = (targetExists ? new MapInfoItemData(MapController.currentMapData.mapInfoItems[targetIndex]) : null);
		MapController.currentMapData.mapInfoItems.Remove(currentIndex);
		if (targetExists) {
			MapController.currentMapData.mapInfoItems.Remove(targetIndex);
		}
		MapController.currentMapData.mapInfoItems.Add(targetIndex, currentItem);
		if (targetExists) {
			MapController.currentMapData.mapInfoItems.Add(currentIndex, targetItem);
		}
		for (int i = 0, found = 0; i < parent.transform.childCount; i++) {
			MapInfoItem mii = parent.transform.GetChild(i).GetComponent<MapInfoItem>();
			if (mii.index == currentIndex) {
				found++;
				mii.index = targetIndex;
				mii.indexDisplay.text = targetIndex.ToString();
			}
			else if (mii.index == targetIndex) {
				found++;
				mii.index = currentIndex;
				mii.indexDisplay.text = currentIndex.ToString();
			}
			if (((found == 2) && targetExists) || ((found == 1) && !targetExists)) {
				break;
			}
		}
		Helper.SortSelector(parent, "map info item");
	}

}
