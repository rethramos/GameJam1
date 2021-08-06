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
    [SerializeField] private GameObject image;
    public int count = 0;

    private Vector3 velocity;
    private bool isGrounded;
    private EventBroadcaster eb = EventBroadcaster.Instance;
    private Inventory inventory = Inventory.Instance;
    private bool superJumpUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Wait());

    }
    //TODO: FIX WAIT - Need to disable power up text 
    //IEnumerator Wait()
    //{
    //    if (count == 1)
    //    {
    //        Debug.Log("Wait");
    //        yield return new WaitForSeconds(2);
    //        image.SetActive(false);
    //    }
    //}

    // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
    private void OnDrawGizmos()
    {
        // just to check how the ground check looks like
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        //image.SetActive(false);
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.ToString());
        if (other.CompareTag("Enemy"))
        {
            // temporarily disable character controller to teleport character
            controller.enabled = false;
            transform.position = startTransform.position;
            controller.enabled = true;
        }
        else if (other.CompareTag("Powerup:Freeze"))
        {
            Debug.Log("from ontrigger Powerup");
            Debug.Log("Freeze found");
            other.gameObject.SetActive(false);

            eb.PostEvent(EventNames.PowerupEvents.ON_FREEZE_COLLECT);

        }
        else if (other.CompareTag("Powerup:Hint"))
        {
            Debug.Log("from powerup hint");
            other.gameObject.SetActive(false);

            eb.PostEvent(EventNames.PowerupEvents.ON_HINT_COLLECT);
        }
        else if (other.CompareTag("Powerup:Jump"))
        {
            Debug.Log("from powerup jump");
            other.gameObject.SetActive(false);

            eb.PostEvent(EventNames.PowerupEvents.ON_JUMP_COLLECT);
        }
        Debug.Log("collided with: " + other);
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

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            }
            else if (superJumpUsed)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 3 * -2f * gravity);
                superJumpUsed = false;
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        ListenToPowerupUse();
    }


    // powerup mapping: 1 - jump, 2 - freeze, 3 - hint
    private void ListenToPowerupUse()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.JumpCounter > 0 && isGrounded)
        {
            Debug.Log("1 is pressed");
            superJumpUsed = true;
            eb.PostEvent(EventNames.PowerupEvents.ON_JUMP_USE);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && inventory.FreezeCounter > 0)
        {
            Debug.Log("2 is pressed");
            eb.PostEvent(EventNames.PowerupEvents.ON_FREEZE_USE);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && inventory.HintCounter > 0)
        {
            Debug.Log("3 is pressed");
            eb.PostEvent(EventNames.PowerupEvents.ON_HINT_USE);

        }
    }
}
