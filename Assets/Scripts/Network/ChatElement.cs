using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatElement : MonoBehaviour {
    [SerializeField] private TMP_Text textDisplay;
    private int count = 0;
    private string type = Constants.chatElementTypeNone;

    private void Update() {
        if (count < 3) {
            ResizeSelf();
            count++;
        }
    }

	public void ResizeSelf() {
		//Debug.Log("---> ResizeViewPanel()");
        // float x = gameObject.GetComponent<RectTransform>()
		float y = textDisplay.textBounds.size.y;
        // Debug.Log("(" + count + ") " + y);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(50, (y > 25 ? y : 25));
	}

    public void StyleSelf(string text) {

    }

}
