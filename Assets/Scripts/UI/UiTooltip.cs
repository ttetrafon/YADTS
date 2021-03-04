using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class UiTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


	public void OnPointerEnter(PointerEventData eventData) {
		// Debug.Log("UI Element; entered: " + this.gameObject.name);
		TooltipController.ShowTooltip(this.gameObject.name);
	}

	public void OnPointerExit(PointerEventData eventData) {
		// Debug.Log("UI Element; exited: " + this.gameObject.name);
		TooltipController.HideTooltip();
	}

	private void OnDisable() {
		// Hide the tooltip since the element has been hidden.
		TooltipController.HideTooltip();
	}


}
