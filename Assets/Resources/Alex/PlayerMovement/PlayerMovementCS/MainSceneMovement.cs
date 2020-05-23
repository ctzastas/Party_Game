using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

[CreateAssetMenu(fileName = "MainSceneMovement", menuName = "Movement/MainSceneMovement", order = 0)]
public class MainSceneMovement : IPlayerMovement
{

    //============Movement===========//
    [SerializeField]
    private float _Speed = 10;  


    public override void OnAwake(GameObject gameObject)
    {
        animator = gameObject.GetComponent<Animator>();
    }
    //Movement
    public override void Move(GameObject gameObject,int playerNum,PlayerStats player)
    {
        
        float forward = player.GetPlayers()[playerNum].GetCurrentState().ThumbSticks.Left.Y;
        float rotation = player.GetPlayers()[playerNum].GetCurrentState().ThumbSticks.Left.X;

        if (forward != 0 || rotation != 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, Mathf.Atan2(rotation, forward) * 180 / Mathf.PI, 0);
        }

        gameObject.transform.Translate(rotation * _Speed * Time.deltaTime, 0, forward * _Speed * Time.deltaTime,Space.World);
       
        if (player.GetPlayers()[playerNum].GetCurrentState().ThumbSticks.Left.Y != 0 || player.GetPlayers()[playerNum].GetCurrentState().ThumbSticks.Left.X !=0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
