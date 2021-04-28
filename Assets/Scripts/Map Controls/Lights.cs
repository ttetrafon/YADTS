using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {
    Lights instance = null;

    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject globalVolume;


    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
}
