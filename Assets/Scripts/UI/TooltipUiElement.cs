using UnityEngine;
using TMPro;

public class TooltipUiElement : MonoBehaviour {
  [SerializeField] private TMP_Text tooltipText;
  private Vector2 screenSize;
  private Vector2 textSize;
  private Vector2 standardOffset = new Vector2(10, 0);

  private void OnEnable() {
    ResizeSelf();
    screenSize = new Vector2 (Screen.width, Screen.height);
  }

  private void LateUpdate() {
    Vector2 pos = InputController.controls.Common.MousePosition.ReadValue<Vector2>() + standardOffset;
    // Debug.Log("mouse position: " + pos.ToString());
    // Debug.Log("screen size: " + screenSize.ToString());
    // Debug.Log("text size: " + textSize.ToString());
    if (pos.x + textSize.x > screenSize.x) {
      pos.x -= (textSize.x + standardOffset.x);
    }
    if (pos.y + textSize.y > screenSize.y) {
      pos.y -= 2 * (textSize.y + standardOffset.y);
    }
    // Debug.Log("tooltip size: " + gameObject.GetComponent<RectTransform>().sizeDelta);
    this.gameObject.transform.position = pos;
  }

	private void ResizeSelf() {
		//Debug.Log("---> TooltipUiElement.ResizeSelf()");
    textSize = tooltipText.GetPreferredValues(tooltipText.text);
    // Debug.Log(textSize);
    gameObject.GetComponent<RectTransform>().sizeDelta = textSize;
	}

  public void UpdateText(string text) {
    tooltipText.text = text;
    ResizeSelf();
  }

}
