using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// The class contains all helper functions used throughout the program.
/// </summary>
public class Helper : MonoBehaviour {
	///////////////////
	///   GENERAL   ///
	///////////////////
	public static string GenerateUid() {
		String newUuid = Guid.NewGuid().ToString();
		if (GameController.dictionaries.UuidExists(newUuid)) {
			return GenerateUid();
		}
		return newUuid;
	}

	public static bool isUIActive() {
		return EventSystem.current.currentSelectedGameObject != null;
	}

	public static bool isMouseOverUI() {
		return EventSystem.current.IsPointerOverGameObject();
	}


	///////////////////////////////
	///   REGULAR EXPRESSIONS   ///
	///////////////////////////////
	public static Regex regexLegalFileSystemCharacters = new Regex( @"^[\w\s\'\,]*$" );

	public static bool TestVsRegex(string expression, Regex regex) {
		return regex.IsMatch(expression);
	}


	///////////////////////
	///   CONTAINERTS   ///
	///////////////////////
	public static void EmptyContainer(GameObject container) {
		foreach (Transform child in container.transform) {
			child.gameObject.SetActive(false);
			Destroy(child.gameObject);
		}
	}


	///////////////////
	///   SORTING   ///
	///////////////////
	public static void SortSelector(GameObject selectorParent, string method) {
		Transform parent = selectorParent.transform;
		bool isChanged = false;
		int safeBrake = 0;
		do {
			isChanged = true;
			for (int i = 0; i < (parent.childCount - 1); i++) {
				int comparison;
				switch (method) {
					case "name":
						comparison = String.Compare(parent.GetChild(i).name, parent.GetChild(i + 1).name);
						break;
					//case "initiative":
					//	int init0 = 0, init1 = 0;
					//	int.TryParse( parent.GetChild( i ).GetComponent<InitiativeSelectorScript>().initiativeScoreInput.text, out init0 );
					//	int.TryParse( parent.GetChild( i + 1 ).GetComponent<InitiativeSelectorScript>().initiativeScoreInput.text, out init1 );
					//	comparison = ( init0 < init1 ? 1 : -1 );
					//	break;
					//case "size category":
					//	int sc0 = 0, sc1 = 0;
					//	int.TryParse( parent.GetChild( i ).GetComponent<SizeCategoryScript>().indexInput.text, out sc0 );
					//	int.TryParse( parent.GetChild( i + 1 ).GetComponent<SizeCategoryScript>().indexInput.text, out sc1 );
					//	comparison = ( sc0 > sc1 ? 1 : -1 );
					//	break;
					case "firstInput":
						string fi0 = parent.GetChild(i).GetComponentsInChildren<InputField>()[0].text;
						string fi1 = parent.GetChild(i + 1).GetComponentsInChildren<InputField>()[0].text;
						comparison = String.Compare(fi0, fi1);
						break;
					case "index input":
						int ii0 = 0, ii1 = 0;
						int.TryParse(parent.GetChild(i).GetComponentsInChildren<InputField>()[0].text, out ii0);
						int.TryParse(parent.GetChild(i + 1).GetComponentsInChildren<InputField>()[0].text, out ii1);
						comparison = (ii0 > ii1 ? 1 : -1);
						break;
					case "map info item":
						int mii0 = parent.GetChild(i).GetComponent<MapInfoItem>().index;
						int mii1 = parent.GetChild(i + 1).GetComponent<MapInfoItem>().index;
						comparison = (mii0 > mii1 ? 1 : -1);
						break;
					//case "removable label":
					//	comparison = String.Compare( parent.GetChild( i ).GetComponent<RemovableLabel>().labelText.text, parent.GetChild( i + 1 ).GetComponent<RemovableLabel>().labelText.text );
					//	break;
					//case "spell like":
					//	comparison = String.Compare( parent.GetChild( i ).GetComponent<SpellLikeAbilityScript>().spellLikeLabel.text, parent.GetChild( i + 1 ).GetComponent<SpellLikeAbilityScript>().spellLikeLabel.text );
					//	break;
					//case "class sq":
					//	int csq0 = 0;
					//	csq0 = parent.GetChild( i ).GetComponent<ClassSpecialQualityScript>().level;
					//	int csq1 = 0;
					//	csq1 = parent.GetChild( i + 1 ).GetComponent<ClassSpecialQualityScript>().level;
					//	comparison = ( csq0 > csq1 ? 1 : -1 );
					//	break;
					//case "campaigns":
					//	string camp0 = parent.GetChild( i ).GetComponentsInChildren<CampaignPrefabScript>()[0].campaignNicknameDisplay.text;
					//	string camp1 = parent.GetChild( i + 1 ).GetComponentsInChildren<CampaignPrefabScript>()[0].campaignNicknameDisplay.text;
					//	comparison = String.Compare( camp0, camp1 );
					//	break;
					//case "attributes":
					//	int att0 = 0;
					//	int att1 = 0;
					//	int.TryParse( parent.GetChild( i ).GetComponent<AbilityScript>().abilityOrder.text, out att0 );
					//	int.TryParse( parent.GetChild( i + 1 ).GetComponent<AbilityScript>().abilityOrder.text, out att1 );
					//	comparison = ( att0 > att1 ? 1 : -1 );
					//	break;
					default:
						comparison = String.Compare(parent.GetChild(i).name, parent.GetChild(i + 1).name);
						break;
				}
				if (comparison > 0) {
					parent.GetChild(i).SetSiblingIndex(i + 1);
					isChanged = false;
				}
			}
			safeBrake++;
			if (safeBrake > 1000) {
				break;
			}
		} while (!isChanged);
	}


	///////////////////////
	///   FILE SYSTEM   ///
	///////////////////////
	public static void SaveFile(string filepath, string data) {
		File.WriteAllText( filepath, data, System.Text.Encoding.UTF8 );
		return;
	}

	public static string ReadFile(string filepath) {
		return File.ReadAllText(filepath, System.Text.Encoding.UTF8);
	}

	public static void SaveUserData() {
		SaveFile(GameController.baseFolder + "User.json", JsonObject.ToJson(GameController.userData));
	}

	public static void SaveCurrentMap() {
		string filename = MapController.mapDirectory + MapController.currentMapData.mapUid + ".json";
		string mapData = JsonObject.ToJson(MapController.currentMapData);
		SaveFile(filename, mapData);
		//MapController.mapTree[MapController.currentMapData.mapUid].UpdateSelf();
	}

	public static void SaveMapObject(MapObject mo, Boolean debug = false) {
		if(debug) { Debug.Log("---> SaveMapObject()"); }
		string filename = MapController.mapObjectsDirectory + mo.mapObjectData.objectType + "/" + mo.mapObjectData.objectUuid + ".json";
		if(debug) { Debug.Log("filename: " + filename); }
		string mapObjectData = JsonObject.ToJson(mo.mapObjectData, 1, debug);
		SaveFile(filename, mapObjectData);
	}


	///////////////////////
	///   UI ELEMENTS   ///
	///////////////////////
	public static void FillDropdown(Dropdown selector, List<string> values, string currentValue = "") {
		selector.ClearOptions();
		selector.AddOptions(values);
		if (currentValue != "") {
			SelectDropdownValue(selector, currentValue);
		}
	}

	public static void SelectDropdownValue(Dropdown selector, string value, bool debug = false) {
		if (debug) {
			Debug.Log("---> SelectSelectorValue(" + value + ")");
			List<string> options = new List<string>();
			for (int i = 0; i < selector.options.Count; i++) {
				options.Add(selector.options[i].text);
			}
			Debug.Log("options: " + PrintStringList(options));
			Debug.Log("found value at index: " + selector.options.FindIndex((u) => { return u.text.Contains(value); }));
		}
		selector.value = selector.options.FindIndex((u) => { return u.text.Contains(value); });
	}

	public static string ExtractUidFromDropdown(string fullName) {
		return fullName.Substring(fullName.LastIndexOf("[") + 1, 36);
	}

	public static string GetDropdownSelectedText(Dropdown selector) {
		return selector.options[selector.value].text;
	}


	/////////////////
	///   DEBUG   ///
	/////////////////
	public static string PrintStringList(List<string> list) {
		return list.Aggregate("", (x, y) => { return x + " <|> " + y; }).Substring(5);
	}

	public static string PrintIntList(List<int> list) {
		return list.Aggregate("", (x, y) => { return x.ToString() + " <|> " + y.ToString(); }).Substring(5);
	}

	public static string PrintDictionaryStringListString(Dictionary<string, List<string>> dict) {
		List<string> keys = new List<string>(dict.Keys);
		string res = "";
		for (int i = 0; i < keys.Count; i++) {
			res += (i > 0 ? " ||| ": "") + keys[i] + ": " + PrintStringList(dict[keys[i]]);
		}
		return res;
	}

	public static string PrintDictionaryStringSpatialData(Dictionary<string, MapObjectSpacialData> dict) {
		List<string> keys = new List<string>(dict.Keys);
		string res = "";
		for (int i = 0; i < keys.Count; i++) {
			res += (i > 0 ? " ||| " : "") + keys[i] + ": " + dict[keys[i]].ToString();
		}
		return res;
	}

}
