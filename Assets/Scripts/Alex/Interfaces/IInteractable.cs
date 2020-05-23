using UnityEngine;

public interface IInteractable
{
    void PickUpItem();
    void ThrowItem();
    void OnTriggerBehaviour(Collider other);
    void OnCollisionBehaviour(Collision collision);
}
