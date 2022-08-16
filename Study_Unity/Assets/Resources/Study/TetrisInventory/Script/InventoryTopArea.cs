using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTopArea : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    Canvas canvas;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    private void Awake() {
        canvasGroup = transform.parent.GetComponent<CanvasGroup>();
        rectTransform = transform.parent.GetComponent<RectTransform>();
    }

    private void Start() {
        canvas = transform.parent.parent.GetComponent<Canvas>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.parent.GetComponent<Inventory>().Position = transform.parent.GetComponent<RectTransform>().position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnDrop(PointerEventData eventData)
    {

    }
}
