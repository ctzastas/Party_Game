using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour, IInteractable
{
    PlayerStats players;
    Rigidbody rb;
    public float MaxSpeed;

    public void OnCollisionBehaviour(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            rb.AddForce(new Vector3(Random.Range(-MaxSpeed, MaxSpeed), 0, Random.Range(-MaxSpeed, MaxSpeed)),ForceMode.Impulse);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    public void OnTriggerBehaviour(Collider other)
    {
        if (other.tag == "Goal")
        {
            if (players.GetPlayers()[other.GetComponent<GoalId>().GetId()] != null)
            {
                players.GetPlayers()[other.GetComponent<GoalId>().GetId()].AddScore(10);
                ObjectPool.SharedInstance.objectsActive--;
                gameObject.SetActive(false);
            }
        }
    }

    public void PickUpItem()
    {
        //throw new System.NotImplementedException();
    }

    public void ThrowItem()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        players = FindObjectOfType<PlayerStats>();
        rb.constraints = RigidbodyConstraints.None;
        rb.velocity = Vector3.zero;
        MaxSpeed = 15;
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * MaxSpeed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        OnCollisionBehaviour(collision);
    }
    public void OnTriggerEnter(Collider other)
    {
        OnTriggerBehaviour(other);
    }

}
