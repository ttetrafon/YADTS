using UnityEngine;
using UnityEngine.EventSystems;

public class CameraBlocker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
  // This class is added on any element that we want to block the camera movement when open and the mouse is hovering above it.

  public void OnPointerEnter(PointerEventData eventData) {
    CameraControl.cameraBlock = true;
  }

  public void OnPointerExit(PointerEventData eventData) {
    CameraControl.cameraBlock = false;
  }

  private void OnDisable() {
    CameraControl.cameraBlock = false;
  }


}
