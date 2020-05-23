using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainSceneMovement", menuName = "Movement/MainSceneMovement new", order = 0)]

public class Movement : IPlayerMovement
{
    public float PlayerMovement=100;
    public float PlayerRotation = 180;
    private Rigidbody rb;

    public override void OnAwake(GameObject gameObject)
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override void Move(Rigidbody rb, int playerNum, PlayerStats player)
    {
        float moveVertical = player.GetPlayers()[playerNum].GetCurrentState().ThumbSticks.Left.Y * PlayerMovement * Time.deltaTime;
        float moveHorizontal = player.GetPlayers()[playerNum].GetCurrentState().ThumbSticks.Right.X * PlayerMovement * Time.deltaTime;
        Debug.Log("Help Me");
        Vector3 movement = rb.transform.forward * moveVertical;
        Vector3 rotation = rb.transform.up * moveHorizontal;

        rb.AddForce(movement * PlayerMovement);
        rb.AddTorque(rotation * PlayerRotation);
    }

} 