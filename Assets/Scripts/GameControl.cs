using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    public enum GameState
    {
        StartScreen, //title screen
        Story, // mode where story is told 
        Running, // alive n kickin
        Paused, // playes just died or hasn't pressed a button so the current level starts
        GameOver // obvious..
    };
    private GameState _state;

    private Player _player;

    // singleton pattern
    private static volatile GameControl _singleton = null;
    private static object _lock = new object();

    static GameControl() { }
    private GameControl() { }

    public static GameControl Instance
    {
        get
        {
            if (_singleton == null)
            {
                lock (_lock)
                {
                    if (_singleton == null) _singleton = new GameControl();
                }
            }
            return _singleton;
        }
    }

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); // prevent this class from being destroyed on scene load

        _player = GameObject.Find("Hero").GetComponent<Player>();

        _state = GameState.Paused;

        // TODO doooo stuff
    }

    // Use this for initialization
    void Start()
    {
        // debug
        _state = GameState.Running;

    }

    // Update is called once per frame
    void Update()
    {
        // TODO state check
        // TODO player alive?

        if (_state == GameState.Paused && Input.GetKey(KeyCode.Return))
        {
            Debug.Log("Reload level on death");
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    #region getter / setter
    public GameState State
    {
        get { return _state; }
        set { _state = value; }
    }
    #endregion
}
