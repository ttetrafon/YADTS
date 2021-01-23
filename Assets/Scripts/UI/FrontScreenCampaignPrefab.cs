using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrontScreenCampaignPrefab : MonoBehaviour {
	// UI
	public Button launchCampaignButton;
	public Button removeCampaignButton;
	public InputField campaignNameInput;
	// Data
	private string givenName = "";

	private void Start() {
		launchCampaignButton.onClick.AddListener( delegate {
			// Set the selected campaign in userData.
			MainScreenBaseScript.userData.selectedCampaign = givenName;
			MainScreenBaseScript.SaveUserData();
			// Launch the Pen and Paper Scene.
			SceneManager.LoadScene( "Pen and Paper Scene" );
		} );
		removeCampaignButton.onClick.AddListener( delegate {
			FeedbackLine.Feedback();
			// Remove the campaign from userData.campaigns, if it exists.
			if ( MainScreenBaseScript.userData.campaigns.Contains( givenName ) ) {
				MainScreenBaseScript.userData.campaigns.Remove( givenName );
			}
			// Notify the player that the campaign link is removed only and not the actual data.
			if ( givenName != "" ) {
				FeedbackLine.Feedback( "The campaign '" + givenName + "' has been unlinked. All campaign data remain in the save folder." );
			}
			// Remove the campaign from the list in the screen.
			this.gameObject.SetActive( false );
			Destroy( this.gameObject );
		} );
		campaignNameInput.onEndEdit.AddListener( delegate {
			string newName = campaignNameInput.text;
			if ( newName == givenName ) {
				return;
			}
			// Check if the new name is valid (does not contain illegal characters and )
			if ( newName == "" ) {
				FeedbackLine.Feedback( "A campaign name cannot be empty." );
				campaignNameInput.text = givenName;
				return;
			}
			if ( MainScreenBaseScript.userData.campaigns.Contains( newName ) ) {
				FeedbackLine.Feedback( "A campaign name must be unique." );
				campaignNameInput.text = givenName;
				return;
			}
			if ( !Helper.TestVsRegex( newName, Helper.regexLegalFileSystemCharacters ) ) {
				FeedbackLine.Feedback( "A campaign name cannot contain illegal filesystem characters." );
				campaignNameInput.text = givenName;
				return;
			}
			// Add the name in userData.campaigns, and remove the old name.
			MainScreenBaseScript.userData.campaigns.Add( newName );
			if ( MainScreenBaseScript.userData.campaigns.Contains( givenName ) ) {
				MainScreenBaseScript.userData.campaigns.Remove( givenName );
			}
			// Create/Rename the campaign folder in the save folder, or do nothing if the folder already exists.
			string oldCampaignFolder = MainScreenBaseScript.userFolder + givenName;
			string newCampaignFolder = MainScreenBaseScript.userFolder + newName;
			if ( !Directory.Exists( newCampaignFolder ) ) {
				if ( Directory.Exists( oldCampaignFolder ) ) {
					Directory.Move( oldCampaignFolder, newCampaignFolder );
				}
				else {
					Directory.CreateDirectory( newCampaignFolder );
				}
			}
			MainScreenBaseScript.SaveUserData();
			// Assign the new name to this campaign.
			givenName = newName;
			// Sort the list of the campaigns alphabetically.
			Helper.SortSelector( MainScreenBaseScript.campaignsList, "firstInput" );
		} );
	}

	public void InitialiseSelf(string campaignName) {
		givenName = campaignName;
		campaignNameInput.text = campaignName;
	}

}
