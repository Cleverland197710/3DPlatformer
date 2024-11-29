using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{

    private void Unsheathe()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Collider>().enabled = true;
        }

    }

    private void Sheathe()
    {
        GetComponent<Collider>().enabled = false;
    }

    /*IEnumerator AbilityCooldownRoutine(float cooldown)
    {
        abilityReady = false;

        yield return new WaitForSeconds(cooldown);

        abilityReady = true;
    }*/
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<Collider>().enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Collider>().enabled = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}
