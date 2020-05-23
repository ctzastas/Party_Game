using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayerInteractions : ScriptableObject
{
    //===========PlayerData===========//
    public ISensor sensor;
    protected Animator animator;
    protected AudioSource source;
    public AudioClip clip;

    public virtual void OnAwake(GameObject gameObject)
    {

    }
    public virtual void Interact(GameObject gameObject, int playerNum)
    {
    }
    public virtual void PlayAnimation(GameObject gameObject)
    {

    }
}
