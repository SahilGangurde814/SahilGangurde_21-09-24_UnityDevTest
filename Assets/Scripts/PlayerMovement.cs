using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jSpeed = 10f;
    private Animator animator;
    private Rigidbody rb;

    public float sensitivity = 1f;
    private Camera mainCamera;

    [SerializeField] GameObject GOPanel;

    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        playerMove();
        isFalling();
    }

    // Player Movement and Running Animation
    void playerMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (x != 0 || z != 0)
        {
            if (isGrounded())
            {
                animator.SetBool("isRunning", true);
                rb.velocity = move.normalized * speed;
                rb.drag = 3f;
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            animator.SetBool("isFalling", true);
            rb.velocity = transform.up * jSpeed;
        }
        else
        {
            animator.SetBool("isFalling", false);
        }

    }

    //Check if Player Falling and Falling Animation
    bool isFalling()
    {
        bool isFalling = rb.velocity.y < 0f;
        if (isFalling)
        {
            animator.SetBool("isFalling", true);
        }
        return isFalling;
    }

    bool isGrounded()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        bool isPlayerGrounded = Mathf.Abs(localVelocity.y) < 0.1f; // Adjust the threshold as needed

        if (!isPlayerGrounded)
        {
            animator.SetBool("isFalling", true);
        }

        return isPlayerGrounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Debug.Log("Go");
            //Destroy(gameObject);
            GOPanel.SetActive(true);
        }
    }
}