using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

/// <summary>
/// Responsible Script for loading and assigning all data on each scene
/// </summary>
public class SceneLoader : MonoBehaviour
{

    public delegate void Change(string newSceneName);


    public ISceneData myCurrentData;
    public ISceneData myNextSceneData;
    //SceneChanges Only when this is True
    public bool _changeScene=false;
    public UnityEvent OnFinishScene;

    void Awake()
    {
       
    }

    // called first
    // Assign Data and events 
    void OnEnable()
    {
        if (myCurrentData == null)
        {
            myCurrentData = Resources.Load<ISceneData>("Alex/SceneData/SceneDataObjects/" + SceneManager.GetActiveScene().name + "Data");
            myCurrentData.SetupData();
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.activeSceneChanged += ActiveSceneChanged;

    }
    //Runs the OnSceneUnloaded Event of the current Scene Data
    void OnSceneUnloaded(Scene scene)
    {
        myCurrentData.OnSceneUnloaded(scene);
        //myCurrentData = myCurrentData.NextSceneData;

    }
    // called second
    //Runs the OnSceneLoaded Event of the current Scene Data
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        myCurrentData.OnSceneLoaded(scene, mode);
        //myNextSceneData = myCurrentData.NextSceneData;
    }
    //Runs the ActiveSceneChanged Event of the current Scene Data
    void ActiveSceneChanged(Scene current,Scene next)
    {
        OnFinishScene.Invoke();
        myCurrentData.ActiveSceneChanged(current, next);
    }
    // Makes sure a scene is fully loaded before searching for data to assign
    void ChangeScene(string nextSceneName)
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        //Debug.Log("Changing to new Scene");

        
        Scene scene = SceneManager.GetSceneByName(myCurrentData.NextSceneName());
        Debug.Log(myCurrentData.NextSceneName() + " : loading Data");
        myCurrentData.levelCompleted.allowChange = 1;
        SceneManager.LoadScene(myCurrentData.NextSceneName());
        myCurrentData = Resources.Load<ISceneData>("Alex/SceneData/SceneDataObjects/" + myCurrentData.NextSceneName() + "Data");
        Debug.Log(myCurrentData.name + " Loaded");
        myCurrentData.SetupData();
        myNextSceneData = myCurrentData.NextSceneData;
        _changeScene = false;
        while (!scene.isLoaded)
        {
            return;
        }
            
        
        SceneManager.SetActiveScene(scene);
       
    }
    // called third
    void Start()
    {
    }
    //Checks when the scene needs to be changed
    private void Update()
    {

        if (AllowSceneChange())
        {
            ChangeScene(myCurrentData.NextSceneName());
        }
    }
    //Bool to allow a scene to change to the next one
    bool  AllowSceneChange()
    {
        return _changeScene;
    }

    // called when the game is terminated _ Unassign events from delegate
    void OnDisable()
    {
        //Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        SceneManager.activeSceneChanged -= ActiveSceneChanged;
    }
}
