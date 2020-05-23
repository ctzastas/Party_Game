using UnityEngine;

public class NailsAudio : MonoBehaviour {
    
    private AudioSource _nailsAudio;

    void Awake() {
        _nailsAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start() {
        _nailsAudio.Stop();   
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Coins")) {
            _nailsAudio.Play();
        }
    }
}