using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float gravity = -9.8f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private Transform startTransform;

    private Vector3 velocity;
    private bool isGrounded;

    // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // temporarily disable character controller to teleport character
            controller.enabled = false;
            transform.position = startTransform.position;
            controller.enabled = true;
            Debug.Log(other.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Debug.Log(isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
