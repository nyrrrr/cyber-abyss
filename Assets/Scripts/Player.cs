using UnityEngine;
using System.Collections;
/// <summary>
/// Handles player state
/// </summary>
public class Player : MonoBehaviour
{
    private float slowFactor = 4f;
    private float slowTimeScale;
    PlayerMovement movementComponent;

    private static Player _singleton = null;

    static Player() { }
    private Player() { }

    public static Player Instance
    {
        get
        {
            return _singleton;
        }
    }

    public enum PlayerState
    { // not sure about those three yet; want to use them instead of booleans
        Attacking,
        Falling,
        Dead,
		End,
    }
    public PlayerState state;
    private float slowFixedDelta;
    private float slowMaxDelta;

    // Use this for initialization
    void Awake()
    {
        _singleton = this;

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
		if (state == PlayerState.Dead || state == PlayerState.End)
        {
            if (Input.anyKeyDown)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            SlowDown();
        }

        // max velocity
        if (rigidbody2D.velocity.y <= -30)
        {
            rigidbody2D.velocity = new Vector2(0, -30);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        state = PlayerState.Dead;
        movementComponent.enabled = false;

		print (col.transform.name);
		if(col.transform.name == "Floor")
		{
			state = PlayerState.End;
		}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        state = PlayerState.Dead;
        movementComponent.enabled = false;

        if (col.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            if (!col.gameObject.GetComponent<BossProjectile>()._moveDown)
            {
                Destroy(col.gameObject);
            }
        }
    }


    void OnGUI()
    {
		if (state == PlayerState.Dead)
		{
			GUI.Label(new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 10, 40, 20), "DEAD!");
			GUI.Label(new Rect((Screen.width / 2) - 60, (Screen.height / 2) + 10, 240, 20), "Any key for restart!");
		}
		else if (state == PlayerState.End)
		{
			GUI.Label(new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 10, 40, 20), "YAY!");
			GUI.Label(new Rect((Screen.width / 2) - 60, (Screen.height / 2) + 10, 240, 20), "Now what? :O");
		}
    }

    public void SlowDown()
    {
        Time.timeScale = Mathf.Lerp(Time.deltaTime, slowTimeScale, Time.time);
        Time.fixedDeltaTime = slowFixedDelta;
        Time.maximumDeltaTime = slowMaxDelta;
    }
}
