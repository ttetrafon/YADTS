using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour {
  public static Materials instance = null;

  [Header("Materials")]
  [SerializeField] private Material checkerPattern;
  [SerializeField] private Material checkerPatternSelected;
  [SerializeField] private Material universePlaneOfExistenceBlue;
  [SerializeField] private Material universePlaneOfExistenceBlueSelected;
  [SerializeField] private Material universePlaneOfExistenceGreen;
  [SerializeField] private Material universePlaneOfExistenceGreenSelected;
  [SerializeField] private Material universePlaneOfExistenceOrange;
  [SerializeField] private Material universePlaneOfExistenceOrangeSelected;
  [SerializeField] private Material universePlaneOfExistenceYellow;
  [SerializeField] private Material universePlaneOfExistenceYellowSelected;

  [Header("Structures")]
  public static Dictionary<string, List<Material>> materialsDictionary;

  public void Awake() {
    if (instance == null) {
      instance = this;
    }
    materialsDictionary = new Dictionary<string, List<Material>>() {
      {"universePlaneOfExistenceBlue", new List<Material>() { universePlaneOfExistenceBlue, universePlaneOfExistenceBlueSelected }},
      {"universePlaneOfExistenceGreen", new List<Material>() { universePlaneOfExistenceGreen, universePlaneOfExistenceGreenSelected }},
      {"universePlaneOfExistenceOrange", new List<Material>() { universePlaneOfExistenceOrange, universePlaneOfExistenceOrangeSelected }},
      {"universePlaneOfExistenceYellow", new List<Material>() { universePlaneOfExistenceYellow, universePlaneOfExistenceYellowSelected }}
    };
  }


  ///////////////////
  ///   METHODS   ///
  ///////////////////
  public static List<string> GetMaterialNames() {
    return new List<string>(materialsDictionary.Keys);
  }

}
