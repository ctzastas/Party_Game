using UnityEngine;

public class HydrantAudio : MonoBehaviour {
    
    private AudioSource _hydrantAudio;

    void Awake() {
        _hydrantAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start() {
        _hydrantAudio.Stop();   
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Coins")) {
            _hydrantAudio.Play();
        }
    }
}