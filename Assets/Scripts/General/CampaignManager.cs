using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CampaignManager : MonoBehaviour {
  // Data
  public static List<string> campaignSubfolders = new List<string>() {
		"dictionaries",
		"game system",
		"game system/name generator",
		"maps",
		"map objects",
		"map objects/effect",
		"map objects/creature",
		"map objects/item",
		"map objects/terrain",
		"map objects/vehicle",
		"map tree hierarchy"
	};

  // Controls
  [SerializeField] private Dropdown campaignSelector;
  [SerializeField] private InputField campaignNameInput;
  [SerializeField] private Button confirmButton;


  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
  private void Start() {
    // populate the dropdown
    List<string> campaigns = new List<string>() { "New Campaign" };
    campaigns.AddRange(GameController.userData.campaigns);
    Helper.FillDropdown(campaignSelector, campaigns, GameController.userData.selectedCampaign);

    // add listeners
    campaignSelector.onValueChanged.AddListener(delegate {
      string campaign = Helper.GetDropdownSelectedText(campaignSelector);
      campaignNameInput.text = "";
      campaignNameInput.gameObject.SetActive(campaign == "New Campaign");
    });
    campaignNameInput.onEndEdit.AddListener(delegate {
      string newName = campaignNameInput.text;
      if (!Helper.TestVsRegex(newName, Helper.regexLegalFileSystemCharacters)) {
        campaignNameInput.text = "";
      }
    });
    confirmButton.onClick.AddListener(delegate {
      // prepare for the new/loaded campaign
      string campaign = Helper.GetDropdownSelectedText(campaignSelector);
      if (campaign == "New Campaign") {
        string newName = campaignNameInput.text;
        if (string.IsNullOrEmpty(newName)) {
          return;
        }
        campaign = newName;
        GameController.userData.campaigns.Add(campaign);
        GameController.userData.campaigns.Sort();
      }
      GameController.userData.selectedCampaign = campaign;
      Helper.SaveUserData();

      // perform all data functions
      SetCampaignFolders();
      EnableControls();
      StartCampaignData();

      // load the root map
      LoadMapScript.LoadMap(MapController.rootMap);
    });
  }

  private void OnEnable() {
    Helper.SelectDropdownValue(campaignSelector, GameController.userData.selectedCampaign);
  }

  //////////////////////////
  ///   INITIALISATION   ///
  //////////////////////////
  public static void SetCampaignFolders() {
		// Debug.Log("---> SetCampaignFolders()");
		GameController.saveFolder = GameController.baseFolder + GameController.userData.selectedCampaign + "/";
		//Debug.Log("saveFolder: " + GameController.saveFolder);
		GameController.backupFolder = GameController.saveFolder + "BACKUPS" + "/";
		//Debug.Log("backupFolder: " + GameController.saveFolder);
		MapController.treeNodesDirectory = GameController.saveFolder + "map tree hierarchy" + "/";
		//Debug.Log("treeNodesDirectory: " + MapController.treeNodesDirectory);
		MapController.mapDirectory = GameController.saveFolder + "maps" + "/";
		//Debug.Log("mapDirectory: " + MapController.mapDirectory);
		MapController.mapObjectsDirectory = GameController.saveFolder + "map objects" + "/";
		//Debug.Log("mapObjectsDirectory: " + MapController.mapObjectsDirectory);
		MapController.rootMapFile = MapController.treeNodesDirectory + MapController.rootMap + ".json";
		//Debug.Log("rootMapFile: " + MapController.rootMapFile);
	}

  public static void EnableControls(bool enable = true) {
		// Debug.Log("---> EnableControls(" + enable + ")");
    if (enable) {
      InputController.controls.Common.Enable();
      InputController.controls.MapMode.Enable();
    }
    else {
      InputController.controls.Common.Disable();
      InputController.controls.MapMode.Disable();
    }
  }

  public static void StartCampaignData() {
    // Debug.Log("---> StartCampaignData()");
    string dictionariesFile = GameController.saveFolder + "dictionaries/dictionaries.json";
    //Debug.Log("dictionariesFile: " + dictionariesFile);
    if (File.Exists(dictionariesFile)) {
      //Debug.Log("... reading dictionaries");
      //Debug.Log(Helper.ReadFile(dictionariesFile));
      GameController.dictionaries = (Dictionaries)JsonObject.FromJson(new Dictionaries(), Helper.ReadFile(dictionariesFile));
    }
    if (!GameController.dictionaries.UuidExists(MapController.rootMap)) {
      GameController.dictionaries.NameAdd(MapController.rootMap, "Multiverse");
    }

    // Create any missing subfolders.
    for (int i = 0; i < campaignSubfolders.Count; i++) {
      if (!Directory.Exists(GameController.saveFolder + campaignSubfolders[i])) {
        Directory.CreateDirectory(GameController.saveFolder + campaignSubfolders[i]);
      }
    }

    // Create the map tree
    MapController.ConstructMapTree(MapController.rootMapFile);
    //Debug.Log("initial map: " + currentMapData.mapUid);
  }



}
