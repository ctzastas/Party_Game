using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : Singleton<PersistentObject>
{
    protected PersistentObject() { }
    private void Awake()
    {
        if (Instance == this)
        {
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
            Destroy(gameObject);
        }
    }
}
