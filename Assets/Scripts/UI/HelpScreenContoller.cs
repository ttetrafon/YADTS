using UnityEngine;
using UnityEngine.UI;

public class HelpScreenContoller : MonoBehaviour {
  [SerializeField] private Button helpButton;
  [SerializeField] private GameObject helpScreen;
  [SerializeField] private Text versionDisplay;

  private void Awake() {
    // Initialise data
    versionDisplay.text = "Version " + Application.version;

    // Add listeners
    helpButton.onClick.AddListener(delegate {
      helpScreen.SetActive(!helpScreen.activeSelf);
    });

    // Finalise
    helpScreen.SetActive(false);
  }

}
