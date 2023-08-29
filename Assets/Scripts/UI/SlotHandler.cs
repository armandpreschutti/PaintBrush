using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SlotHandler : MonoBehaviour, IDropHandler
{
    [SerializeField] ColorCraftingHandler colorCraftingHandler;

    public enum ObjectType
    {
        FirstColorSlot,
        SecondColorSlot,
        ColorHUDSlot,
        PrimaryColorSlot,
        EquipColorSlot
    }
    public ObjectType objectType;

    private void Start()
    {
        colorCraftingHandler = GameObject.Find("CraftingBar").GetComponent<ColorCraftingHandler>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            RectTransform colorTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            colorTransform.SetParent(this.GetComponent<RectTransform>());  
            colorTransform.anchoredPosition= Vector3.zero;
            colorTransform.GetComponent<DragHandler>().SetColorPositionData();
            switch (objectType)
            {
                case ObjectType.FirstColorSlot:
                   
                    colorCraftingHandler.color1 = eventData.pointerDrag.GetComponent<Image>().color;
                    break;
                case ObjectType.SecondColorSlot:
                    colorCraftingHandler.color2 = eventData.pointerDrag.GetComponent<Image>().color;
                    break;
                case ObjectType.EquipColorSlot:
                    colorCraftingHandler.equippedColor = eventData.pointerDrag.GetComponent<Image>().color;
                    colorCraftingHandler.EquipColor();

                    break;
                default:
                    break;
            }
        }
    }
}
