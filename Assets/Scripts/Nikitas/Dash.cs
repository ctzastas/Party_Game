using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float dashLength;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
                transform.Translate(transform.forward * dashLength * playerSpeed); 
        }  
    }
}
