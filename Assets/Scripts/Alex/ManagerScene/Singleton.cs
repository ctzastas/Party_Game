using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T gameController;
    private static bool _shuttingDown = false;
    private static object _Lock = new object();

    public static T Instance 
    {
        get 
        {
            if (_shuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed. Returning null.");
                return null;
            }
            lock (_Lock)
            {
                if (gameController == null)
                {
                    gameController = (T)FindObjectOfType(typeof(T));

                    if (gameController == null)
                    {
                        var singletonObject = new GameObject();
                        gameController = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return gameController;
            }
        }
    }
    private void OnGUI()
    {
      //  GUI.Label(new Rect(10, 10, 100, 30), name);
    }


    private void OnApplicationQuit()
    {
        _shuttingDown = true;
    }


    private void OnDestroy()
    {
        _shuttingDown = true;
    }
}

