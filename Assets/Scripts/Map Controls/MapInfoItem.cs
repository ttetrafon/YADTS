using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapInfoItem : MonoBehaviour {
  public int index = -1;
  private GameObject parent;
  [SerializeField] private TMP_StyleSheet stylesheet;
  private string infoItemType;

  [Header("View Mode")]
  [SerializeField] private GameObject viewMode;
  [SerializeField] private TMP_Text textDisplay;
  [SerializeField] private Text indexDisplay;
  [SerializeField] private Button moveDownButton;
  [SerializeField] private Button moveUpButton;
  [SerializeField] private Image playerVisibleIndicator;
  [SerializeField] private Button editButton;

  [Header("Edit Mode")]
  [SerializeField] private GameObject editMode;
  [SerializeField] private InputField positionInput;
  [SerializeField] private Toggle moveAssociatedItemsToggle;
  [SerializeField] private Toggle playerVisibleToggle;
  [SerializeField] private Dropdown typeSelector;
  [SerializeField] private InputField textInput;
  [SerializeField] private Button confirmEditButton;
  [SerializeField] private Button cancelEditButton;
  [SerializeField] private Button deleteEditButton;


  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
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
    deleteEditButton.onClick.AddListener(delegate {
      DeleteItem();
    });
  }


  ///////////////////
  ///   GENERAL   ///
  ///////////////////
  public void ToggleMode() {
    //Debug.Log("---> ToggleMode()");
    editMode.SetActive(!editMode.activeSelf);
    viewMode.SetActive(!viewMode.activeSelf);
    if (viewMode.activeSelf) {
      ResizeViewPanel();
    }
    MapInfoPanel.changeCounter = 0;
  }

  public void ResizeViewPanel() {
    // TODO: Use a count (like with ChatElement) to resize elements only twice.
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
        mii.SetIndexDisplay(targetIndex);
      }
      else if (mii.index == targetIndex) {
        found++;
        mii.index = currentIndex;
        mii.SetIndexDisplay(currentIndex);
      }
      if (((found == 2) && targetExists) || ((found == 1) && !targetExists)) {
        break;
      }
    }
    Helper.SortSelector(parent, "map info item");
  }


  ///////////////////
  ///   DISPLAY   ///
  ///////////////////
  public void FillDisplayElements(int index, MapInfoItemData data, string type) {
    // Debug.Log("---> FillDisplayElements(" + ind + ")");
    // Debug.Log(data.Print());
    this.index = index;
    this.infoItemType = type;
    indexDisplay.text = index.ToString();
    textDisplay.text = data.text;
    textDisplay.textStyle = stylesheet.GetStyle(Localization.tmpProStyleHashes[MapController.currentMapData.mapInfoItems[index].type]);
    playerVisibleIndicator.gameObject.SetActive(data.playerVisibile);
  }

  public void SetIndexDisplay(int index) {
    this.indexDisplay.text = index.ToString();
  }

  ////////////////
  ///   EDIT   ///
  ////////////////
  private void UpdateInfo() {
    // text
    MapController.currentMapData.mapInfoItems[index].text = textInput.text;
    textDisplay.text = Helper.ParseInfoInputText(textInput.text);
    // player visible
    playerVisibleIndicator.gameObject.SetActive(this.playerVisibleToggle.isOn);
    if (MapController.currentMapData.mapInfoItems.ContainsKey(this.index)) {
      MapController.currentMapData.mapInfoItems[index].playerVisibile = this.playerVisibleToggle.isOn;
    }
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

  private void FillEditElements() {
    positionInput.text = index.ToString();
    moveAssociatedItemsToggle.isOn = false;
    playerVisibleToggle.isOn = MapController.currentMapData.mapInfoItems[index].playerVisibile;
    textInput.text = MapController.currentMapData.mapInfoItems[index].text;
    Helper.SelectDropdownValue(typeSelector, MapController.currentMapData.mapInfoItems[index].type);
  }

  public void DeleteItem() {
    // remove:
    //		item info from map data
    if (MapController.currentMapData.mapInfoItems.ContainsKey(this.index)) {
      MapController.currentMapData.mapInfoItems.Remove(this.index);
    }
    Helper.SaveCurrentMap();
    //		item object from hierarchy
    Destroy(this.gameObject);
  }

}
