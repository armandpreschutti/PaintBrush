using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDetectionHandler : MonoBehaviour
{
    [SerializeField]
    Color testColor;
    ColorCraftingHandler crafter;

    // Start is called before the first frame update
    void Start()
    {
        crafter= GetComponent<ColorCraftingHandler>();  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "House")
        {
            Debug.Log($"touching house{collision.name}");
            collision.GetComponent<SpriteRenderer>().color = crafter.colorResult;

        }
    }
}
