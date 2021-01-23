using UnityEngine;
using UnityEngine.EventSystems;

public class CameraBlocker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

  public void OnPointerEnter(PointerEventData eventData) {
    CameraControl.cameraBlock = true;
  } // OnPointerEnter()

  public void OnPointerExit(PointerEventData eventData) {
    CameraControl.cameraBlock = false;
  } // OnPointerExit()

  private void OnDisable() {
    CameraControl.cameraBlock = false;
  }


}
