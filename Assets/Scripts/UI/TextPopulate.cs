using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use this when proper localisation will be implemented.
// Attach on all UI elements that have text in them, so the proper language is displayed.
public class TextPopulate : MonoBehaviour {
	private void OnEnable() {
		if (this.gameObject.activeSelf) {
			this.GetComponent<Text>().text = Localization.GetText(this.gameObject.name);
		}
	}
}
