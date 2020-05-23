using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStairs : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
            rb.isKinematic = false;
    }
} 
