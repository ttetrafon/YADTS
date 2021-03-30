using UnityEngine;
using UnityEngine.EventSystems;

// Attach this script to any UI element that needs to close when clicked on.
public class SelfCloseOnClick : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick( PointerEventData eventData ) {
		this.gameObject.SetActive( false );
	}

}
