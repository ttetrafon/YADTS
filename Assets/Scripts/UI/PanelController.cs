using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {
  public static PanelController instance = null;
  private List<GameObject> panelList;
  private int panelCount;

  [Header("Menus")]
  [SerializeField] private GameObject mainMenu;
  [SerializeField] private GameObject mapMenu;
  [SerializeField] private GameObject gameSystemMenu;

  [Header("Main Menu")]
  [SerializeField] private GameObject userPanel;
	[SerializeField] private GameObject campaignsPanel;
	[SerializeField] private GameObject settingsPanel;

  [Header("Map Menu")]
	[SerializeField] private GameObject newMapPanel;
	[SerializeField] private GameObject loadMapPanel;
	[SerializeField] private GameObject deleteMapPanel;
	[SerializeField] private GameObject mapInfoPanel;
	[SerializeField] private GameObject addMapObjectPanel;
	[SerializeField] private GameObject mapConfigurationPanel;
	[SerializeField] private GameObject mapObjectPanel;

  [Header("Game System Menu")]
  [SerializeField] private GameObject planesOfExistencePanel;
	[SerializeField] private GameObject nameGeneratorPanel;



  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
  private void Start() {
    if (instance == null) {
      instance = this;
    }

    this.panelList = new List<GameObject>() {
      this.mainMenu,
      this.mapMenu,
      this.gameSystemMenu,
      this.userPanel,
      this.campaignsPanel,
      this.settingsPanel,
      this.newMapPanel,
      this.loadMapPanel,
      this.deleteMapPanel,
      this.mapInfoPanel,
      this.addMapObjectPanel,
      this.mapConfigurationPanel,
      this.mapObjectPanel,
      this.nameGeneratorPanel,
      this.planesOfExistencePanel
    };
    this.panelCount = this.panelList.Count;

  }


  ////////////////////
  ///   CONTROLS   ///
  ////////////////////
  public static void CloseMenus() {
    instance.mapMenu.SetActive(false);
    instance.mainMenu.SetActive(false);
    instance.gameSystemMenu.SetActive(false);
  }
  public static void CloseAllPanels() {
    for (int i = 0; i < instance.panelCount; i++) {
      instance.panelList[i].SetActive(false);
    }
  }

  public static void OpenPanel(string panel) {
    if (panel == Constants.panelMainMenu) {
      instance.mainMenu.SetActive(!instance.mainMenu.activeSelf);
    }
    else if (panel == Constants.panelMapMenu) {
      instance.mapMenu.SetActive(!instance.mapMenu.activeSelf);
    }
    else if (panel == Constants.panelGameSystemMenu) {
      instance.gameSystemMenu.SetActive(!instance.gameSystemMenu.activeSelf);
    }
    else if (panel == Constants.panelUser) {
      instance.userPanel.SetActive(!instance.userPanel.activeSelf);
    }
    else if (panel == Constants.panelCampaign) {
      instance.campaignsPanel.SetActive(!instance.campaignsPanel.activeSelf);
    }
    else if (panel == Constants.panelSettings) {
      instance.settingsPanel.SetActive(!instance.settingsPanel.activeSelf);
    }
    else if (panel == Constants.panelNewMap) {
      instance.newMapPanel.SetActive(!instance.newMapPanel.activeSelf);
    }
    else if (panel == Constants.panelLoadMap) {
      instance.loadMapPanel.SetActive(!instance.loadMapPanel.activeSelf);
    }
    else if (panel == Constants.panelDeleteMap) {
      instance.deleteMapPanel.SetActive(!instance.deleteMapPanel.activeSelf);
    }
    else if (panel == Constants.panelMapInfo) {
      instance.mapInfoPanel.SetActive(!instance.mapInfoPanel.activeSelf);
    }
    else if (panel == Constants.panelAddMapObject) {
      instance.addMapObjectPanel.SetActive(!instance.addMapObjectPanel.activeSelf);
    }
    else if (panel == Constants.panelMapConfiguration) {
      instance.mapConfigurationPanel.SetActive(!instance.mapConfigurationPanel.activeSelf);
    }
    else if (panel == Constants.panelMapObject) {
      instance.mapObjectPanel.SetActive(!instance.mapObjectPanel.activeSelf);
    }
    else if (panel == Constants.panelNameGenerator) {
      instance.nameGeneratorPanel.SetActive(!instance.nameGeneratorPanel.activeSelf);
    }
    else if (panel == Constants.panelPlanesOfExistence) {
      instance.planesOfExistencePanel.SetActive(!instance.planesOfExistencePanel.activeSelf);
    }
  }

}
