using UnityEngine;

public class objectPlacing : MonoBehaviour {
    public static Controls controls;

    [SerializeField] private GameObject placeable;
    [SerializeField] LayerMask def;

    private void Awake() {
        controls = new Controls();
    }

    private void OnEnable() {
        controls.Common.Enable();
    }

    private void OnDisable() {
        controls.Common.Disable();
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(controls.Common.MousePosition.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, def)) {
            placeable.transform.position = hit.point;
        }
    }

}
