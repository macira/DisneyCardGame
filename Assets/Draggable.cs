using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform homeParent = null;
    public Transform placeHolderParent = null;
    public GameObject placeHolder = null;

    public enum Type { DEFAULT };
    public Type type = Type.DEFAULT;

	public void OnBeginDrag(PointerEventData eventData) {
		// Debug.Log ("OnBeginDrag");

        homeParent = this.transform.parent;
        placeHolderParent = homeParent;

        placeHolder = new GameObject();
        placeHolder.transform.SetParent(placeHolderParent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData) {
		// Debug.Log ("OnDrag");

        this.transform.position = eventData.position;

        if (placeHolder.transform.parent != placeHolderParent)
            placeHolder.transform.SetParent(placeHolderParent);

        int newSiblingIndex = placeHolderParent.childCount;
        for (int i = 0; i < placeHolderParent.childCount; i++) {
            if (this.transform.position.x < placeHolderParent.GetChild(i).position.x) {
                newSiblingIndex = i;

                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                    i--;

                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
	}

	public void OnEndDrag(PointerEventData eventData) {
		// Debug.Log ("OnEndDrag");

        this.transform.SetParent(homeParent);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeHolder);
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}
}
