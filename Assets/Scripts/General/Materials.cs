using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour {
    Materials instance = null;

    [SerializeField] private Material universeBlue;
    [SerializeField] private Material universeGreen;
    [SerializeField] private Material universeOrange;
    [SerializeField] private Material universeYellow;

    public void Awake() {
        if (instance == null) {
            instance = this;
        }
    }


}
