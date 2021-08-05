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
<<<<<<< HEAD:Assets/Scripts/PlayerMovement.cs
    //[SerializeField] private GameObject image;

    private Inventory inventory = Inventory.Instance;
=======
    [SerializeField] private GameObject image;
>>>>>>> main:Assets/PlayerMovement.cs
    public int count = 0;

    private Vector3 velocity;
    private bool isGrounded;
    private EventBroadcaster eb = EventBroadcaster.Instance;
<<<<<<< HEAD:Assets/Scripts/PlayerMovement.cs
=======
    private Inventory inventory = Inventory.Instance;
>>>>>>> main:Assets/PlayerMovement.cs

    // Start is called before the first frame update
    void Start()
    {
            //StartCoroutine(Wait());

    }
    //TODO: FIX WAIT - Need to disable power up text 
    //IEnumerator Wait()
    //{
    //    if (count == 1)
<<<<<<< HEAD:Assets/Scripts/PlayerMovement.cs
      //  {
        //    Debug.Log("Wait");
          //  yield return new WaitForSeconds(2);
            //image.SetActive(false);
       // }
   // }
=======
    //    {
    //        Debug.Log("Wait");
    //        yield return new WaitForSeconds(2);
    //        image.SetActive(false);
    //    }
    //}
>>>>>>> main:Assets/PlayerMovement.cs

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
<<<<<<< HEAD:Assets/Scripts/PlayerMovement.cs

            eb.PostEvent(EventNames.PowerupEvents.ON_FREEZE_COLLECT);

        }
        Debug.Log("collided with: " + other);
    }
=======
            
            eb.PostEvent(EventNames.PowerupEvents.ON_FREEZE_COLLECT);
            
        }
        Debug.Log("collided with: " + other);
    }


>>>>>>> main:Assets/PlayerMovement.cs



    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);
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

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        ListenToPowerupUse();
    }


    // powerup mapping: 1 - jump, 2 - freeze, 3 - hint
    private void ListenToPowerupUse()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.JumpCounter > 0)
        {
            Debug.Log("1 is pressed");
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
