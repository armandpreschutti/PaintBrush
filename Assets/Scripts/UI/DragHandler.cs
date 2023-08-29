using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler,IDropHandler
{
    [SerializeField] ColorCraftingHandler colorCraftingHandler;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] public RectTransform originalParent;
    [SerializeField] Vector2 originalPosition = new Vector2(0f,0f);
    

    private void Start()
    {
        SetComponents();
        SetColorPositionData();
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GetComponentInParent<SlotHandler>().objectType == SlotHandler.ObjectType.FirstColorSlot)
        {
            Debug.Log("Succes");
            colorCraftingHandler.color1 = Color.HSVToRGB(0, 0, 100);
        }
        if (GetComponentInParent<SlotHandler>().objectType == SlotHandler.ObjectType.SecondColorSlot)
        {
            Debug.Log("Succes");
            colorCraftingHandler.color2 = Color.HSVToRGB(0, 0, 100);
        }
        if (GetComponentInParent<SlotHandler>().objectType == SlotHandler.ObjectType.EquipColorSlot)
        {
            
            colorCraftingHandler.equippedColor = Color.HSVToRGB(0, 0, 100);
            colorCraftingHandler.EquipColor();
        }

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
        if(GetComponentInParent<RectTransform>().parent.name == "Canvas")
        {
            rectTransform.SetParent(originalParent);
            rectTransform.anchoredPosition = originalPosition;
        }
        
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
    public void OnDrop(PointerEventData eventData)
    {

    }
    public void SetColorPositionData()
    {
        originalParent = rectTransform.parent.GetComponent<RectTransform>();
        originalPosition = new Vector2(0,0);
    }
    public void SetComponents()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        colorCraftingHandler = GameObject.Find("CraftingBar").GetComponent<ColorCraftingHandler>();
    }
}
