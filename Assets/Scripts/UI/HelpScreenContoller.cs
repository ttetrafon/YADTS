using UnityEngine;
using UnityEngine.UI;

public class HelpScreenContoller : MonoBehaviour {
	[SerializeField] private Button helpButton;
	[SerializeField] private GameObject helpScreen;

	private void Awake() {
		// Initialise
		helpScreen.SetActive(false);

		// Add listeners
		helpButton.onClick.AddListener(delegate {
			helpScreen.SetActive(!helpScreen.activeSelf);
		});
	}

}
