using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDetectionHandler : MonoBehaviour
{
    
    public Color desiredColor;
    public Color currentColor;
    public bool isPainted = false;
    public GameObject swatch;
    public GameObject checkMark;
    public GameObject grass;

    public void Start()
    {
        desiredColor = swatch.GetComponent<SpriteRenderer>().color;
    }
    public void SetHouseColor(Color newColor)
    {
        
        currentColor = newColor;
        GetComponent<SpriteRenderer>().color = currentColor;
        // create variables for hue, saturation, and value of both colors
        float h1, s1, v1;
        float h2, s2, v2;

        // convert colors from RGB to HSV then output results to variables above
        Color.RGBToHSV(currentColor, out h1, out s1, out v1);
        Color.RGBToHSV(desiredColor, out h2, out s2, out v2);
        if(s1 != 0)
        {
            if (h1 == h2)
            {
                transform.DOPunchScale(new Vector3(.1f, .1f, .1f), .5f, 5, 1f);
                isPainted = true;
                checkMark.SetActive(true);
                grass.SetActive(true);
                GameObject.Find("Player").GetComponent<LocomotionHandler>().housesPainted += 1;
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
        
        
    }



}
