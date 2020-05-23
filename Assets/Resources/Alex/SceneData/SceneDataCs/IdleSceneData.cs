using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "IdleSceneData", menuName = "SceneData/IdleSceneData", order = 0)]

public class IdleSceneData : ISceneData
{
    public override string NextSceneName()
    {
        return base.NextSceneName();
    }

    public override void ActiveSceneChanged(Scene current, Scene next)
    {
        base.ActiveSceneChanged(current, next);

    }

    public override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        base.OnSceneLoaded(scene, mode);
      
    }

    public override void OnSceneUnloaded(Scene scene)
    {
        base.OnSceneUnloaded(scene);
    }
}
