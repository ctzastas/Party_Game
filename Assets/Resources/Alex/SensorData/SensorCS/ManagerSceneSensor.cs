using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ManagerSceneSensor", menuName = "Sensor/ManagerSceneSensor", order = 0)]

public class ManagerSceneSensor : ISensor
{
    public override bool CanInteract()
    {
        return base.CanInteract();
    }

    public override void DrawGizmo(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }
    public override void Sensor(GameObject gameObject)
    {
        base.Sensor(gameObject);
    }
}
