using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public static MainMenu instance = null;
	// interface controls
	// public static InputControls interfaceControls;
	// main menu
	public Button mainMenuButton;
	public Button exitAppButton;
	public Button frontScreenButton;
	public GameObject mainMenuPanel;
	// panels
	public GameObject deleteMapPanel;
	public GameObject loadMapPanel;
	public GameObject newMapPanel;
	public GameObject mapInfoPanel;
	public GameObject addMapObjectPanel;
	public GameObject mapConfigurationPanel;
	// map menu
	public Text mapHeaderText;
	public Button mapToolsButton;
	public GameObject mapToolsPanel;
	public Button newMapButton;
	public Button saveMapButton;
	public Button loadMapButton;
	public Button editMapButton;
	public Button deleteMapButton;
	public InputField mapNameInputRef;
	public static InputField mapNameInput;

	private void Awake() {
		if (instance == null) { instance = this; }
		// interfaceControls = new InputControls();
	}

	private void Start() {
		// Set references
		mapNameInput = mapNameInputRef;

		// Add Listeners
		// (main menu)
		mainMenuButton.onClick.AddListener(delegate {
			mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
			mapToolsPanel.SetActive(false);
		});
		frontScreenButton.onClick.AddListener(delegate {
			SceneManager.LoadScene("Front Screen");
		});
		exitAppButton.onClick.AddListener(delegate {
			Application.Quit();
		});
		// (map menu)
		mapToolsButton.onClick.AddListener(delegate {
			mainMenuPanel.SetActive(false);
			mapToolsPanel.SetActive(!mapToolsPanel.activeSelf);
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
		editMapButton.onClick.AddListener(delegate {
			mapNameInput.gameObject.SetActive(!mapNameInput.gameObject.activeSelf);
		});
		deleteMapButton.onClick.AddListener(delegate {
			TogglePanel("DeleteMap");
		});
		mapNameInput.onEndEdit.AddListener(delegate {
			string newMapName = mapNameInput.text;
			RenameMap(newMapName);
		});

		// Finished initialisation...
		GameController.loadedMainMenu = true;
		PostLoad.FinishedInitialLoading();
	}

	private void OnEnable() {
		// interfaceControls.Interface.Enable();
	}

	private void OnDisable() {
		// interfaceControls.Interface.Disable();
	}

	///////////////////
	///   GENERAL   ///
	///////////////////
	public static void CloseMenus() {
		instance.mainMenuPanel.SetActive(false);
		instance.mapToolsPanel.SetActive(false);
		TogglePanel("NewMap", true, false);
		TogglePanel("DeleteMap", true, false);
		TogglePanel("LoadMap", true, false);
		TogglePanel("MapInfo", true, false);
		TogglePanel("AddMapObject", true, false);
		TogglePanel("MapConfiguration", true, false);
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
	}

	///////////////
	///   MAP   ///
	///////////////
	public static void SetMapName(string mapName) {
		instance.mapHeaderText.text = mapName;
	}

	public static void RenameMap(string newMapName) {
		mapNameInput.gameObject.SetActive(false);
		if (newMapName != "") {
			GameController.dictionaries.NameSet(MapController.currentMapData.mapUid, newMapName);
			MapController.currentMapData.mapName = newMapName;
			MapController.SaveCurrentMap();
			SetMapName(newMapName);
		}
	}


}
