﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Draggable.Type type = Draggable.Type.DEFAULT;
    public bool usePlaceHolder = true;

    public void OnPointerEnter(PointerEventData eventData) {
        // Debug.Log ("OnPointerEnter to " + gameObject.name);

        if (eventData.pointerDrag == null) return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            /* Only accept draggables of filtered type but let DEFAULT drop zones accept all */
            if (d.type == this.type || this.type == Draggable.Type.DEFAULT)
                d.placeHolderParent = usePlaceHolder ? this.transform : null;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        // Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        if (eventData.pointerDrag == null) return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && (d.placeHolderParent == null || d.placeHolderParent == this.transform)) {
            /* Only accept draggables of filtered type but let DEFAULT drop zones accept all */
            if (d.type == this.type || this.type == Draggable.Type.DEFAULT)
                d.homeParent = this.transform;
                d.homeIndex = usePlaceHolder ? d.transform.GetSiblingIndex() : this.transform.childCount;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        // Debug.Log ("OnPointerExit to " + gameObject.name);

        if (eventData.pointerDrag == null) return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            /* Only accept draggables of filtered type but let DEFAULT drop zones accept all */
            if (d.type == this.type || this.type == Draggable.Type.DEFAULT)
                d.placeHolderParent = null;
        }
    }
}
