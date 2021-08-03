using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Vertical");
        anim.SetFloat("vertical", z);
        float x = Input.GetAxis("Horizontal");
        anim.SetFloat("horizontal", x);
        Debug.Log("V: " + z + " H: " + x);
    }
}
