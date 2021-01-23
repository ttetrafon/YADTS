using System.Collections.Generic;

/// <summary>
/// This calls holds all text that appears throughout the application.
/// </summary>
public class Localization {
	/// <summary>
	/// Each sub-dictionary holds the names of the components in Unity and the tooltip that will appear when the mouse moves over them based on the selected language.
	/// </summary>
	public static Dictionary<string, Dictionary<string, string>> tooltips = new Dictionary<string, Dictionary<string, string>>() {
		{"eng", new Dictionary<string, string>() {
			{"Add Common Map Info Component Button", "Add Common Info Components for this Map Type"},
			{"Add New Campaign", "Add Campaign"},
			{"Add Map Info Item Button", "Add Map Info Item"},
			{"Add Map Object Button", "Add Map Object"},
			{"Cancel Button", "Cancel"},
			{"Confirm Button", "Confirm"},
			{"Connect to Server Button", "Connect to Server"},
			{"Done Button", "Done"},
			{"Campaigns Tab", "Campaigns"},
			{"Create New Map Button", "Create Map"},
			{"Delete Map Button", "Delete Map"},
			{"Distance Tool Button", "Measure Distance"},
			{"Edit Button", "Edit"},
			{"Edit Map Button", "Edit Map"},
			{"Exit App Button", "Quit"},
			{"Front Screen Button", "Exit Session"},
			{"Help Button", "Help"},
			{"Load Map Button", "Load Map"},
			{"Main Menu Button", "Menu"},
			{"Magic Axiom Button", "Axiom: Magic"},
			{"Map Config Button", "Map Configuration"},
			{"Map Info Button", "Map Info"},
			{"Map Tools Button", "Map Tools"},
			{"Move Down Button", "Move Down"},
			{"Move Up Button", "Move Up"},
			{"Network Tab", "Network"},
			{"New Map Button", "New Map"},
			{"Refresh Map Info Button", "Refresh"},
			{"Remove Campaign Button", "Remove Campaign"},
			{"Save Map Button", "Save Map"},
			{"Social Axiom Button", "Axiom: Social"},
			{"Spirit Axiom Button", "Axiom: Spirit"},
			{"Start Campaign Button", "Start Campaign"},
			{"Start Server Button", "Start Server"},
			{"Tech Axiom Button", "Axiom: Tech"},
			{"Text Chat Button", "Text Chat"},
			{"User Tab", "User"}
		}}
	};

	public static Dictionary<string, Dictionary<string, List<string>>> dropdowns = new Dictionary<string, Dictionary<string, List<string>>>() {
		{"eng", new Dictionary<string, List<string>>() {
			{"Map Types", new List<string>() {
				"Plane of Existence",
				"Demiplane",
				"Universe",
				"Galaxy Cluster",
				"Galaxy",
				"Solar System",
				"Planet", "Settlement",
				"Building",
				"Vehicle"
			}},
			{"Text Format Choices", new List<string>() {
				"Section",
				"Sub-Section",
				"Sub-Sub-Section",
				"Paragraph",
				"List",
				"Sub-List",
				"Sub-Sub-List",
				"Numbered List",
				"Sub-Numbered List",
				"Sub-Sub-Numbered List",
				"Quote",
				"Quoter",
				"Map Link",
				"Creature Link",
				"Note",
				"Important"
			}},
			{"User Roles", new List<string>() {"DM", "Player", "Observer"}}
		}}
	};

	public static Dictionary<string, int> tmpProStyleHashes = new Dictionary<string, int>() {
		{"Section", -1779002743},
		{"Sub-Section", -1360214496},
		{"Sub-Sub-Section", -1246483255},
		{"Paragraph", -1345553650},
		{"Note", 2857104},
		{"Immportant", 371327558},
		{"List", 2656610},
		{"Sub-List", 2109943659},
		{"Sub-Sub-List", -1044468702},
		{"Numbered List", 773639072},
		{"Sub-Numbered List", -776439735},
		{"Sub-Sub-Numbered List", -1697257888},
		{"Quote", 93368250},
		{"Quoter", -1213815128},
		{"Map Link", 1014283868},
		{"Creature Link", 617108419}
	};

	public static Dictionary<string, Dictionary<string, string>> text = new Dictionary<string, Dictionary<string, string>>() {
		{"eng", new Dictionary<string, string>() {
			{"delete map confirmation text", "Are you sure you want to delete this map?\nThis action is irreversile.\nTo continue, click the Delete Map button below."}
		}}
	};

	/////////////////////
	///   FUNCTIONS   ///
	/////////////////////
	public static string GetText(string textName) {
		if (text.ContainsKey("eng") && text["eng"].ContainsKey(textName)) {
			return text["eng"][textName]; // TODO: Implement language selection...
		}
		return "Undefined text...";
	}

}
