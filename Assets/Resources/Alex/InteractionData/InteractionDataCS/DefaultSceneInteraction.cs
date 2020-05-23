using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultSceneInteraction", menuName = "Interaction/DefaultSceneInteraction", order = 0)]

public class DefaultSceneInteraction : IPlayerInteractions
{
    float timer = 0;
    SceneLoader loader;
    public override void OnAwake(GameObject gameObject)
    {
        animator = gameObject.GetComponent<Animator>();
        loader = FindObjectOfType<SceneLoader>();
    }
    public override void Interact(GameObject gameObject, int playerNum)
    {
        sensor.GetGameObjectFound().GetComponent<RagdollEnabler>().useRagdoll = true;
        
    }
    public override void PlayAnimation(GameObject gameObject)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            source = gameObject.GetComponent<AudioSource>();
            animator.SetTrigger("Attack");
            source.PlayOneShot(loader.myCurrentData.PlayerAudioClips[1], 0.6f);
        }
        
    }
}
