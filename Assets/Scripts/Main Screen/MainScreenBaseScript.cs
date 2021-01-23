using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenBaseScript : MonoBehaviour {
	// Data
	public static UserData userData;
	public static string userFolder;
	public static string userDataFile;
	// User
	private Button userTab;
	private GameObject userContainer;
	private InputField userNameInput;
	private Dropdown userRoleSelector;
	// Campaigns
	private Button campaignsTab;
	private GameObject campaignsContainer;
	private Button addNewCampaign;
	public static GameObject campaignsList;
	private GameObject campaignPrefab;
	// Network
	private Button networkingTab;
	// General
	private Button exitButton;

	private void Start() {
		// Assign UI elements.
		userTab = GameObject.FindGameObjectWithTag("User Tab").GetComponentInChildren<Button>();
		campaignsTab = GameObject.FindGameObjectWithTag("Campaigns Tab").GetComponentInChildren<Button>();
		networkingTab = GameObject.FindGameObjectWithTag("Network Tab").GetComponentInChildren<Button>();
		exitButton = GameObject.FindGameObjectWithTag("Exit Button").GetComponentInChildren<Button>();
		userContainer = GameObject.FindGameObjectWithTag("Front Screen - User Container");
		userNameInput = GameObject.FindGameObjectWithTag("Front Screen - UserName Input").GetComponentInChildren<InputField>();
		userRoleSelector = GameObject.FindGameObjectWithTag("Front Screen - UserRole Selector").GetComponentInChildren<Dropdown>();
		campaignsContainer = GameObject.FindGameObjectWithTag("Front Screen - Campaigns Container");
		addNewCampaign = GameObject.FindGameObjectWithTag( "Add New Campaign Button" ).GetComponentInChildren<Button>();
		campaignsList = GameObject.FindGameObjectWithTag("Front Screen - Campaigns List");
		campaignPrefab = Resources.Load<GameObject>("UI/Front Screen Campaign Prefab");

		// Hide not initially visible elements.
		userContainer.gameObject.SetActive(false);
		campaignsContainer.gameObject.SetActive(false);

		// Load data
		userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/.YADTS/";
		userDataFile = userFolder + "User.json";
		userData = new UserData();
		if (File.Exists(userDataFile)) {
			userData = (UserData)JsonObject.FromJson(new UserData(), Helper.ReadFile(userDataFile));
		}
		else {
			Helper.SaveFile(userDataFile, JsonObject.ToJson(userData));
		}
		userNameInput.text = userData.userName;
		Helper.FillDropdown(userRoleSelector, Localization.dropdowns["eng"]["User Roles"], userData.userRole);
		Helper.SelectDropdownValue(userRoleSelector, userData.userRole);
		for ( int i = 0; i < userData.campaigns.Count; i++ ) {
			GameObject existingCampaign = Instantiate( campaignPrefab, campaignsList.transform );
			existingCampaign.GetComponent<FrontScreenCampaignPrefab>().InitialiseSelf( userData.campaigns[i] );
		}

		// User controls
		userTab.onClick.AddListener( delegate {
			ToggleUser();
		} );
		userNameInput.onEndEdit.AddListener( delegate {
			FeedbackLine.Feedback();
			string newUserName = userNameInput.text;
			if (newUserName == "") {
				FeedbackLine.Feedback("Your username cannot be blank.");
			}
			userData.userName = newUserName;
			SaveUserData();
		} );
		userRoleSelector.onValueChanged.AddListener( delegate {
			userData.userRole = userRoleSelector.options[userRoleSelector.value].text;
			Debug.Log("userRole: " + userData.userRole);
			SaveUserData();
		} );

		// Campaigns controls
		campaignsTab.onClick.AddListener( delegate {
			ToggleCampaigns();
		} );
		addNewCampaign.onClick.AddListener( delegate {
			Instantiate( campaignPrefab, campaignsList.transform );
		} );

		// Network controls
		networkingTab.onClick.AddListener( delegate {
		} );

		// General
		exitButton.onClick.AddListener( delegate {
			Application.Quit();
		} );
	}

	private void ToggleUser() {
		userContainer.SetActive( !userContainer.activeSelf );
		campaignsContainer.SetActive( false );
	}

	private void ToggleCampaigns() {
		campaignsContainer.SetActive( !campaignsContainer.activeSelf );
		userContainer.SetActive( false );
	}

	public static void SaveUserData() {
		Helper.SaveFile( userDataFile, JsonObject.ToJson( userData ) );
	}

}
