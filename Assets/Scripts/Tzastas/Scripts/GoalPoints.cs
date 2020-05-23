using UnityEngine;

public class GoalPoints : MonoBehaviour {
    
    private PlayerStats _players;
    private int _score = 5;
    private ParticleSystem _effect;
    private Transform _child;
    private Transform _secondChild;
    private AudioSource _goalAudio;
    public static int MaxScore = 25;
    void Awake() {
        _child = transform.GetChild(0);
        _secondChild = transform.GetChild(1);
        _effect = _secondChild.GetComponent<ParticleSystem>();
        _goalAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start() {
        _players = FindObjectOfType<PlayerStats>();
        _effect.Stop();
        _goalAudio.Stop();
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Coins")) {
            _players.GetPlayers()[GetComponent<GoalId>().GetId()].AddScore(_score);
            _goalAudio.Play();
            if (_players.GetPlayers()[GetComponent<GoalId>().GetId()].GetScore() == MaxScore) {
                Destroy(_child.gameObject);
                _effect.Play();
            }
        }
    }
    
    public int GetMaxScore() {
        return MaxScore;
    }
    
    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Coins")) {
            other.gameObject.SetActive(false);
        }
    }
}