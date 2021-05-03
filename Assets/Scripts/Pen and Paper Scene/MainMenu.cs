using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public static MainMenu instance = null;
	// panels
	[Header("Panels")]
	[SerializeField] private GameObject mainMenuPanel;
	[SerializeField] private GameObject mapMenuPanel;
	[SerializeField] private GameObject userPanel;
	[SerializeField] private GameObject campaignsPanel;
	[SerializeField] private GameObject settingsPanel;
	[SerializeField] private GameObject newMapPanel;
	[SerializeField] private GameObject loadMapPanel;
	[SerializeField] private GameObject deleteMapPanel;
	[SerializeField] private GameObject mapControlsToolbar;
	[SerializeField] private GameObject mapInfoPanel;
	[SerializeField] private GameObject addMapObjectPanel;
	[SerializeField] private GameObject mapConfigurationPanel;
	[SerializeField] private GameObject mapObjectPanel;
	// main menu
	[Header("Main Menu")]
	[SerializeField] private Button mainMenuButton;
	[SerializeField] private Button userButton;
	[SerializeField] private Button campaignsButton;
	[SerializeField] private Button settingsButton;
	[SerializeField] private Button exitAppButton;
	// map menu
	[Header("Map Menu")]
	[SerializeField] private Button mapManuButton;
	[SerializeField] private Text mapHeaderText;
	[SerializeField] private Button newMapButton;
	[SerializeField] private Button saveMapButton;
	[SerializeField] private Button loadMapButton;
	[SerializeField] private Button editMapButton;
	[SerializeField] private Button deleteMapButton;

	private void Awake() {
		if (instance == null) { instance = this; }
	}

	private void Start() {
		// Add Listeners
		// (main menu)
		mainMenuButton.onClick.AddListener(delegate {
			mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
			mapMenuPanel.SetActive(false);
		});
		userButton.onClick.AddListener(delegate {
			TogglePanel("UserInfo");
		});
		campaignsButton.onClick.AddListener(delegate {
			TogglePanel("Campaigns");
		});
		settingsButton.onClick.AddListener(delegate {
			TogglePanel("Settings");
		});
		exitAppButton.onClick.AddListener(delegate {
			Application.Quit();
		});
		// (map menu)
		mapManuButton.onClick.AddListener(delegate {
			mainMenuPanel.SetActive(false);
			mapMenuPanel.SetActive(!mapMenuPanel.activeSelf);
		});
		newMapButton.onClick.AddListener(delegate {
			TogglePanel("NewMap");
		});
		saveMapButton.onClick.AddListener(delegate {
			CloseMenus();
			MapController.SaveCurrentMap();
		});
		loadMapButton.onClick.AddListener(delegate {
			TogglePanel("LoadMap");
		});

		// Finished initialisation...
		GameController.loadedMainMenu = true;
		PostLoad.FinishedInitialLoading();
	}

	///////////////////
	///   GENERAL   ///
	///////////////////
	public static void CloseMenus() {
		instance.mainMenuPanel.SetActive(false);
		instance.mapMenuPanel.SetActive(false);
		TogglePanel("NewMap", true, false);
		TogglePanel("DeleteMap", true, false);
		TogglePanel("LoadMap", true, false);
		TogglePanel("MapInfo", true, false);
		TogglePanel("AddMapObject", true, false);
		TogglePanel("MapConfiguration", true, false);
		TogglePanel("Settings", true, false);
		TogglePanel("UserInfo", true, false);
		TogglePanel("MapObject", true, false);
		CameraControl.cameraBlock = false;
	}

	public static void TogglePanel(string panel = "none", bool _override = false, bool state = false) {
		//Debug.Log("---> TogglePanel(" + panel + ", " + _override + ", " + state + ")");
		if (instance.newMapPanel) {
			instance.newMapPanel.SetActive((panel == "NewMap") && (_override ? state : !instance.newMapPanel.activeSelf));
		}
		if (instance.deleteMapPanel) {
			instance.deleteMapPanel.SetActive((panel == "DeleteMap") && (_override ? state : !instance.deleteMapPanel.activeSelf));
		}
		if (instance.loadMapPanel) {
			instance.loadMapPanel.SetActive((panel == "LoadMap") && (_override ? state : !instance.loadMapPanel.activeSelf));
		}
		if (instance.mapInfoPanel) {
			instance.mapInfoPanel.SetActive((panel == "MapInfo") && (_override ? state : !instance.mapInfoPanel.activeSelf));
		}
		if (instance.addMapObjectPanel) {
			instance.addMapObjectPanel.SetActive((panel == "AddMapObject") && (_override ? state : !instance.addMapObjectPanel.activeSelf));
		}
		if (instance.mapConfigurationPanel) {
			instance.mapConfigurationPanel.SetActive((panel == "MapConfiguration") && (_override ? state : !instance.mapConfigurationPanel.activeSelf));
		}
		if (instance.settingsPanel) {
			instance.settingsPanel.SetActive((panel == "Settings") && (_override ? state : !instance.settingsPanel.activeSelf));
		}
		if (instance.userPanel) {
			instance.userPanel.SetActive((panel == "UserInfo") && (_override ? state : !instance.userPanel.activeSelf));
		}
		if (instance.campaignsPanel) {
			instance.campaignsPanel.SetActive((panel == "Campaigns") && (_override ? state : !instance.campaignsPanel.activeSelf));
		}
		if (instance.campaignsPanel) {
			instance.mapObjectPanel.SetActive((panel == "MapObject") && (_override ? state : !instance.mapObjectPanel.activeSelf));
		}
	}

	///////////////
	///   MAP   ///
	///////////////
	public static void SetMapName(string mapName) {
		instance.mapHeaderText.text = mapName;
	}

	public static void RenameMap(string newMapName) {
		// mapNameInput.gameObject.SetActive(false);
		// if (newMapName != "") {
		// 	GameController.dictionaries.NameSet(MapController.currentMapData.mapUid, newMapName);
		// 	MapController.currentMapData.mapName = newMapName;
		// 	MapController.SaveCurrentMap();
		// 	SetMapName(newMapName);
		// }
	}


}
