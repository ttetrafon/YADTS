using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The system will use Markov chains to create new, randomised names that look and sound like normal names.
// (1) Input a name list for a culture.
// (2) Create the dictionary and the rules.
//      (i) next letters list (by frequency), of order 1, 2, 3, or more
//      (ii) median length and length variance
//      (iii) usual starting and ending letters
// (3) Apply the rules in the dictionary to create names.
public class NameGenerator : MonoBehaviour {
  public static NameGenerator instance = null;

  [Header("UI")]
  [SerializeField] private Button deleteGeneratorButton;
  [SerializeField] private Button loadGeneratorButton;
  [SerializeField] private Button newGeneratorButton;
  [SerializeField] private Button resetButton;
  [SerializeField] private Button confirmButton;

  [Header("Controls")]
  private string mode;
  public static MarkovData nameGeneratorData;

  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
  private void Awake() {
    if (instance == null) {
      instance = this;
    }
  }

  private void Start() {
    // initial setup
    this.mode = Constants.nameGeneratorModeLoad;

    // Listeners
    newGeneratorButton.onClick.AddListener(delegate { SetMode(Constants.nameGeneratorModeNew); });
    loadGeneratorButton.onClick.AddListener(delegate { SetMode(Constants.nameGeneratorModeLoad); });
    deleteGeneratorButton.onClick.AddListener(delegate { SetMode(Constants.nameGeneratorModeDelete); });
    confirmButton.onClick.AddListener(Confirm);
    resetButton.onClick.AddListener(Reset);
  }


  ////////////////////
  ///   CONTROLS   ///
  ////////////////////
  private void SetMode(string mode) {
    Debug.Log("--> SetMode(" + mode + ")");
    this.mode = mode;
    // enable/disable controls & panels as appropriate for the selected mode
    this.resetButton.gameObject.SetActive(mode != Constants.nameGeneratorModeDelete);
  }

  private void Confirm() {
    Debug.Log("--> Confirm()");
  }

  private void Reset() {
    Debug.Log("--> Reset()");
  }


  ////////////////
  ///   DATA   ///
  ////////////////



  //////////////////
  ///   MARKOV   ///
  //////////////////



}
