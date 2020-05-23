using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
public class ConditionChecker : MonoBehaviour
{
    ILevelCompleted completed;
    Image fader;
    private void Awake()
    {
        completed = FindObjectOfType<SceneLoader>().myCurrentData.levelCompleted;
        completed.OnAwake();
    }

    private void Start()
    {
        fader = GameObject.Find("Fader").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        StartChangingScene();
    }
    public void StartChangingScene()
    {
        completed = FindObjectOfType<SceneLoader>().myCurrentData.levelCompleted;
        if (completed.WinConditionMet())
        {
            fader.color += Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), Mathf.PingPong(Time.deltaTime, 1));
            if (fader.color.a >= 2.5f && completed.allowChange == 0)
            {
                ChangeScene();
            }
        }
        else
        {

        }
    }
    public void ChangeScene()
    {
        completed.LevelHasFinished();
        fader.color = new Color(0, 0, 0, 0);
    }
}
