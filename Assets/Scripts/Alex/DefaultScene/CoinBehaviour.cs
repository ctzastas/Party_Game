using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour,IInteractable
{
    private AudioClip clip;
    private AudioSource source;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
        source.priority = 256;
        source.volume = 0.2f;
        source.playOnAwake = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        OnCollisionBehaviour(collision);
    }
    public void OnCollisionBehaviour(Collision collision)
    {
        source.PlayOneShot(clip);
    }
    public void SetClip(AudioClip clip)
    {
        this.clip = clip;
        source.clip = this.clip;
    }

    public void OnTriggerBehaviour(Collider other)
    {
       // throw new System.NotImplementedException();
    }

    public void PickUpItem()
    {
      //  throw new System.NotImplementedException();
    }

    public void ThrowItem()
    {
      //  throw new System.NotImplementedException();
    }
}
