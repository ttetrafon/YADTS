using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObjectController : MonoBehaviour {
  public static MapObjectController instance = null;
  private string selectedPanel = Constants.mapObjectPanelBio; // Use this to remember which panel was last open in the panel. This is ignored between sessions.
  public static MapObject selectedMapObject; // The selected Map Object, if it exists in the map!
  public static MapObjectData selectedMapObjectData; // The selected Map Object, if it does not exist in the map!

  [Header("General")]
  [SerializeField] private Dropdown moCategorySelector;
  [SerializeField] private Dropdown moSelector;

  [Header("Bio")]
  [SerializeField] private Button bioTab;
  [SerializeField] private GameObject bioContainer;

  [Header("Properties")]
  [SerializeField] private Button propertiesTab;
  [SerializeField] private GameObject propertiesContainer;


  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
  private void Awake() {
    if (instance == null) {
      instance = this;
    }

    // Initiation
    Helper.FillDropdown(moCategorySelector, Localization.dropdowns["eng"]["Map Object Categories"]);

    // Listeners
    bioTab.onClick.AddListener(delegate{
      DisplaySelection(Constants.mapObjectPanelBio);
      selectedPanel = Constants.mapObjectPanelBio;
    });
    propertiesTab.onClick.AddListener(delegate{
      DisplaySelection(Constants.mapObjectPanelProperties);
      selectedPanel = Constants.mapObjectPanelProperties;
    });
    moCategorySelector.onValueChanged.AddListener(delegate {
      FillMapObjectsList();
      selectedMapObject = null;
      RefreshPanels();
    });
    moSelector.onValueChanged.AddListener(delegate {
      SelectMapObject();
    });
  }

  private void OnEnable() {
    DisplaySelection(selectedPanel);
    FillMapObjectsList();
    selectedMapObject = null;
  }


  ///////////////////////
  ///   UI CONTROLS   ///
  ///////////////////////
  private void DisplaySelection(string panel) {
    bioContainer.SetActive(panel == Constants.mapObjectPanelBio);
    propertiesContainer.SetActive(panel == Constants.mapObjectPanelProperties);
  }

  private void FillMapObjectsList() {
    Debug.Log("---> FillMapObjectsList()");
    string category = Helper.GetDropdownSelectedText(moCategorySelector);
    switch(category) { // FIXME: This won't work with different localization...
      case "Currenty selected":
        List<string> values = new List<string>() { "-" };
        for (int i = 0; i < MapController.currentlySelectedObjects.Count; i++) {
          MapObjectData mod = MapController.currentlySelectedObjects[i].mapObjectData;
          values.Add(mod.objectName + " [" + mod.objectUuid + "]");
        }
        Helper.FillDropdown(moSelector, values, "-");
        break;
      default:
        Debug.LogError("No category selected...");
        Helper.FillDropdown(moSelector, new List<string>(), "-");
        break;
    }
  }

  private void SelectMapObject() {
    Debug.Log("---> FillMapObjectsList()");
    // Locate and select the map object, or just its data if it's not on the map.
    string category = Helper.GetDropdownSelectedText(moCategorySelector);
    string moUid = Helper.ExtractUidFromDropdown(Helper.GetDropdownSelectedText(moSelector));
    if (moUid == "-") {
      selectedMapObject = null;
      selectedMapObjectData = null;
    }
    else {
      switch(category) {
        case "Currenty selected":
          for (int i = 0; i < MapController.currentlySelectedObjects.Count; i++) {
            if (MapController.currentlySelectedObjects[i].name == moUid) {
              selectedMapObject = MapController.currentlySelectedObjects[i];
              selectedMapObjectData = MapController.currentlySelectedObjects[i].mapObjectData;
              break;
            }
          }
          Debug.Log("selected mo: " + selectedMapObject.mapObjectData.objectName);
          break;
        case "Creatures in map":
        case "Vehicles in map":
        case "Items in map":
        case "Terrain in map":
        case "Effects in map":
        case "In map":
        case "All creatures":
        case "All vehicles":
        case "All items":
        case "All terrain":
        case "All effects":
        case "All":
        default:
          Debug.LogError("No category selected...");
          break;
      }
    }
    // Refresh the appropriate panel...
    RefreshPanels();
  }

  private void RefreshPanels() {
    if (bioContainer.activeSelf) {
    }
    else if (propertiesContainer.activeSelf) {
      MapObjectControllerProperties.CleanPropertiesPanel();
      MapObjectControllerProperties.PopulatePropertiesPanel();
    }
  }

}
