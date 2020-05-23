using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEnabler : MonoBehaviour
{
    public bool useRagdoll;
    Rigidbody[] rigidbodies;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = transform.GetChild(1).GetComponentsInChildren<Rigidbody>();
        transform.Find("PlayerCanvas").GetComponent<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RagdollCheck();
    }
    void RagdollCheck()
    {
        if (useRagdoll)
        {
            transform.parent.GetComponent<PlayerScript>().enabled = false;
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.isKinematic = false;
                rb.AddForce(-transform.forward, ForceMode.Force);
            }
            timer += Time.deltaTime;
            GetComponent<Animator>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            if (timer >= 2)
            {
                useRagdoll = false;
                transform.parent.GetComponent<PlayerScript>().enabled = true;
                timer = 0;
            }

        }
        else
        {
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.isKinematic = true;
            }
            GetComponent<Animator>().enabled = true;
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
