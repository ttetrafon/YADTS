using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObjectController : MonoBehaviour {
    public static MapObjectController instance = null;
    private string selectedPanel = Constants.mapObjectPanelBio; // Use this to remember which panel was last open in the panel. This is ignored between sessions.

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
    }

    private void OnEnable() {
        DisplaySelection(selectedPanel);
        FillMapObjectsList();
    }


    ///////////////////////
    ///   UI CONTROLS   ///
    ///////////////////////
    private void DisplaySelection(string panel) {
        bioContainer.SetActive(panel == Constants.mapObjectPanelBio);
        propertiesContainer.SetActive(panel == Constants.mapObjectPanelProperties);
    }


    ///////////////////////
    ///   UI CONTROLS   ///
    ///////////////////////
    private void FillMapObjectsList() {
        Debug.Log("---> FillMapObjectsList()");
        string category = Helper.GetDropdownSelectedText(moCategorySelector);
        switch(category) {
            case "Currenty selected":
                List<string> values = new List<string>() { "-" };
                for (int i = 0; i < MapController.currentlySelectedObjects.Count; i++) {
                    MapObjectData mod = MapController.currentlySelectedObjects[i].mapObjectData;
                    values.Add(mod.objectName + " (" + mod.objectUuid + ")");
                }
                Helper.FillDropdown(moSelector, values, "-");
                break;
            default:
                Debug.LogError("No category selected...");
                break;
        }
    }

}
