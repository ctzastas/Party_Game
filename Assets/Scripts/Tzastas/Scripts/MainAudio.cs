using UnityEngine;

public class MainAudio : MonoBehaviour {
    private AudioSource _mainAudio;

    void Awake() {
        _mainAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start() {
        _mainAudio.Play();   
    }
}
