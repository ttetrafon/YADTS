using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class UiTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("UI Element; exited: " + this.gameObject.name);
		GameController.tooltipController.HideTooltip();
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("UI Element; entered: " + this.gameObject.name);
		GameController.tooltipController.SetTooltipText(this.gameObject.name);
		GameController.tooltipController.ShowTooltip();
	}

	private void OnDisable() {
		// Hide the tooltip since the element has been hidden.
		GameController.tooltipController.HideTooltip();
	}


}
