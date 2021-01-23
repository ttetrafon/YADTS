using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopulate : MonoBehaviour {
	private void OnEnable() {
		if (this.gameObject.activeSelf) {
			this.GetComponent<Text>().text = Localization.GetText(this.gameObject.name);
		}
	}
}
