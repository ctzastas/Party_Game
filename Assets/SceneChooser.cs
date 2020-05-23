using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChooser : MonoBehaviour
{
    public string name;

    public void ChooseScene()
    {
        FindObjectOfType<SceneLoader>().myCurrentData.SetNextScene(name);
        Debug.Log(FindObjectOfType<SceneLoader>().myCurrentData.nextSceneName);
        FindObjectOfType<ConditionChecker>().ChangeScene();
    }
}
