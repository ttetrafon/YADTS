﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour {
  public static GameController instance = null;
  public static bool initiationFinished = false;
  // Cameras and viewports
  public static CameraControl activeCamera = null;
  // Tooltips
  public static UiTooltipComponent tooltipController;
  // Mouse
  [Header("Mouse Cursor")]
  [SerializeField] private Texture2D mouseCursorDistance;
  // File System
  public static string baseFolder;
  public static string saveFolder;
  public static string backupFolder;
  // General Game Data
  public static Dictionaries dictionaries = new Dictionaries();
  public static MapHierarchy mapHierarchy = new MapHierarchy();
  // Current User
  public static UserData userData = new UserData();
  public static Options options = new Options();
  // Loading Checks
  public static Boolean campaignLoaded = false;
  public static Boolean loadedGameController = false;
  public static Boolean loadedMapController = false;
  public static Boolean loadedMainMenu = false;
  public static Boolean loadedMapObjectMenuControls = false;

  private void Awake() {
    //Debug.Log("===> GameController Start");
    if (instance == null) { instance = this; }
    // TODO: loading screen starts

    // Set References and hide non-required elements.
    activeCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();

    // Load the UserData and Options
    baseFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal).Replace('\\', '/') + "/.YADTS/";
    string userFile = baseFolder + "user.json";
    //Debug.Log( userFile );
    if (File.Exists(userFile)) {
      userData = (UserData)JsonObject.FromJson(new UserData(), Helper.ReadFile(userFile));
    }
    else {
      // TODO: Create user file instead of exiting.
      Application.Quit();
    }
    campaignLoaded = !String.IsNullOrEmpty(userData.selectedCampaign);
    if (campaignLoaded) {
      CampaignManager.SetCampaignFolders();
    }
  }

  private void Start() {
    //Debug.Log("===> GameController Start");
    CampaignManager.StartCampaignData();
    loadedGameController = true;
    PostLoad.FinishedInitialLoading();
  }


  ////////////////////////
  ///   MOUSE CURSOR   ///
  ////////////////////////
  public static void ChangeCursor(string option = "") {
    // Controls the image used by the cursor.
    if (option == "distance") {
      Cursor.SetCursor(instance.mouseCursorDistance, Vector2.zero, CursorMode.Auto);
    }
    else {
      Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
  }


}
