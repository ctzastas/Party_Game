using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultSceneSensor", menuName = "Sensor/DefaultSceneSensor", order = 0)]
public class DefaultSceneSensor : ISensor
{
    public Collider[] _HitColliders;
    public float sensorRadius = 1.5f;

    private bool _DrawGizmo;
    private LayerMask _LayerMask;
    private PlayerId id;
    private Transform objHit;

    private void Awake()
    {
        _DrawGizmo = true;
        _LayerMask = LayerMask.GetMask("Player");
    }
    public override void DrawGizmo(GameObject gameObject)
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode!!!
        if (_DrawGizmo)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireSphere(gameObject.transform.position, sensorRadius);
    }

    public override bool CanInteract()
    {
        return base.CanInteract();
    }

    public override void Sensor(GameObject gameObject)
    {
        _HitColliders = Physics.OverlapSphere(gameObject.transform.position, sensorRadius,_LayerMask);


        for (int i = 0; i < _HitColliders.Length; i++)
        {
            //Output all of the collider names
            if (_HitColliders[i].name != gameObject.transform.parent.name)
            {
                objHit = _HitColliders[i].transform;
                Debug.Log(objHit.name);
            }
            //Increase the number of Colliders in the array

        }
        if (_HitColliders.Length > 1)
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
        if (_HitColliders.Length > 0)
        {
            return _HitColliders;
        }
        else
        {
            return null;
        }
    }
    public override Transform GetGameObjectFound()
    {
        return objHit;
    }
    public int GetPlayerId()
    {
        return id.GetId();
    }
}
