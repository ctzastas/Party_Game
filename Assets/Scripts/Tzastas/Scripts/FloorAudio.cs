using UnityEngine;

public class FloorAudio : MonoBehaviour {
    
    private AudioSource _floorAudio;

    void Awake() {
        _floorAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start() {
        _floorAudio.Stop();   
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Coins")) {
            _floorAudio.Play();
        }
    }
}