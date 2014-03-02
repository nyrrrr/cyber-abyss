using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    public enum GameState { StartScreen, Story, Running, GameOver };
    private GameState _state;

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
        _state = GameState.StartScreen;
        // TODO doooo stuff
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region getter / setter
    public GameState State
    {
        get { return _state; }
        set { _state = value; }
    }
    #endregion
}
