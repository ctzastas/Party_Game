using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour {
    #region Data
    //Holds a list with the controllers connected
    private List<Player> _Players;
    //================DataUsedToSetupPlayerControllers===================//
    private bool _PlayerIndexSet = false;
    private List<PlayerIndex> controllersConected = new List<PlayerIndex>();
    //==============EventCalledWhenControllersConnect/Disconnect==========//
    public UnityEvent ControllerHandler;

    #endregion Data
    private void Awake()
    {
        _Players = new List<Player>();
        SetUpControllers();
    }
    private void Update()
    {
        UpdateStates();
       // DebugControllers();
       
        
    }
    private void LateUpdate()
    {
        CheckControllerConnection();
        RemoveController();
        AddController();
    }

    private void OnControllerAdded()
    {
        if (ControllerHandler != null)
        {
            ControllerHandler.Invoke();
            Debug.Log("Called");
        }
    }
    //Check if a registered Controller Connected or Disconected
    void CheckControllerConnection()
    {
        for (int i = 0; i < _Players.Count; i++)
        {
            if (_Players[i].GetPrevState().IsConnected && !_Players[i].GetCurrentState().IsConnected)
            {
                Debug.Log("Disconected");
            }
            else if (!_Players[i].GetPrevState().IsConnected && _Players[i].GetCurrentState().IsConnected)
            {
                Debug.Log("Connected");
                
            }
        }
    }
    //Simple Debug cs Checking input on A button and Stick Axis
    void UpdateStates()
    {
        for (int i = 0; i < _Players.Count; i++)
        {
            _Players[i].SetPrevState(_Players[i].GetCurrentState());
            _Players[i].SetCurrentState(GamePad.GetState(_Players[i].GetIndex()));
        }
    }
    void DebugControllers()
    {
        for (int i = 0; i < _Players.Count; i++)
        {
            // Detect if a button was pressed this frame
            if (_Players[i].GetPrevState().Buttons.A == ButtonState.Released && _Players[i].GetCurrentState().Buttons.A == ButtonState.Pressed)
            {
                GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            }
            // Detect if a button was released this frame
            if (_Players[i].GetPrevState().Buttons.A == ButtonState.Pressed && _Players[i].GetCurrentState().Buttons.A == ButtonState.Released)
            {
                GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }

            // Make the current object turn
            transform.localRotation *= Quaternion.Euler(0.0f, _Players[i].GetCurrentState().ThumbSticks.Left.X * 25.0f * Time.deltaTime, 0.0f);
        }
    }

    //Searches for at least 4 controllers and creates _Players
    //depending on how many controllers are connected
    void SetUpControllers()
    {
       
        if (!_PlayerIndexSet)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    _PlayerIndexSet = true;
                    GameObject obj = Instantiate(Resources.Load("PlayerScriptHolder"), Vector3.zero, Quaternion.identity, gameObject.transform) as GameObject;
                    _Players.Add(new Player( testPlayerIndex, testState,obj));
                    obj.AddComponent<PlayerId>().SetId((int)testPlayerIndex);
                    //Debug.Log((int)testPlayerIndex);
                    controllersConected.Add(testPlayerIndex);
                }
                else
                {
                   // Debug.Log("No Controller found at " + testPlayerIndex);
                }
            }
        }
    }

    //Adds AnotherController During Runtime
    void AddController()
    {
       // Debug.Log(controllersConected.Count);
        for (int i = 0; i < 4; i++)
        {
            if (!controllersConected.Contains((PlayerIndex)i))
            {
                GamePadState testState = GamePad.GetState((PlayerIndex)i);
                if (testState.IsConnected)
                {
                    PlayerIndex testPlayerIndex = (PlayerIndex)i;
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    GameObject obj = Instantiate(Resources.Load("PlayerScriptHolder"), Vector3.zero, Quaternion.identity, gameObject.transform) as GameObject;
                    _Players.Add(new Player (testPlayerIndex, testState,obj));
                    obj.AddComponent<PlayerId>().SetId((int)testPlayerIndex);
                    Debug.Log((int)testPlayerIndex);
                    controllersConected.Add(testPlayerIndex);
                    OnControllerAdded();
                }
            }
        }
    }
    //Removes controller During Runtime
    void RemoveController()
    {
        for (int i = 0; i < 4; i++)
        {
            if (controllersConected.Contains((PlayerIndex)i))
            {
                GamePadState testState = GamePad.GetState((PlayerIndex)i);
                if (!testState.IsConnected)
                {
                    PlayerIndex testPlayerIndex = (PlayerIndex)i;
                    Debug.Log(string.Format("GamePad Disconnected {0}", testPlayerIndex));
                    _Players.RemoveAt(i);
                    controllersConected.Remove(testPlayerIndex);
                }
            }
        }
    }
    //Gets a list of all the players created by the controller IDs
    public List<Player> GetPlayers()
    {
        return _Players;
    }
    public Player GetPlayer(int player)
    {
        return _Players[player];
    }
    //Class to hold information on player Stats and Input
    public class Player
    {
        private bool _PlayerIndexSet;
        private PlayerIndex _PlayerIndex;
        private GamePadState _State;
        private GamePadState _PrevState;
        private int _Score;
        private int _GlobalScore;
        private GameObject gameObject;
      
       public Player()
       {
           
       }
        // Main Constructor
        public Player( PlayerIndex newPlayerIndex, GamePadState newState, GameObject gameObject, int score =0,int globalScore=0 )
        {
            _PlayerIndex = newPlayerIndex;
            _State = newState;
            _PlayerIndexSet = true;
            _Score = score;
            _GlobalScore = globalScore;
            this.gameObject = gameObject;
        }

        public PlayerIndex GetIndex()
        {
            return _PlayerIndex;
        }
        public GamePadState GetCurrentState()
        {
            return _State;
        }
        public GamePadState GetPrevState()
        {
            return _PrevState;
        }
        public void SetCurrentState(GamePadState curState)
        {
            _State = curState;
        }
        public void SetPrevState(GamePadState prevState)
        {
            _PrevState = prevState;
        }
        public bool GetIndexSet()
        {
            return _PlayerIndexSet;
        }
        public GameObject GetObject()
        {
            return gameObject;
        }
        public int GetScore()
        {
            return _Score;
        }
        public int AddScore(int score)
        {
            _Score += score;
            return _Score;
        }
        public int SubScore(int score)
        {
            _Score -= score;
            return _Score;
        }
        public int SetScore(int score)
        {
            _Score = score;
            return _Score;
        }
        public int GetGlobalScore()
        {
            return _GlobalScore;
        }
        public int AddGlobalScore(int score)
        {
            _GlobalScore += score;
            return _GlobalScore;
        }
        public int SubGlobalScore(int score)
        {
            _GlobalScore -= score;
            return _GlobalScore;
        }

    }
}
