using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorCraftingHandler : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public Color colorResult;
    public float hue1;
    public float hue2;
    public float hueDistance;
    public float halfDistance;
    public float finalHue;
    [SerializeField] GameObject colorObject;
    public Color equippedColor;
    public GameObject player;
    public GameObject hudColor;

    public void Update()
    {
        
    }
    public void MixColor()
    { 
        // create variables for hue, saturation, and value of both colors
        float h1, s1, v1;
        float h2, s2, v2;

        // convert colors from RGB to HSV then output results to variables above
        Color.RGBToHSV(color1, out h1, out s1, out v1);
        Color.RGBToHSV(color2, out h2, out s2, out v2);

        // check and set highest hue to be first, then lowest hue to be second
        if(h1 < h2)
        {
            hue1 = h2 * 360;
            hue2 = h1 * 360;
        }
        else
        {
            hue1 = h1 * 360;
            hue2 = h2 * 360;
        }

        // calculate distance between both colors
        hueDistance = Mathf.Abs(hue1 - hue2);
        
        // determine mix direction based on hue distance
        if(hueDistance > 179)
        {
            float newDistance = hue2 + 360f - hue1;
            newDistance /= 2;
            Debug.Log(newDistance);
          
            if(hue1+newDistance > 359)
            {
                finalHue = hue2 - newDistance;
            }
            else
            {
                finalHue = hue1+ newDistance;
            }
        }
        else
        {
            finalHue = hue1 + hue2;
            finalHue /= 2;
        }

        finalHue /= 360;
        colorResult = Color.HSVToRGB(finalHue, .90f, .95f);
        GameObject newColorObject =  Instantiate(colorObject);
        newColorObject.GetComponent<DragHandler>().GetComponent<RectTransform>().SetParent(GameObject.Find("Slot1").GetComponent<RectTransform>());
        newColorObject.GetComponent<RectTransform>().anchoredPosition= new Vector2(0, 0);
        newColorObject.GetComponent<Image>().color = colorResult;
        colorResult = Color.HSVToRGB(0, 0, 0);
    }
    
    public void CreateRandomColor()
    {

        colorResult = Color.HSVToRGB(Random.Range(0f, 1f), .90f, .95f);
    }
    public void EquipColor()
    {
        player.GetComponent<LocomotionHandler>().currentColor = equippedColor;
        hudColor.GetComponent<Image>().color = equippedColor;
    }
    


}

