using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Ctrl : MonoBehaviour
{
    [SerializeField]
    public GameObject particle1;
    public GameObject particle2;


    void Start()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            particle1.SetActive(true);
            particle2.SetActive(true);

            StartCoroutine(AttackCoolDown());
        }

       

      
    }

    IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(2);
        particle1.SetActive(false);
        particle2.SetActive(false);
    }

}
