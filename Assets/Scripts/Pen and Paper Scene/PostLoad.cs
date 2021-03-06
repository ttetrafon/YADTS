﻿using UnityEngine;

public class PostLoad : MonoBehaviour {

	public static void FinishedInitialLoading() {
		//Debug.Log("---> FinishedInitialLoading()");
    if (GameController.campaignLoaded) {
      if (!GameController.loadedGameController
          || !GameController.loadedMapController
          || !GameController.loadedMainMenu
          || !GameController.loadedMapObjectMenuControls) {
        //Debug.Log("... not ready yet!");
        return;
      }
      //Debug.Log("... proceed!");
      // Do extra stuff after initial loading.
      // TODO: ... load the last selected map
      LoadMapScript.LoadMap(GameController.userData.lastMap);
      // TODO: ... hide Loading Screen

      GameController.initiationFinished = true;
    }
    else {
      PanelController.OpenPanel(Constants.panelCampaign);
      CampaignManager.EnableControls(false);
      // Display message that no campaign has been loaded!
    }
	}


}
