using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PingPongMovement", menuName = "Movement/PingPongMovement", order = 0)]
public class PingPongMovement : IPlayerMovement
{
    [SerializeField]
    private float _Speed = 10;
    [SerializeField]
    private float _RotSpeed = 160;


    //Movement
    public override void Move(GameObject gameObject, int playerNum, PlayerStats player)
    {

        gameObject.transform.Translate(player.GetPlayers()[playerNum].GetCurrentState().ThumbSticks.Left.X * _Speed * Time.deltaTime, 0, 0);

    }
}
