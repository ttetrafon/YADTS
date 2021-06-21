using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapObjectMenuControls : MonoBehaviour {
  public static MapObjectMenuControls instance = null;
  [Header("Resources")]
  public static GameObject[] mapObjectPrefabsList;
  public static Dictionary<string, GameObject> mapObjectPrefabs;
  private Dictionary<string, bool> mapObjectTags = new Dictionary<string, bool>(); // Controls which tags are shown and which are not.
  private Dictionary<string, List<string>> prefabTags = new Dictionary<string, List<string>>(); // Contains a list of the tags belonging to each prefab for easy reference when selecting a prefab and toggling a tag.
  private Dictionary<string, List<string>> tagPrefabs = new Dictionary<string, List<string>>(); // Contains a list of prefabs that correspond to each tag for easy reference when toggling a tag.
  public static Dictionary<string, string> creatureNameFileDictionary;
  [SerializeField] private Toggle togglePrefab;

  [Header("Map Object Creation")]
  [SerializeField] private Button addMapObjectButton;
  [SerializeField] private Toggle newMapObjectToggle;
  [SerializeField] private Toggle existingMapObjectToggle;
  [SerializeField] private Dropdown addMapObjectSelector;
  [SerializeField] private GameObject tagsContainer;
  [SerializeField] private Text selectedPrefabsTagList;
  [SerializeField] private Button confirmAddMapObjectButton;
  [SerializeField] private Dropdown mapContainerSelector;

  [Header("Map Configuration")]
  [SerializeField] private Button mapConfigurationButton;
  [SerializeField] private Toggle gridNoneToggle;
  [SerializeField] private Toggle gridHexToggle;
  [SerializeField] private Toggle gridSquareToggle;
  [SerializeField] private InputField rotationStepVerticalInput;
  [SerializeField] private InputField rotationStepFrontInput;
  [SerializeField] private InputField rotationStepSideInput;

  /////////////////////
  ///   LIFECYCLE   ///
  /////////////////////
  private void Start() {
    if (instance == null) { instance = this; }

    //Debug.Log("===> MapObjectMenuControls Start");
    // Initiailise
    mapObjectPrefabsList = Resources.LoadAll<GameObject>("Map Objects");
    mapObjectPrefabs = new Dictionary<string, GameObject>();
    //Debug.Log("map objects loaded: " + mapObjectPrefabsList.Length);
    PopulateMapObjectDropdownAndTags();
    Helper.FillDropdown(mapContainerSelector, Localization.dropdowns["eng"]["Map Object Types"]);

    // Listeners
    //   Map Objects
    addMapObjectButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      PanelController.OpenPanel(Constants.panelAddMapObject);
    });
    addMapObjectSelector.onValueChanged.AddListener(delegate {
      //Debug.Log("---> addMapObjectSelector.onValueChanged()");
      string selectedModel = Helper.GetDropdownSelectedText(addMapObjectSelector);
      //Debug.Log("Selected: " + selectedModel);
      if (selectedModel == "-") {
        selectedPrefabsTagList.text = "";
      }
      else {
        List<string> tags = prefabTags[selectedModel];
        tags.Sort();
        selectedPrefabsTagList.text = tags.Aggregate("", (x, y) => { return x + "\n" + y; }).Substring(1);
      }
    });
    confirmAddMapObjectButton.onClick.AddListener(delegate {
      CreateNewMapObject(true);
    });
    //   Map Configuration
    mapConfigurationButton.onClick.AddListener(delegate {
      PanelController.CloseAllPanels();
      PanelController.OpenPanel(Constants.panelMapConfiguration);
    });
    gridNoneToggle.onValueChanged.AddListener(delegate {
      if (gridNoneToggle.isOn) {
        MapController.currentMapData.gridType = Constants.gridTypeNone;
        Helper.SaveCurrentMap();
      }
    });
    gridHexToggle.onValueChanged.AddListener(delegate {
      if (gridHexToggle.isOn) {
        MapController.currentMapData.gridType = Constants.gridTypeHex;
        Helper.SaveCurrentMap();
      }
    });
    gridSquareToggle.onValueChanged.AddListener(delegate {
      if (gridSquareToggle.isOn) {
        MapController.currentMapData.gridType = Constants.gridTypeSquare;
        Helper.SaveCurrentMap();
      }
    });
    rotationStepFrontInput.onEndEdit.AddListener(delegate {
        int rot = GetRotationStep(rotationStepFrontInput);
        MapController.currentMapData.rotationStepFront = rot;
        Helper.SaveCurrentMap();
    });
    rotationStepSideInput.onEndEdit.AddListener(delegate {
    int rot = GetRotationStep(rotationStepSideInput);
    MapController.currentMapData.rotationStepSide = rot;
    Helper.SaveCurrentMap();
    });
    rotationStepVerticalInput.onEndEdit.AddListener(delegate {
    int rot = GetRotationStep(rotationStepVerticalInput);
    MapController.currentMapData.rotationStepVertical = rot;
    Helper.SaveCurrentMap();
    });

    // Finalise
    GameController.loadedMapObjectMenuControls = true;
    PostLoad.FinishedInitialLoading();
  }


  /////////////////////////
  ///   CONFIGURATION   ///
  /////////////////////////
  private void PopulateMapObjectDropdownAndTags() {
    //Debug.Log("---> PopulateMapObjectDropdownAndTags()");
    addMapObjectSelector.ClearOptions();
    List<string> names = new List<string>();
    names.Add("-");
    for (int i = 0; i < mapObjectPrefabsList.Length; i++) {
      string name = mapObjectPrefabsList[i].name;
      if (!names.Contains(name)) {
        names.Add(name);
      }
      mapObjectPrefabs.Add(name, mapObjectPrefabsList[i]);
      //Debug.Log("mapObjectPrefabs: added '" + name + "' - '" + mapObjectPrefabsList[i].ToString() +  "'");
      List<string> tags = mapObjectPrefabsList[i].GetComponent<MapObject>().tags;
      tags.Sort();
      if (prefabTags.ContainsKey(name)) {
        prefabTags[name] = tags;
      }
      else {
        prefabTags.Add(name, tags);
      }
      for (int j = 0; j < tags.Count; j++) {
        string tag = tags[j];
        if (!mapObjectTags.ContainsKey(tag)) {
          //Debug.Log("... adding tag: " + tag);
          mapObjectTags.Add(tag, true);
          tagPrefabs.Add(tag, new List<string>());
          if (!tagPrefabs[tag].Contains(name)) {
            tagPrefabs[tag].Add(name);
          }
        }
        tagPrefabs[tag].Sort();
      }
    }
    names.Sort();
    List<string> tagNames = new List<string>(mapObjectTags.Keys);
    tagNames.Sort();
    //Debug.Log("names collected: " + Helper.PrintStringList(names));
    //Debug.Log("tags collected: " + Helper.PrintStringList(tagNames));
    Helper.FillDropdown(addMapObjectSelector, names);
    for (int i = 0; i < tagNames.Count; i++) {
      Toggle to = Instantiate(togglePrefab, tagsContainer.transform);
      to.name = tagNames[i];
      to.onValueChanged.AddListener(delegate {
        FilterModels(to);
      });
      to.GetComponentInChildren<Text>().text = tagNames[i];
    }
    //Debug.Log("prefabTags: " + Helper.PrintDictionaryStringListString(prefabTags));
    //Debug.Log("tagPrefabs: " + Helper.PrintDictionaryStringListString(tagPrefabs));
  }

  private void FilterModels(Toggle to) {
    //Debug.Log("---> FilterModels()");
    mapObjectTags[to.gameObject.name] = to.isOn;
    List<string> prefabs = new List<string>(prefabTags.Keys);
    List<string> selectorOptions = new List<string>() { "-" };
    for (int i = 0; i < prefabs.Count; i++) {
      string prefab = prefabs[i];
      List<string> tags = prefabTags[prefab];
      for (int j = 0; j < tags.Count; j++) {
        if (mapObjectTags[tags[j]]) {
          selectorOptions.Add(prefab);
          break;
        }
      }
    }
    addMapObjectSelector.ClearOptions();
    Helper.FillDropdown(addMapObjectSelector, selectorOptions);
  }

  public static void SetMapConfigurationOptions() {
    // Debug.Log("---> SetMapConfigurationOptions()");
    // Grid Type
    instance.gridNoneToggle.isOn = MapController.currentMapData.gridType == Constants.gridTypeNone;
    instance.gridHexToggle.isOn = MapController.currentMapData.gridType == Constants.gridTypeHex;
    instance.gridSquareToggle.isOn = MapController.currentMapData.gridType == Constants.gridTypeSquare;
    // Rotation angle steps
    instance.rotationStepFrontInput.text = MapController.currentMapData.rotationStepFront.ToString();
    instance.rotationStepSideInput.text = MapController.currentMapData.rotationStepSide.ToString();
    instance.rotationStepVerticalInput.text = MapController.currentMapData.rotationStepVertical.ToString();
  }


  ///////////////////////////////
  ///   MAP OBJECT CREATION   ///
  ///////////////////////////////
  private void CreateNewMapObject(bool debug = false) {
    if (debug) { Debug.Log("---> CreateNewMapObject()"); }

    // prepare
    string selectedPrefabName = Helper.GetDropdownSelectedText(addMapObjectSelector);
    if (debug) { Debug.Log("... " + selectedPrefabName); }
    if (selectedPrefabName == "-") {
      return;
    }
    string moType = Helper.GetDropdownSelectedText(mapContainerSelector);

    // instantiate the map object
    GameObject newMapObject = mapObjectPrefabs[selectedPrefabName];
    string uid = Helper.GenerateUid();
    GameController.dictionaries.NameAdd(uid, selectedPrefabName);
    GameObject go = Instantiate(newMapObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
    go.name = uid;

    // assign properties & values
    MapObject mo = go.GetComponent<MapObject>();
    mo.mapObjectData.objectUuid = uid;
    mo.mapObjectData.objectName = selectedPrefabName;
    mo.mapObjectData.prefabName = selectedPrefabName;
    mo.mapObjectData.objectType = moType;
    Debug.Log(go.transform.localScale);
    mo.UpdateSpacialData();
    MapController.currentMapData.AddMapObjectInMap(uid, moType);
    Helper.SaveCurrentMap();
    Helper.SaveMapObject(mo);
    PanelController.CloseAllPanels();
  }


  ///////////////////////////////
  ///   MAP OBJECT MOVEMENT   ///
  ///////////////////////////////
  private int GetRotationStep(InputField input) {
    // Debug.Log("---> GetRotationStep()");
    int rot = 0;
    int.TryParse(input.text, out rot);
    // Debug.Log("got " + rot);
    if (!Constants.circleDivisors.Contains(rot)) {
      List<int> distances = new List<int>(Constants.circleDivisors.Select(x => Mathf.Abs(rot - x)));
      // Debug.Log("distances: " + Helper.PrintIntList(distances));
      int min = distances.Min();
      // Debug.Log("min distance: " + min);
      int pos = distances.FindIndex(elem => elem == min);
      // Debug.Log("min position: " + pos);
      rot = Constants.circleDivisors[pos];
      input.text = rot.ToString();
    }
    return rot;
  }

}
