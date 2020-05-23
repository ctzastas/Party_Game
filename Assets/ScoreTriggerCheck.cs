using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerCheck : MonoBehaviour
{
    private PlayerStats stats;
    [SerializeField]
    private int score;
    SceneLoader loader;
    private void OnEnable()
    {
        loader = FindObjectOfType<SceneLoader>();
        stats = FindObjectOfType<PlayerStats>();
        transform.parent.GetComponent<Rigidbody>().AddTorque(Vector3.up * 500, ForceMode.VelocityChange);
        transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0.5f, 0, 0.5f) * 20, ForceMode.VelocityChange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stats.GetPlayers()[other.GetComponent<Transform>().parent.GetComponent<PlayerId>().GetId()].AddScore(score);
            CoinSpawner.SharedInstance.objectsActive--;
            other.GetComponentInChildren<ParticleSystem>().Play();
            other.GetComponent<AudioSource>().PlayOneShot(loader.myCurrentData.PlayerAudioClips[0]);
            transform.parent.gameObject.SetActive(false);

        }
    }
}
