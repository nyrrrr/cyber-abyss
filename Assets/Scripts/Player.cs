using UnityEngine;
using System.Collections;
/// <summary>
/// Handles player state
/// </summary>
public class Player : MonoBehaviour
{
    private float slowFactor = 4f;
    private float slowTimeScale;
    int count;
    PlayerMovement movementComponent;

    #region singleton pattern
    private static volatile Player _singleton = null;
    private static object _lock = new object();

    static Player() { }
    private Player() { }

    public static Player Instance
    {
        get
        {
            return _singleton;
        }
    }
    #endregion

    public enum PlayerState
    { // not sure about those three yet; want to use them instead of booleans
        Attacking,
        Falling,
        Dead,
    }
    PlayerState state;
    private float slowFixedDelta;
    private float slowMaxDelta;
    

    // Use this for initialization
    void Awake()
    {
        // default values
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        Time.maximumDeltaTime = 0.3333333f;

        movementComponent = GetComponent<PlayerMovement>();

        // slow-mo stuff
        slowTimeScale = Time.timeScale / slowFactor;
        slowFixedDelta = Time.fixedDeltaTime / slowFactor;
        slowMaxDelta = Time.maximumDeltaTime / slowFactor;
    }

    // Update is called once per frame
    void Update()
    {
        //TestMethod();

        if (state == PlayerState.Dead)
        {
            if (Input.anyKeyDown)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            SlowDown();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		state = PlayerState.Dead;
        movementComponent.enabled = false;
        Debug.Log("DON'T FORGET THE DEATH ANIMATION! ;)");
    }

    void OnGUI()
    {
        if (state == PlayerState.Dead)
        {
            GUI.Label(new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 10, 40, 20), "DEAD!");
            GUI.Label(new Rect((Screen.width / 2) - 60, (Screen.height / 2) + 10, 240, 20), "Any key for restart!");
        }
    }

    #region custom
    public void SlowDown() {
        Time.timeScale = Mathf.Lerp(Time.deltaTime, slowTimeScale, Time.time);
        Time.fixedDeltaTime = slowFixedDelta;
        Time.maximumDeltaTime = slowMaxDelta;  

        // TODO create analogue method for increasing speed back to normal
    }

    /// <summary>
    /// DON'T YOU DARE FORGET REMOVING ME!!!!
	/// LOL! Now who's awesome at commenting?? haha! xD
    /// </summary>
    private void TestMethod()
    {
        // TODO remove later
		count += Time.frameCount;
        if (count % 180 == 0) GameObject.Instantiate(Resources.Load("DestroyableEnemyDummy"), new Vector3(5, transform.position.y - 10, transform.position.z), Quaternion.Euler(Vector3.zero));
    }
    #endregion
}
