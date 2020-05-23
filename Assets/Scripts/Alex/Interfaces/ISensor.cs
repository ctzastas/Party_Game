using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISensor : ScriptableObject
{
    public bool canInteract=false;
    protected IInteractable interactable = null;
    protected Transform transform = null;

    public virtual bool CanInteract()
    {
        return canInteract;
    }
    public virtual IInteractable GetInteractable()
    {
        return interactable;
    }
    public virtual void Sensor(GameObject gameObject)
    {

    }
    public abstract void DrawGizmo(GameObject gameObject);
    public virtual Transform GetGameObjectFound()
    {
        return transform;
    }
}
