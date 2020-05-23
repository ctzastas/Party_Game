using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainSceneSensor", menuName = "Sensor/MainSceneSensor", order = 0)]
public class MainSceneSensor : ISensor
{
    private bool _DrawGizmo;
    private LayerMask _LayerMask;
    [SerializeField]
    private float _BoxCheckScale = 3.5f;
    private Collider[] _HitColliders;

    private void Awake()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        _DrawGizmo = true;
        //Sets the LayerMask to the appropriate Layer
        _LayerMask = LayerMask.GetMask("ItemInteractions");
    }

    public override bool CanInteract()
    {
        return canInteract;
    }
    public override Transform GetGameObjectFound()
    {
        return transform;
    }
    public override IInteractable GetInteractable()
    {
        return interactable;
    }
    public override void Sensor(GameObject gameObject)
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        _HitColliders = Physics.OverlapBox(gameObject.transform.position, gameObject.transform.localScale.normalized * _BoxCheckScale / 2, Quaternion.identity, _LayerMask);
       
        for(int i = 0; i < _HitColliders.Length; i++)
        { 
            //Output all of the collider names
            Debug.Log("Hit : " + _HitColliders[i].name + " " + i);
            interactable = _HitColliders[0].GetComponent<IInteractable>();
            transform = _HitColliders[0].GetComponent<Transform>();
            //Debug.Log(gameObject.name);
            //Increase the number of Colliders in the array
        }
        if (_HitColliders.Length > 0)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }
    public Collider[] GetColliders()
    {
        if (_HitColliders != null)
        {
            return _HitColliders;
        }
        else
        {
            return null;
        }
    }
    public override void DrawGizmo(GameObject gameObject)
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode!!!
        if (_DrawGizmo)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(gameObject.transform.position, gameObject.transform.localScale.normalized * _BoxCheckScale);
    }
}
