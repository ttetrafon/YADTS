using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiTooltipComponent : MonoBehaviour {
	public Image panel;
	public TextMeshProUGUI toolTipText;
	public RectTransform rect;

	private void Update() {
		if (GameController.tooltipController && this.gameObject.activeSelf) {
			PlaceTooltipInPosition();
			ResizeTooltipToMatchText();
		}
	}

	public void ShowTooltip() {
		//Debug.Log("---> ShowTooltip()");
		if (!this.gameObject.activeSelf && !string.IsNullOrEmpty(toolTipText.text)) {
			this.gameObject.SetActive(true);
		}
	}

	public void HideTooltip() {
		//Debug.Log("---> HideTooltip()");
		if (GameController.tooltipController && this.gameObject.activeSelf) {
			this.gameObject.SetActive(false);
		}
	}

	public void SetTooltipText(string uiComponentName) {
		//Debug.Log("---> SetText(" + uiComponentName + ")");
		if (Localization.tooltips["eng"].ContainsKey(uiComponentName)) {
			//Debug.Log("... game object name found :)");
			toolTipText.text = Localization.tooltips["eng"][uiComponentName];
		}
		else {
			Debug.Log("... game object name not found :(");
			toolTipText.text = "";
		}
	}

	public void ClearTooltipText() {
		//Debug.Log("---> ClearText()");
		toolTipText.text = "";
	}

	private void ResizeTooltipToMatchText() {
		//Debug.Log("---> ResizeTooltipToMatchText()");
		//float x = toolTipText.textBounds.size.x;
		float y = toolTipText.textBounds.size.y;
		//var marginsX = toolTipText.margin.x * 2;
		var marginsY = toolTipText.margin.y * 2;
		rect.sizeDelta = new Vector2(rect.sizeDelta.x, y + marginsY);
		// TODO: Adjust horizontal size also.
		// Maybe set initial size at 150 or something, and then check the horizontal bounds of the text before readjusting size.
	}

	private void PlaceTooltipInPosition() {
		//Debug.Log("---> PlaceTooltipInPosition()");
		// Vector2 tooltipPosition = MainMenu.interfaceControls.Interface.MousePosition.ReadValue<Vector2>();
		// TODO: Fix ending out of screen.
		// (1) get screen size
		// (2) get tooltip's width & height
		// (3) compare screen size with position + width/height and move to left and bottom instead of top and right
		// rect.anchoredPosition = tooltipPosition;
	}

}
