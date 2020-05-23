using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public abstract class IPlayerMovement : ScriptableObject
{
    protected Animator animator;
    public virtual void OnAwake(GameObject gameObject)
    {

    }
    public virtual void Move(GameObject gameObject,int playerNum,PlayerStats player)
    {

    }
    public virtual void Move(Rigidbody rb, int playerNum, PlayerStats player)
    {

    }
}
