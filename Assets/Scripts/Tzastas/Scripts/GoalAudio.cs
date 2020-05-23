using UnityEngine;

public class GoalAudio : MonoBehaviour {
    
    private AudioSource _goalAudio;

    void Awake() {
        _goalAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start() {
        _goalAudio.Stop();   
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Coins")) {
            _goalAudio.Play();
        }
    }
}