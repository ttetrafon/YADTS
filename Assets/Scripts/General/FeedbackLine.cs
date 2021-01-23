using UnityEngine;
using UnityEngine.UI;

public class FeedbackLine : MonoBehaviour {
	protected static GameObject feedbackLine;
	protected static Text feedbackText;

	private void Start() {
		feedbackLine = GameObject.FindGameObjectWithTag( "Feedback Line" );
		feedbackText = GameObject.FindGameObjectWithTag( "Feedback Line Text" ).GetComponentInChildren<Text>();
		Feedback();
	}

	public static void Feedback(string message = "") {
		feedbackText.text = message;
		feedbackLine.gameObject.SetActive( !( message.Length == 0 ) );
	}

}
