using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LocomotionHandler : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction move;
    public Vector2 moveDirection;
    public float moveHorizontal;
    public float moveVertical;
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        ActivateInput();
    }

    private void OnDisable()
    {
        DeactivateInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the movement direction input vector
        moveDirection = move.ReadValue<Vector2>();
        if(playerControls.Player.Move.ReadValue<Vector2>().magnitude > 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("xInput", moveDirection.x);
            anim.SetFloat("yInput", moveDirection.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        Debug.Log(rb.velocity.magnitude);
    }
    /// <summary>
    /// Once every .02 seconds, this function is called
    /// </summary>
    public void FixedUpdate()
    {
        rb.velocity= move.ReadValue<Vector2>() * speed;
    }

    

    public void ActivateInput()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    public void DeactivateInput()
    {
        move.Disable();
    }
}
