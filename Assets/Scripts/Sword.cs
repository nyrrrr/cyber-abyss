using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour
{
    private bool isBlocked = false;
    public float delay = 5f;

	private Player _player;
	public bool _isSwooshing = false;

	// Sprites
	private Sprite[] swordSprite;
	private SpriteRenderer _spriteRenderer;
	private float _animTime, _anim = 80;
	private int _animctr = 0;
	
	// sounds
	public AudioClip sfx_swoosh, sfx_enemyHit, sfx_ricochet;

    // Use this for initialization
    void Awake()
    {
        this.collider2D.enabled = false;
        renderer.enabled = false;

		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		swordSprite = Resources.LoadAll<Sprite> ("Textures/sword");
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
				if(!_isSwooshing)
				{
					_isSwooshing = true;
					_animTime = (Time.time * 1000) + _anim;
					_animctr = 0;
				}
	            StartCoroutine(SwordSwing());
	        }
		}


		// animation : hard code >__< sorry
		if(_isSwooshing)
		{
			if(_animTime < Time.time * 1000)
			{
				_animTime = (Time.time * 1000) + _anim;
				_animctr++;
			}
			_spriteRenderer.sprite = swordSprite[_animctr];
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
		_isSwooshing = false;
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Destroyable"))
        {
            Destroy(col.gameObject);
			audio.PlayOneShot (sfx_enemyHit);
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Projectile"))
		{
			audio.PlayOneShot (sfx_ricochet);
			col.gameObject.GetComponent<BossProjectile>().MoveDown();
        }
    }
}
