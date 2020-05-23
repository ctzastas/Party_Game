using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour {

    public string levelName;
    public bool MadeChoice = false;
    public void LevelSelector ()
    {
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        for (int i = 0; i < stats.GetPlayers().Count; i++)
        {
            stats.GetPlayers()[i].SetScore(0);
        }
      
        FindObjectOfType<SceneLoader>().myCurrentData.SetNextScene(levelName);
        FindObjectOfType<SceneLoader>()._changeScene = true;
        GameObject.Find("Selector").SetActive(false);
    }
     
}