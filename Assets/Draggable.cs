using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public void OnBeginDrag(PointerEventData eventData) {
		Debug.Log ("OnBeginDrag");
	}

	public void OnDrag(PointerEventData eventData) {
		Debug.Log ("OnDrag");
        this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData) {
		Debug.Log ("OnEndDrag");
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}
}
