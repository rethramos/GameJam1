using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyd5Collision : MonoBehaviour
{
    public GameObject mySpawnGameObject;
    public GameObject myObject;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Namog");
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "enemyd5")
        {
            //or have a GameObject and get its position
            Debug.Log("Namog");
            myObject.transform.position = mySpawnGameObject.transform.position;
            //Where mySpawnGameObject is a public GameObject variable that you assign from the inspector


        }
    }
}
