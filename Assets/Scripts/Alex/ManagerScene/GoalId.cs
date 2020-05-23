using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalId : MonoBehaviour
{
    [SerializeField]
    private int goalId;

    public int GetId()
    {
        return goalId;
    }
    private void Start()
    {
        PlayerStats players = FindObjectOfType<PlayerStats>();

        //if (GetId()<players.GetPlayers().Count)
        //{
        //    GetComponent<Collider>().isTrigger = true;
        //}
    }
}
