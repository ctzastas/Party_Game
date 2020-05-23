using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "DefaultSceneData", menuName = "SceneData/DefaultSceneData", order = 0)]
public class DefaultSceneData : ISceneData
{
    public ParticleSystem system;
    private AudioSource source;
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
            source = stats.GetPlayers()[i].GetObject().transform.GetChild(0).gameObject.AddComponent<AudioSource>();
            if (source != null)
            {
               
                source.clip = PlayerAudioClips[0];
                source.volume = 0.5f;
                source.priority = 2;
            }
           
            if (system != null)
            {
                Instantiate(system, stats.GetPlayers()[i].GetObject().transform.GetChild(0).gameObject.transform);

            }
        }
    }

    public override void OnSceneUnloaded(Scene scene)
    {
        base.OnSceneUnloaded(scene);
    }
}
