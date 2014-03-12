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

    // sounds
    public AudioClip sfx_death;
    private bool _audioOnce = false;
    private GUIStyle centeredStyle;
    public Font font;
    public string deathText;
    public string endReachedText;
    private GameObject _sound;

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

        _sound = GameObject.Find("Sound");
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
        else
        {
            // to prevent rotation
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // max velocity
        if (rigidbody2D.velocity.y <= -30)
        {
            rigidbody2D.velocity = new Vector2(0, -30);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        Death();

        if (col.transform.name == "Floor")
        {
            state = PlayerState.End;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Death();

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
        if (state == PlayerState.Dead || state == PlayerState.End)
        {
            centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;
            centeredStyle.font = font;
        }
        if (state == PlayerState.Dead)
        {
            GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 - 50, 400, 800), "<color=red><size=26>" + deathText + "</size></color>", centeredStyle);
            GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 + 50, 400, 800), "<color=white><size=15>Press any key to restart</size></color>", centeredStyle);
        }
        else if (state == PlayerState.End)
        {
            GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 - 50, 400, 800), "<color=red><size=18>CONGRATULATIONS!!!</size></color>", centeredStyle);
            GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 + 50, 400, 800), "<color=white><size=15>You wasted " + ((int)_sound.GetComponent<Counter>().counter / 60) + " minutes of your live to beat this game!</size></color>", centeredStyle);
        }
    }

    public void SlowDown()
    {
        Time.timeScale = Mathf.Lerp(Time.deltaTime, slowTimeScale, Time.time);
        Time.fixedDeltaTime = slowFixedDelta;
        Time.maximumDeltaTime = slowMaxDelta;
    }

    private void Death()
    {
        if (!_audioOnce)
        {
            _audioOnce = true;
            audio.PlayOneShot(sfx_death);
        }
        state = PlayerState.Dead;
        movementComponent.enabled = false;
    }
}
