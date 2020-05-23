using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "MainSceneData", menuName = "SceneData/MainSceneData", order = 0)]
public class MainSceneData : ISceneData
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
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        for (int i = 0; i < stats.GetPlayers().Count; i++)
        {
            stats.GetPlayers()[i].GetObject().transform.GetChild(0).transform.localScale *= 2;
        }
    }

    public override void OnSceneUnloaded(Scene scene)
    {
        base.OnSceneUnloaded(scene);
    }
}
