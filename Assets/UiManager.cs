using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    private PlayerStats stats;
    [SerializeField]
    private TextMeshProUGUI[] texts;

    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();  
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < stats.GetPlayers().Count; i++)
        {
            texts[i].text = "P" + (i+1) + "\nScore : " + stats.GetPlayers()[i].GetScore();
        }
    }
}
