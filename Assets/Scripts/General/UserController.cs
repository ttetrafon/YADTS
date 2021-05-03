using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour {
  // Username
  [SerializeField] private InputField usernameInput;

  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
  private void Awake() {

    // Listeners
    usernameInput.onEndEdit.AddListener(delegate {
      string newUsername = usernameInput.text;
      Debug.Log("new username: " + newUsername);
      if (newUsername != GameController.userData.userName) {
        Helper.SaveUserData();
      }
    });
  }

  private void OnEnable() {
    // Date Assignments
    usernameInput.text = GameController.userData.userName;
  }

}
