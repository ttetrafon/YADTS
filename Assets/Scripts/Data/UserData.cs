using System.Collections.Generic;

public class UserData  {
	public string userName = "";
	public string userRole = ""; // DM, Player, Observer
	public List<string> campaigns = new List<string>();
	public string selectedCampaign = "";

	public string lastMap = "MAP00000-TREE-ROOT-0000-000000000000";
}
