using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerId : MonoBehaviour
{
    public int playerId = 10;

    public void SetId(int value)
    {
        playerId = value;
    }
    public int GetId()
    {
        return playerId;
    }
}
