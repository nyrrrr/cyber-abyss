using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    //public enum GameState
    //{
    //    // those states were not chosen that cleverly... whatever... no time :D
    //    StartScreen, //title screen
    //    Story, // mode where story is told 
    //    Running, // alive n kickin
    //    //Paused, // playes just died or hasn't pressed a button so the current level starts
    //    GameOver // obvious..
    //};
    //private GameState _state;

    //private Player _player;

    //#region singleton pattern
    //private static volatile GameControl _singleton = null;
    //private static object _lock = new object();

    //static GameControl() { }
    //private GameControl() { }

    //public static GameControl Instance
    //{
    //    get
    //    {
    //        if (_singleton == null)
    //        {
    //            lock (_lock)
    //            {
    //                if (_singleton == null) _singleton = new GameControl();
    //            }
    //        }
    //        return _singleton;
    //    }
    //}
    //#endregion

    //// Use this for initialization
    //void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject); // prevent this class from being destroyed on scene load

    //    _player = Player.Instance;

    //    _state = GameState.Running; // for now

    //    // TODO doooo stuff
    //}

    //// Use this for initialization
    //void Start()
    //{
    //    // debug
    //    _state = GameState.Running;

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // TODO state check
    //    // TODO player alive?

    //    if (_state == GameState.GameOver && Input.anyKey)
    //    {
    //        Debug.Log("Reload level on death");
    //        Application.LoadLevel(Application.loadedLevel);
    //    }
    //}

    //void OnGUI()
    //{
    //    if (_state == GameState.GameOver)
    //    {
    //        GUI.Label(new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 10, 40, 20), "DEAD!");
    //        GUI.Label(new Rect((Screen.width / 2) - 60, (Screen.height / 2) + 10, 240, 20), "Any key for restart!");
    //    }
    //}

    //#region getter / setter
    //public GameState State
    //{
    //    get { return _state; }
    //    set { _state = value; }
    //}
    //#endregion
}
