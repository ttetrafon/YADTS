using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour {
    public static TooltipController instance;
    [SerializeField] private GameObject tooltipUiElement;
    [SerializeField] private GameObject tooltipMapObjectElement;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
    }

    public static void ShowUiTooltip(string elementName) {
        if (Localization.tooltips["eng"].ContainsKey(elementName)) {
            instance.tooltipUiElement.GetComponent<TooltipUiElement>().UpdateText(Localization.tooltips["eng"][elementName]);
            instance.tooltipUiElement.gameObject.SetActive(true);
        }
    }

    public static void HideUiTooltip() {
        if (instance.tooltipUiElement.gameObject != null) {
            instance.tooltipUiElement.gameObject.SetActive(false);
        }
    }


    public static void ShowMoTooltip(string name) {
        instance.tooltipMapObjectElement.GetComponent<TooltipMapObjectElement>().UpdateText(name);
        instance.tooltipMapObjectElement.gameObject.SetActive(true);
    }

    public static void HideMoTooltip() {
        if (instance.tooltipMapObjectElement != null) {
            instance.tooltipMapObjectElement.gameObject.SetActive(false);
        }
    }


}
