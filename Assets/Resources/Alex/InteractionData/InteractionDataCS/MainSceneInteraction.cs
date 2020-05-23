using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MainSceneInteraction", menuName = "Interaction/MainSceneInteraction", order = 0)]

public class MainSceneInteraction : IPlayerInteractions
{
    //============Interaction=========//
    [SerializeField]
    private bool _HoldingItem = false;

    private Transform _ItemHold;

    //Player Interacts with Items In Range
    public override void Interact(GameObject gameObject, int playerNum)
    {
        _ItemHold = gameObject.transform;
        if (gameObject.transform.childCount>0)
        {
            _HoldingItem = true;
        }
        else
        {
            _HoldingItem = false;
        }
        if (!_HoldingItem)
        {
            sensor.GetGameObjectFound().SetParent(_ItemHold);
            sensor.GetInteractable().PickUpItem();
            _HoldingItem = true;
        }
        else
        {
             sensor.GetInteractable().ThrowItem();
            _HoldingItem = false;
        }
    }
}
