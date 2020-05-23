using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.Events;
/// <summary>
/// Responsible Script to Implement all the Behaviors of a player in every Scene Depending on the provided data
/// </summary>
public class PlayerScript : MonoBehaviour
{
    public IPlayerMovement playerMovement;
    public IPlayerInteractions playerInteractions;

    //==========Controller / ID =======//
    private int playerNum;
    private PlayerStats player;
    private SceneLoader loader;
    private UnityAction gameObjectDestroyer;
    private GameObject _HoldingPosition;
    public GameObject PlayerObject;
    private Rigidbody rb;
    //Find requiered Data
    private void Awake()
    {
        playerNum = GetComponent<PlayerId>().GetId();
        player = FindObjectOfType<PlayerStats>();
        loader = FindObjectOfType<SceneLoader>();
        
        gameObjectDestroyer += OnLoadingNewScene;
        loader.OnFinishScene.AddListener(gameObjectDestroyer);

        PlayerObject = gameObject.transform.GetChild(0).gameObject;
        if (loader.myCurrentData.thisScenePlayerMovement != null)
        {
            playerMovement = ScriptableObject.CreateInstance(loader.myCurrentData.thisScenePlayerMovement.GetType())as IPlayerMovement;
            playerMovement.OnAwake(PlayerObject);
        }
        if (loader.myCurrentData.thisScnenePlayerInteractions != null)
        {
            playerInteractions = ScriptableObject.CreateInstance(loader.myCurrentData.thisScnenePlayerInteractions.GetType())as IPlayerInteractions;
            if (loader.myCurrentData.thisScnenePlayerInteractions.sensor != null)
            {
                playerInteractions.sensor = ScriptableObject.CreateInstance(loader.myCurrentData.thisScnenePlayerInteractions.sensor.GetType()) as ISensor;
            }
        }
        


        
        //playerMovement = loader.myCurrentData.thisScenePlayerMovement;
        //playerInteractions = loader.myCurrentData.thisScnenePlayerInteractions;
    }
    //Find Objects in Scene
    private void Start()
    {
        
        //Debug.Log(PlayerObject.name);
       // Debug.Log("PlayerScript Start");
        _HoldingPosition = PlayerObject.transform.Find("HoldingPosition").gameObject;
        rb = PlayerObject.GetComponent<Rigidbody>();

    }
    //Check for anything that requires Physics
    private void FixedUpdate()
    {
        if (playerInteractions != null)
        {
            playerInteractions.sensor.Sensor(_HoldingPosition);
        }

        if (playerNum < player.GetPlayers().Count && playerMovement !=null)
        {
            playerMovement.Move(rb, playerNum, player);
            playerMovement.Move(PlayerObject.gameObject, playerNum, player);
        }
    }
    // Checks for anything withought the need of Physics
    private void Update()
    {
        if (playerNum < player.GetPlayers().Count && playerInteractions !=null)
        {
            Debug.Log(playerInteractions.sensor.CanInteract());
            if (playerInteractions.sensor.CanInteract()) 
            {
                
                if (player.GetPlayers()[playerNum].GetPrevState().Buttons.A == ButtonState.Released && player.GetPlayers()[playerNum].GetCurrentState().Buttons.A == ButtonState.Pressed)
                {
                    playerInteractions.Interact(_HoldingPosition, playerNum);
                }
            }
        }
    }
    //Debug Sensors on Game View
    private void OnDrawGizmos()
    {
        if (playerInteractions != null)
        {
            playerInteractions.sensor.DrawGizmo(_HoldingPosition);
        }
    }
    //Runs as an event when a new scene has been loaded
    private void OnLoadingNewScene()
    {
        Debug.Log("Destroy Object Runs");
        Destroy(GetComponent<PlayerScript>());
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        transform.DetachChildren();
        Destroy(PlayerObject);
        
        
    }
    //Gets the event out of the delegate
    private void OnDestroy()
    {
        gameObjectDestroyer -= OnLoadingNewScene;
    }
}
