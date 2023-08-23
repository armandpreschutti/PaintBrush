using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler,IDropHandler
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    [SerializeField] CanvasGroup canvasGroup;


    private void Awake()
    {
        rectTransform= GetComponent<RectTransform>();
        canvas= GameObject.Find("Canvas").GetComponent<Canvas>();
        canvasGroup= GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.GetComponentInParent<SlotHandler>().slottedColor = Color.black;
        this.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>());
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
    public void OnDrop(PointerEventData eventData)
    {

    }
    
}
