using UnityEngine;
using TMPro;

public class TooltipUiElement : MonoBehaviour {
  [SerializeField] private TMP_Text tooltipText;

  private void OnEnable() {
    ResizeSelf();
  }

	private void ResizeSelf() {
		//Debug.Log("---> TooltipUiElement.ResizeSelf()");
    Vector2 textSize = tooltipText.GetPreferredValues(tooltipText.text);
    // Debug.Log(textSize);
    gameObject.GetComponent<RectTransform>().sizeDelta = textSize;
	}

  public void UpdateText(string text) {
    tooltipText.text = text;
    ResizeSelf();
  }

}
