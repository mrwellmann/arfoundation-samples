using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.gameObject.transform.IsChildOf(gameObject.transform))
        {
            //transform relative to object
            //rectTransform.Translate(eventData.delta / canvas.scaleFactor *2, Space.Self);

            //transform relative to the camera
            var transformation = eventData.delta / canvas.scaleFactor * 2;
            Vector3 cameraUp = Camera.main.transform.up;
            Vector3 cameraRight = Camera.main.transform.right;
            transform.Translate(cameraUp * transformation.y, Space.World);
            transform.Translate(cameraRight * transformation.x, Space.World);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}