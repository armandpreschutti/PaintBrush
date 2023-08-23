using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SlotHandler : MonoBehaviour, IDropHandler
{
    public Color slottedColor;
    private void Awake()
    {
        slottedColor = Color.black;
        slottedColor.a = 100;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            RectTransform colorTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            colorTransform.SetParent(this.GetComponent<RectTransform>());  
            colorTransform.anchoredPosition= Vector3.zero;
            slottedColor = colorTransform.GetComponent<Image>().color;
        }
    }
}
