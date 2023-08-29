using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class LocomotionHandler : MonoBehaviour
{

    public PlayerInput playerInput;
    public GameObject targetHouse;
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;
    public Color currentColor = Color.HSVToRGB(0, 0, 100);
    public int housesPainted;
    public GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerInput= GetComponent<PlayerInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerInput.moveDirection.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("xInput", playerInput.moveDirection.x);
            anim.SetFloat("yInput", playerInput.moveDirection.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (housesPainted == 8)
        {
            gameOverPanel.SetActive(true);
        }
    }
    /// <summary>
    /// Once every .02 seconds, this function is called
    /// </summary>
    public void FixedUpdate()
    {
        rb.velocity= playerInput.moveDirection * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "House")
        {
            Debug.Log($"touching house{collision.name}");
            targetHouse = collision.gameObject;
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        targetHouse = null;
    }
    public void PaintHouse()
    {   
        
        if (targetHouse != null)
        {
            if (targetHouse.GetComponent<HouseDetectionHandler>().isPainted != true)
            {
                targetHouse.GetComponent<HouseDetectionHandler>().SetHouseColor(currentColor);
                
            }
            else
            {
                return;
            }
            /*targetHouse.GetComponent<SpriteRenderer>().color = currentColor;*/
        }
        else
        {
            return;
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }



}
