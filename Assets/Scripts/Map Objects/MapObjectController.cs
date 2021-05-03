using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObjectController : MonoBehaviour {
    public static MapObjectController instance = null;
    private string selectedPanel = Constants.mapObjectPanelBio; // Use this to remember which panel was last open in the panel. This is ignored between sessions.

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
    }


    ///////////////////////
    ///   UI CONTROLS   ///
    ///////////////////////
    private void DisplaySelection(string panel) {
        bioContainer.SetActive(panel == Constants.mapObjectPanelBio);
        propertiesContainer.SetActive(panel == Constants.mapObjectPanelProperties);
    }

}
