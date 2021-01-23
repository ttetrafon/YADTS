using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditSwitchOnClick : MonoBehaviour, IPointerClickHandler {
	public GameObject alternateObject;

	public void OnPointerClick(PointerEventData eventData) {
		this.gameObject.SetActive(false);
		alternateObject.SetActive(true);
		SetCurrentValue(GetCurrentValue());
	}

	private string GetCurrentValue() {
		Text label = this.GetComponent<Text>();
		if (label) {
			return label.text;
		}
		return "";
	}

	private void SetCurrentValue(string value) {
		InputField inputField = alternateObject.GetComponent<InputField>();
		if (inputField) {
			inputField.text = value;
		}
	}

}
