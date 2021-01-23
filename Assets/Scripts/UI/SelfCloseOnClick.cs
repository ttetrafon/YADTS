using UnityEngine;
using UnityEngine.EventSystems;

public class SelfCloseOnClick : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick( PointerEventData eventData ) {
		this.gameObject.SetActive( false );
	}

}
