using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Attach this script to a button (direct child) on a panel, so the panel is closed with a click.
// button prefab: Prefabs/UI/components/Close Panel Button
public class ClosePanelButton : MonoBehaviour {
    private Button closePanelButton;
    private void Awake() {
        this.closePanelButton = this.GetComponent<Button>();
        this.closePanelButton.onClick.AddListener(delegate {
            this.gameObject.transform.parent.gameObject.SetActive(false);
        });
    }
}
