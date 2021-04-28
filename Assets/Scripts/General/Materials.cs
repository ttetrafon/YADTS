using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour {
    Materials instance = null;

	[Header("Meta")]
    [SerializeField] private Material selectionSphereBlue;
    [SerializeField] private Material selectionSphereGreen;
    [SerializeField] private Material selectionSphereOrange;
    [SerializeField] private Material selectionSphereRed;

	[Header("Cosmos")]
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
