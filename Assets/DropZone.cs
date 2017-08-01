using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Draggable.Type type = Draggable.Type.DEFAULT;

    public void OnPointerEnter(PointerEventData eventData) {
        // Debug.Log ("OnPointerEnter to " + gameObject.name);
    }

    public void OnDrop(PointerEventData eventData) {
        // Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            /* Only accept draggables of filtered type but let DEFAULT drop zones accept all */
            if (d.type == this.type || this.type == Draggable.Type.DEFAULT)
                d.homeParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        // Debug.Log ("OnPointerExit to " + gameObject.name);
    }
}
