using System.Collections.Generic;

public class Constants {
	public static string gridTypeNone = "none";
	public static string gridTypeHex = "hex";
	public static string gridTypeSquare = "square";

	public static int gameObjectActiveNoOverride = 0;
	public static int gameObjectActiveOverrideTrue = 1;
	public static int gameObjectActiveOverrideFalse = 2;
	public static List<int> circleDivisors = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, 18, 20, 24, 30, 36, 40, 45, 60, 72, 90, 120, 180, 360 };


	public static string chatElementTypeNone = "none";
	public static string chatElementTypeSystemWarning = "warning";
	public static string chatElementTypeSystemError = "error";
	public static string chatElementTypeSystemSuccess = "success";
	public static string chatElementTypeChatMessage = "message";
	public static string chatElementTypeChatWhisper = "whisper";
	public static string chatElementTypeChatYell = "yell";
	public static string chatElementTypeLogRollSuccess = "rollSuccess";
	public static string chatElementTypeLogRollFailure = "rollFailure";


	public static string mapObjectPanelBio = "bio";
	public static string mapObjectPanelProperties = "properties";


	public static string nameGeneratorModeNew = "new";
	public static string nameGeneratorModeLoad = "load";
	public static string nameGeneratorModeDelete = "delete";

	public static string infoItemCampaign = "campaign";
	public static string infoItemCreature = "creature";
	public static string infoItemMap = "map";

	public static string panelMainMenu = "main menu";
	public static string panelMapMenu = "map menu";
	public static string panelGameSystemMenu = "game system menu";
	public static string panelUser = "user panel";
	public static string panelCampaign = "campaigns panel";
	public static string panelSettings = "settings panel";
	public static string panelNewMap = "new map panel";
	public static string panelLoadMap = "load map panel";
	public static string panelDeleteMap = "delete map panel";
	public static string panelMapInfo = "map info panel";
	public static string panelAddMapObject = "add map object panel";
	public static string panelMapConfiguration = "map configuration panel";
	public static string panelMapObject = "map object panel";
	public static string panelNameGenerator = "name generator panel";
}
