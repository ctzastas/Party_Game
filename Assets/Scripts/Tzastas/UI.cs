using System.Collections;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{

    private PlayerStats _player;    // Player data
    [SerializeField] private TextMeshProUGUI _TimeText;
    private TextMeshProUGUI[] _playerScores = new TextMeshProUGUI[4];
    [SerializeField] private float _Timer;
    [SerializeField] private MainAudio _audio; // Main audio of level 1 is an instance of the main camera object
    [SerializeField] private GameObject _levelObjectPanel;

    void Awake()
    {
        StartCoroutine(EnablePanel());
        _Timer = 120;
        _player = FindObjectOfType<PlayerStats>();
        _TimeText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < _player.GetPlayers().Count; i++)
        {
            _playerScores[i] = GameObject.Find("Player" + (i + 1) + "Text").GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore();
        CountdownTime();
    }

    // Players show scores
    void PlayerScore()
    {
        for (int i = 0; i < _player.GetPlayers().Count; i++)
        {
            _playerScores[i].text = _player.GetPlayers()[i].GetScore().ToString();
        }
    }

    // Countdown Timer
    void CountdownTime()
    {
        _Timer -= Time.deltaTime;
        _TimeText.text = "" + Mathf.Round(_Timer);
        // Check when Timer go to 0 then end stage
        if (_Timer <= 0)
        {
            Debug.Log("Level ends");
            Time.timeScale = 0;
           // _audio.MainAudioStop();
        }
    }

    // After 2 seconds disable text
    IEnumerator EnablePanel()
    {
        yield return new WaitForSeconds(2);
        _levelObjectPanel.SetActive(false);
    }
}