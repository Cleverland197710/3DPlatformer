using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Ctrl : MonoBehaviour
{
    [SerializeField]
    public GameObject particle1;
    public GameObject particle2;

    private Vector2 mousePos;

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
        }

      
    }
}
