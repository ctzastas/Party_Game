using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllMyScenes : MonoBehaviour
{
    [SerializeField]
    protected ISceneData[] _allScenes;
    public ISceneData[] GetScenes()
    {
        return _allScenes;
    }
}
