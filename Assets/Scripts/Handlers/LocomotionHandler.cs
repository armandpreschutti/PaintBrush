using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LocomotionHandler : MonoBehaviour
{

    public PlayerInput playerInput;

    public Rigidbody2D rb;
    public Animator anim;
    public float speed;

   
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

        
    }
    /// <summary>
    /// Once every .02 seconds, this function is called
    /// </summary>
    public void FixedUpdate()
    {
        rb.velocity= playerInput.moveDirection * speed;
    }

    

   
}
