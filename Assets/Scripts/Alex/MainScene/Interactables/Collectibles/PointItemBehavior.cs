using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointItemBehavior : MonoBehaviour, IInteractable
{
    private Rigidbody rb;
    [SerializeField]
    private float forcePower = 10;
    int firstCollision = 0;
    private PlayerStats _Player;
    [SerializeField] private int _Points = 5;
    //private TextMeshProUGUI[] _PlayerScores = new TextMeshProUGUI[4];

    private void Awake()
    {
        _Player = FindObjectOfType<PlayerStats>();
    }
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
        transform.parent.parent.GetComponent<Animator>().SetTrigger("Attack");
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
    public void OnCollisionBehaviour(Collision collision)
    {
        if (collision.transform.tag == "Floor" && firstCollision == 0)
        {
           
        }
    }
    public void OnTriggerBehaviour(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _Player.GetPlayers()[other.gameObject.GetComponent<PlayerId>().GetId()].AddScore(_Points);
            Debug.Log("Score Added for " + _Player.GetPlayers()[other.gameObject.GetComponent<PlayerId>().GetId()]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionBehaviour(collision);
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerBehaviour(other);
    }

   
}
