using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayers : MonoBehaviour
{
    PlayerStats stats;

    private void Awake()
    {
        stats = FindObjectOfType<PlayerStats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < stats.GetPlayers().Count; i++)
        { 
           GameObject obj = Instantiate(Resources.Load("Player_0"),Vector3.zero,Quaternion.identity,gameObject.transform) as GameObject;
            
            obj.name = "Player_0"+ (i + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
