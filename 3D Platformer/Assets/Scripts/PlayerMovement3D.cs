using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 7, 0);
        }

        
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
        }

        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -3);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-3, 0, 0);
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 0);
        }

    }
}
