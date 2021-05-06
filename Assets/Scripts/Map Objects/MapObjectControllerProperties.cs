using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObjectControllerProperties : MonoBehaviour {
  public static MapObjectControllerProperties instance = null;

  [Header("Materials")]
  [SerializeField] private GameObject materialList;
  [SerializeField] private Dropdown dropdownPrefab;
  // private List<Dropdown> materialSelectors;


  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
  private void Awake() {
    if (instance == null) {
      instance = this;
    }
  }

  private void OnEnable() {
    CleanPropertiesPanel();
    PopulatePropertiesPanel();
  }

  public static void CleanPropertiesPanel() {
    Debug.Log("---> CleanPropertiesPanel()");
    // materials
    // instance.materialSelectors = new List<Dropdown>();
    for (int i = instance.materialList.transform.childCount; i > 0; i--) {
      Destroy(instance.materialList.transform.GetChild(i).gameObject);
    }
  }

  public static void PopulatePropertiesPanel() {
    Debug.Log("---> PopulatePropertiesPanel()");
    if (MapObjectController.selectedMapObject != null) {
      // materials
      List<string> mats = MapObjectController.selectedMapObject.mapObjectData.materials;
      List<string> materialNames = Materials.GetMaterialNames();
      for (int i = 0; i < mats.Count; i++) {
        int k = i;
        Dropdown mat = Instantiate(instance.dropdownPrefab, instance.materialList.transform);
        Helper.FillDropdown(mat, materialNames, mats[k]);
        mat.onValueChanged.AddListener(delegate {
          string selectedMaterial = Helper.GetDropdownSelectedText(mat);
          Debug.Log("selected materials: " + selectedMaterial);
          MapObjectController.selectedMapObject.UpdateMaterial(k, selectedMaterial);
        });
      }
    }
  }

}
