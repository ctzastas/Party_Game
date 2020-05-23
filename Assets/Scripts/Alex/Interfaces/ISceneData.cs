using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Responsible Abstract class that hold all the data each scene needs to have.
/// Also assigns Movement, Interaction and Sensor Data if such objects exist in the assets folder for the current scene
/// </summary>

    //Colors for Players are
    //Player 1 Green
    //Player 2 Red
    //Player 3 Blue
    //Player 4 Yellow

public abstract class ISceneData : ScriptableObject
{
    public ISceneData NextSceneData;
    public IPlayerMovement thisScenePlayerMovement;
    public IPlayerInteractions thisScnenePlayerInteractions;
    public string nextSceneName;
    public List<Vector3> playerSpawnPoints;
    public GameObject[] playerObjectToUse;
    private Color[] playerColors = new Color[4];
    public ILevelCompleted levelCompleted;
    public AudioClip[] PlayerAudioClips;

    public void SetupData()
    {
        Debug.Log("SettingData");
        playerColors[0] = Color.green;
        playerColors[1] = Color.red;
        playerColors[2] = Color.blue;
        playerColors[3] = Color.magenta;

        if (levelCompleted == null)
        {
            if (Resources.Load<ILevelCompleted>("Alex/WinConditions/Data/" + SceneManager.GetActiveScene().name + "WinCondition") != null)
            {
                levelCompleted = Resources.Load<ILevelCompleted>("Alex/WinConditions/Data/" + SceneManager.GetActiveScene().name + "WinCondition");
            }
            else
            {
                levelCompleted = null;
            }
        }
        if (thisScenePlayerMovement == null)
        {
            if (Resources.Load<IPlayerMovement>("Alex/PlayerMovement/PlayerMovementObjects/" + SceneManager.GetActiveScene().name + "Movement") != null)
            {
                thisScenePlayerMovement = Resources.Load<IPlayerMovement>("Alex/PlayerMovement/PlayerMovementObjects/" + SceneManager.GetActiveScene().name + "Movement");
            }
            else
            {
                thisScenePlayerMovement = null;
            }
        }
        if (thisScnenePlayerInteractions == null)
        {
            if (Resources.Load<IPlayerInteractions>("Alex/InteractionData/InteractionDataObjects/" + SceneManager.GetActiveScene().name + "Interaction") != null)
            {
                thisScnenePlayerInteractions = Resources.Load<IPlayerInteractions>("Alex/InteractionData/InteractionDataObjects/" + SceneManager.GetActiveScene().name + "Interaction");

                if (Resources.Load<ISensor>("Alex/SensorData/SensorObjects/" + SceneManager.GetActiveScene().name + "Sensor") != null)
                {
                    thisScnenePlayerInteractions.sensor = Resources.Load<ISensor>("Alex/SensorData/SensorObjects/" + SceneManager.GetActiveScene().name + "Sensor");
                }
                else
                {
                    thisScnenePlayerInteractions.sensor = null;
                }
            }
            else
            {
                thisScnenePlayerInteractions = null;
            }
        }
        
    }
    public virtual string NextSceneName()
    {
        return nextSceneName;
    }
    public virtual void SetNextScene(string sceneName)
    {
        nextSceneName = sceneName;
        NextSceneData = Resources.Load<ISceneData>("Alex/SceneData/SceneDataObjects/" + sceneName + "Data");
    }
    public virtual void ActiveSceneChanged(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }
        // Debug.Log("Scenes: " + currentName + ", " + next.name);
    }
    public virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(scene.buildIndex);
        //Debug.Log(mode);
        SetupData();
        if (NextSceneData == null)
        {
            Debug.LogWarning("No Next scene Data has Been Assigned");
            if (nextSceneName != null)
            {
                NextSceneData = Resources.Load<ISceneData>("Alex/SceneData/SceneDataObjects/" + nextSceneName + "Data");
            }
        }
        if (playerObjectToUse != null && playerObjectToUse.Length>0)
        {
            PlayerStats players = FindObjectOfType<PlayerStats>();
            for (int i = 0; i < players.GetPlayers().Count; i++)
            {
                //players.GetPlayerObjects()[i].SetActive(true);
                //players.GetPlayers()[i].GetObject().transform.DetachChildren();
                GameObject obj = Instantiate(playerObjectToUse[i], players.GetPlayers()[i].GetObject().transform.position, players.GetPlayers()[i].GetObject().transform.rotation, players.GetPlayers()[i].GetObject().transform);
                obj.name = "Player_0" + i;
               // obj.GetComponent<MeshRenderer>().material.color = playerColors[i];
                players.GetPlayers()[i].GetObject().transform.position = playerSpawnPoints[i];
                players.GetPlayers()[i].GetObject().transform.LookAt(new Vector3(0, players.GetPlayers()[i].GetObject().transform.position.y, 0));
                players.GetPlayers()[i].GetObject().AddComponent<PlayerScript>();
                
                //Debug.Log(players.GetPlayers()[i].GetObject().transform.GetChild(0).gameObject.name);
                //Debug.Log(playerObjectToUse.name);
            }
        }
    }
    public void ResetScore()
    {
        PlayerStats players = FindObjectOfType<PlayerStats>();
        for (int i = 0; i < players.GetPlayers().Count; i++)
        {
            players.GetPlayers()[i].SetScore(0);
        }
    }
    public virtual void OnSceneUnloaded(Scene scene)
    {
        //Debug.Log("Scene Unloaded" + scene.name);
        PlayerStats players = FindObjectOfType<PlayerStats>();
   
    }
    public void AssignGoalIDs()
    {
    }
}
