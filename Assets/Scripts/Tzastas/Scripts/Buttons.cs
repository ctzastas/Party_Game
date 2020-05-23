using UnityEngine;

public class Buttons : MonoBehaviour {
    
    private AudioSource _buttonAudio;
    PlayerStats stats;
    
    private void Awake() {
        _buttonAudio = GetComponent<AudioSource>();
    }

    private void Start() {
        stats = FindObjectOfType<PlayerStats>();
        _buttonAudio.Stop();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            if (stats.GetPlayers()[other.gameObject.transform.parent.GetComponent<PlayerId>().GetId()].GetScore() >= FindObjectOfType<GoalPoints>().GetMaxScore()) {
                _buttonAudio.PlayOneShot(_buttonAudio.clip);
                Debug.LogWarning(" To Do Scene Transition ");
            }
        }       
    }
}
