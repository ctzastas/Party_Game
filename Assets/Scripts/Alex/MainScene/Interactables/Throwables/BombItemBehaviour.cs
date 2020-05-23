using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItemBehaviour : MonoBehaviour,IInteractable {

    private Rigidbody rb;
    [SerializeField]
    private float forcePower = 10;

    public void PickUpItem()
    {
        rb.isKinematic = true;
        transform.SetPositionAndRotation(transform.parent.transform.position, transform.parent.transform.rotation);
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        rb.useGravity = false;
    }

    public void ThrowItem()
    {
        rb.isKinematic = false;
        rb.AddForce(transform.parent.transform.forward * forcePower, ForceMode.VelocityChange);
        transform.parent.DetachChildren();
        rb.useGravity = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionBehaviour(collision);
    }


    public void OnTriggerBehaviour(Collider other)
    {
      //  throw new System.NotImplementedException();
    }

    public void OnCollisionBehaviour(Collision collision)
    {
      // throw new System.NotImplementedException();
    }
}
