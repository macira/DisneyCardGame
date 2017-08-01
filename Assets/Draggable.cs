using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform homeParent = null;
    public enum Type { DEFAULT };
    public Type type = Type.DEFAULT;

	public void OnBeginDrag(PointerEventData eventData) {
		// Debug.Log ("OnBeginDrag");
        homeParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData) {
		// Debug.Log ("OnDrag");
        this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData) {
		// Debug.Log ("OnEndDrag");
        this.transform.SetParent(homeParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}
}
