using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DefaultSceneWinCondition", menuName = "DefaultSceneWinCondition", order = 0)]
public class DefaultSceneWinCondition : ILevelCompleted
{
    PlayerStats players;
    public int MaxScore;

    public override bool WinConditionMet()
    {
        players = FindObjectOfType<PlayerStats>();
        for (int i = 0; i < players.GetPlayers().Count; i++)
        {
            if (players.GetPlayers()[i].GetScore() >= MaxScore)
            {
                return true;
            }
        }
        return false;
    }
    public override void LevelHasFinished()
    {
        base.LevelHasFinished();
    }
    public override void OnAwake()
    {
        base.OnAwake();
        players = FindObjectOfType<PlayerStats>();
    }

}
