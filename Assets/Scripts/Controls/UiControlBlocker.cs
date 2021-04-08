using UnityEngine;
using UnityEngine.EventSystems;

// This script should be attached on all UI containers so that UI functionality will be resumed and suspended as needed when the mouse moves over them!
public class UiControlBlocker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

  public void OnPointerEnter(PointerEventData eventData) {
    // switch to UI controls if the pointer enters the panel
    InputController.SwitchControlsMode("UI");
  }

  public void OnPointerExit(PointerEventData eventData) {
    // revert to map mode controls if the pointer exits the panel
    InputController.SwitchControlsMode("MapMode");
  }

  private void OnEnable() {
    // TODO: switch to UI controls if the pointer already in the panel
    // get panels' bounding box on screen
    // calculate the panel's actual on screen position & area
    // get mouse position
    // check if mouse is within the panel's area
  }

  private void OnDisable() {
    // revert to map mode controls if the panel is closed
    InputController.SwitchControlsMode("MapMode");
  }

}
