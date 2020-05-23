using UnityEngine;

public class FenceAudio : MonoBehaviour {
    
    private AudioSource _fenceAudio;

    void Awake() {
        _fenceAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start() {
        _fenceAudio.Stop();   
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Coins")) {
            _fenceAudio.Play();
        }
    }
}