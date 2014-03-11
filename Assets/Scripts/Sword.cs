using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour
{
    private bool isBlocked = false;
    public float delay = 5f;

	private Player _player;

	// sounds
	public AudioClip sfx_swoosh;


    // Use this for initialization
    void Awake()
    {
        this.collider2D.enabled = false;
        renderer.enabled = false;
    }

	void Start()
	{
		_player = Player.Instance;
	}

    // Update is called once per frame
    void Update()
    {
		if(_player.GetComponent<Player>().state != Player.PlayerState.Dead && _player.GetComponent<Player>().state != Player.PlayerState.End)
		{
	        if (!isBlocked && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetMouseButtonDown(0)))
			{

	            StartCoroutine(SwordSwing());
	        }
		} 
    }
    /// <summary>
    /// sword swing with delay, so user can't simply keep the button pressed or press like a maniac
    /// </summary>
    /// <TODO>this method will need some fine-tuning</TODO>
    /// <returns></returns>
    private IEnumerator SwordSwing()
	{
		audio.PlayOneShot (sfx_swoosh);
        collider2D.enabled = true;
        isBlocked = true;
        renderer.enabled = true;

        yield return new WaitForSeconds(delay);

        collider2D.enabled = false;
        isBlocked = false;
        renderer.enabled = false;
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Destroyable"))
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            col.gameObject.GetComponent<BossProjectile>().MoveDown();
        }
    }
}
