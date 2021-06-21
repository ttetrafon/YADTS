using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
  public static MainMenu instance = null;

  [Header("Main Menu")]
  [SerializeField] private Button mainMenuButton;
  [SerializeField] private Button userButton;
  [SerializeField] private Button campaignsButton;
  [SerializeField] private Button settingsButton;
  [SerializeField] private Button exitAppButton;

  [Header("Map Menu")]
  [SerializeField] private Button mapMenuButton;
  [SerializeField] private Text mapHeaderText;
  [SerializeField] private Button newMapButton;
  [SerializeField] private Button saveMapButton;
  [SerializeField] private Button loadMapButton;
  [SerializeField] private Button editMapButton;
  [SerializeField] private Button deleteMapButton;
  // game system menu
  [Header("Game System Menu")]
  [SerializeField] private Button gameSystemMenuButton;
  [SerializeField] private Button nameGeneratorButton;


  private void Awake() {
    if (instance == null) { instance = this; }
  }

  private void Start() {
    // Add Listeners
    // (main menu)
    mainMenuButton.onClick.AddListener(delegate {
      PanelController.CloseMenus();
      PanelController.OpenPanel(Constants.panelMainMenu);
    });
    userButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      PanelController.OpenPanel(Constants.panelUser);
    });
    campaignsButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      PanelController.OpenPanel(Constants.panelCampaign);
    });
    settingsButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      PanelController.OpenPanel(Constants.panelSettings);
    });
    exitAppButton.onClick.AddListener(delegate {
      Application.Quit();
    });
    // (map menu)
    mapMenuButton.onClick.AddListener(delegate {
      PanelController.CloseMenus();
      PanelController.OpenPanel(Constants.panelMapMenu);
    });
    newMapButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      PanelController.OpenPanel(Constants.panelNewMap);
    });
    saveMapButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      MapController.SaveCurrentMap();
    });
    loadMapButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      PanelController.OpenPanel(Constants.panelLoadMap);
    });
    // (game system menu)
    gameSystemMenuButton.onClick.AddListener(delegate {
      PanelController.CloseMenus();
      PanelController.OpenPanel(Constants.panelGameSystemMenu);
    });
    nameGeneratorButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      PanelController.OpenPanel(Constants.panelNameGenerator);
    });

    // Finished initialisation...
    GameController.loadedMainMenu = true;
    PostLoad.FinishedInitialLoading();
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
