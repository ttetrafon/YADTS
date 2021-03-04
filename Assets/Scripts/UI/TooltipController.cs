using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour {
    public static TooltipController instance;
    [SerializeField] private GameObject tooptipUiElement;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
    }

    public static void ShowTooltip(string elementName) {
        if (Localization.tooltips["eng"].ContainsKey(elementName)) {
            instance.tooptipUiElement.GetComponent<TooltipUiElement>().UpdateText(Localization.tooltips["eng"][elementName]);
            instance.tooptipUiElement.gameObject.SetActive(true);
        }
    }

    public static void HideTooltip() {
        if (instance.tooptipUiElement.gameObject != null) {
            instance.tooptipUiElement.gameObject.SetActive(false);
        }
    }

}
