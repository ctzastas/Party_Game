using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EmptySceneWinCondition", menuName = "DefaultSceneWinCondition", order = 0)]

public class EmptySceneWinCondition : ILevelCompleted
{
    public bool test;
    public override void OnAwake()
    {
        base.OnAwake();
    }

    public override bool WinConditionMet()
    {
        LevelSelectorController[] obj = FindObjectsOfType<LevelSelectorController>();

        for (int i = 0; i > obj.Length; i++)
        {
            if (obj[i].MadeChoice == true)
            {
                return true;
            }
        }
        return false;
    }
}
