using System.Collections;
using System.Collections.Generic;
// using Unity.Jobs;
// using Unity.Mathematics;
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
  [SerializeField] private InputField generatorNameInput;
  [SerializeField] private InputField seedInput;
  [SerializeField] private Button buldMarkovDictionariesButton;
  [SerializeField] private Toggle markovGeneration;
  [SerializeField] private Text markovGenerationLabel;

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
    nameGeneratorData = new MarkovData();

    // Listeners
    newGeneratorButton.onClick.AddListener(delegate { SetMode(Constants.nameGeneratorModeNew); });
    loadGeneratorButton.onClick.AddListener(delegate { SetMode(Constants.nameGeneratorModeLoad); });
    deleteGeneratorButton.onClick.AddListener(delegate { SetMode(Constants.nameGeneratorModeDelete); });
    confirmButton.onClick.AddListener(Confirm);
    resetButton.onClick.AddListener(Reset);
    seedInput.onEndEdit.AddListener(delegate { GetSeedWords(); });
    // buldMarkovDictionariesButton.onClick.AddListener(delegate {
    //   JobHandle jh = BuildMarkovDictionaries();
    //   jh.Complete();
    // });
    markovGeneration.onValueChanged.AddListener(delegate {
      nameGeneratorData.markovGeneration = markovGeneration.isOn;
      this.markovGenerationLabel.text = (this.markovGeneration.isOn ? "Markov Generation" : "Random Selection");
    });
  }


  ////////////////////
  ///   CONTROLS   ///
  ////////////////////
  private void SetMode(string mode) {
    Debug.Log("--> SetMode(" + mode + ")");
    this.mode = mode;
    // enable/disable controls & panels as appropriate for the selected mode
    this.resetButton.gameObject.SetActive(mode != Constants.nameGeneratorModeDelete);
    // setup the data
    if (this.mode == Constants.nameGeneratorModeNew) { // new
      nameGeneratorData = new MarkovData();
    }
    else if (this.mode == Constants.nameGeneratorModeLoad) { // load

    }
    else { // delete

    }
  }

  private void Confirm() {
    Debug.Log("--> Confirm()");
    if (this.mode == Constants.nameGeneratorModeNew) { // new

    }
    else if (this.mode == Constants.nameGeneratorModeLoad) { // load

    }
    else { // delete

    }
  }

  private void Reset() {
    Debug.Log("--> Reset()");
  }


  ////////////////
  ///   DATA   ///
  ////////////////
  private void GetSeedWords() {
    string text = this.seedInput.text;
    nameGeneratorData.namesSeed = new List<string>();
    if (!string.IsNullOrEmpty(text)) {
      string[] words = text.Split('\n');
      for (int i = 0; i < words.Length; i++) {
        nameGeneratorData.namesSeed.Add(words[i].Trim());
      }
    }
  }


  //////////////////
  ///   MARKOV   ///
  //////////////////
  // private JobHandle BuildMarkovDictionaries() {
  //   BuildMarkovDictionariesJob buildMarkovDictionariesJob = new BuildMarkovDictionariesJob();
  //   return buildMarkovDictionariesJob.Schedule();
  // }


}


// public struct BuildMarkovDictionariesJob : IJob {
//   public void Execute() {
//     float value = 0.0f;
//     for (int i = 0; i < 50000; i++) {
//       value = Mathf.Exp(i);
//     }
//   }
// }
