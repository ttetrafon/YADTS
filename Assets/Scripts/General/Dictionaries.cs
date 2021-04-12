using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Dictionaries class will contain hash maps between uuids (which are used as filenames and other information concerning game objects.
/// Current Dictionaries:
/// - Game Object Names
/// </summary>
public class Dictionaries {
	public Dictionary<string, string> goNames;

	////////////////////////
	///   CONSTRUCTORS   ///
	////////////////////////
	public Dictionaries() {
		this.goNames = new Dictionary<string, string>();
	}

	public Dictionaries(Dictionary<string, string> goNames) {
		this.goNames = goNames;
	}

	///////////////////
	///   GENERAL   ///
	///////////////////
	public string NameGet(string uuid) {
		//Debug.Log("---> Dictionary.NameGet(" + uuid + ")");
		if (goNames.ContainsKey(uuid)) {
			return goNames[uuid];
		}
		else {
			//Debug.LogError("NameGet: uuid not present!");
			return "unknown?";
		}
	}

	public void NameAdd(string uuid, string newName) {
		//Debug.Log("---> Dictionary.NameAdd(" + uuid + ", " + newName + ")");
		if (!goNames.ContainsKey(uuid)) {
			goNames.Add(uuid, newName);
			SaveDictionaries();
		}
		else {
			Debug.LogError("NameAdd: uuid already exists!");
		}
	}

	public void NameRemove(string uuid, bool debug = false) {
		if (debug) { Debug.Log("---> Dictionary.NameRemove(" + uuid + ")"); }
		if (goNames.ContainsKey(uuid)) {
			if (debug) { Debug.Log("NameRemove: success"); }
			goNames.Remove(uuid);
			SaveDictionaries(debug);
		}
		else {
			if (debug) { Debug.LogError("NameRemove: uuid not present!"); }
		}
	}

	public void NameUpdate(string uuid, string newName) {
		//Debug.Log("---> Dictionary.NameSet(" + uuid + ", " + newName + ")");
		if (goNames.ContainsKey(uuid)) {
			goNames[uuid] = newName;
			SaveDictionaries();
		}
		else {
			Debug.LogError("NameSet: The specified uuid does not exist in the names dictionary.");
		}
	}

	///////////////////
	///   GENERAL   ///
	///////////////////
	public bool UuidExists(string uuid) {
		return goNames.ContainsKey(uuid);
	}

	public void SaveDictionaries(bool debug = false) {
		if (debug) { Debug.Log("---> SaveDictionaries()"); }
		string filename = GameController.saveFolder + "dictionaries/dictionaries.json";
		string data = JsonObject.ToJson(this);
		Helper.SaveFile(filename, data);
	}


}
