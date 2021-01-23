using UnityEngine;
using UnityEngine.UI;

public class HelpScreenContoller : MonoBehaviour {
	public Button helpButton;
	public GameObject helpScreen;

	private void Start() {
		// Initialise
		helpScreen.SetActive(false);

		// Add listeners
		helpButton.onClick.AddListener(delegate {
			helpScreen.SetActive(!helpScreen.activeSelf);
		});
	}

}
