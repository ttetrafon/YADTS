using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
  public GameSystem instance = null;


  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
  private void Awake() {
    if (instance == null) {
      instance = this;
    }
  }

  private void Start() {
    // Read the game system data
    // ... name generator data
    // ... planes of existence
  }




}
