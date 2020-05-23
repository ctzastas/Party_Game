using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreateManager : MonoBehaviour
{
    PersistentObject obj;

    private void OnEnable()
    {
        if (FindObjectOfType<PersistentObject>() == null)
        {
            //SceneManager.LoadScene("ManagerScene", LoadSceneMode.Additive);
            Instantiate(Resources.Load("Managers") as GameObject); 
        }
    }
}
