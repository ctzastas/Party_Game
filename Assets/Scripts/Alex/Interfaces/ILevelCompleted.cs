using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ILevelCompleted : ScriptableObject
{
    public int allowChange = 0;
    public virtual void OnAwake()
    {
        allowChange = 0;
    }
    public virtual void LevelHasFinished()
    {
        Debug.Log("Changing Scene");
        FindObjectOfType<SceneLoader>()._changeScene = true;
        allowChange = 1;
    }
    public abstract bool WinConditionMet();
}
