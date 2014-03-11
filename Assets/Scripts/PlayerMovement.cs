using UnityEngine;
using System.Collections;
/// <summary>
/// obvious, right?
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    float horizontal, horizontalRaw;

	// sprites
	private Sprite[] faceSprite;
    private SpriteRenderer _spriteRenderer;
	private GameObject _sword;

	void Awake ()
	{
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		_sword = GameObject.Find ("Sword");
		faceSprite = Resources.LoadAll<Sprite> ("Textures/hero");
	}

    // Use this for initialization
    void Start()
    {
		horizontal = 0;
		horizontalRaw = 0;
    }

    // Update is called once per frame
    void Update()
    {
		horizontal = Input.GetAxis("Horizontal");
		horizontalRaw = Input.GetAxisRaw("Horizontal");


		int spriteIndex = 3;
		if(_sword.gameObject.GetComponent<Sword>()._isSwooshing)
		{
			spriteIndex = 0;
		}

		if(horizontalRaw == 1)
		{
			_spriteRenderer.sprite = faceSprite[spriteIndex + 2];
		}
		else if(horizontalRaw == -1)
		{
			_spriteRenderer.sprite = faceSprite[spriteIndex];
		}
		else
		{
			_spriteRenderer.sprite = faceSprite[spriteIndex + 1];
		}

		
		
		
		if (horizontal != 0) 
		{
			// prevent over lapping
			float xpos = transform.position.x + horizontal * Time.deltaTime * 5f;

			if(xpos < -3.2f) xpos = -3.2f;
			else if(xpos > 3.2f) xpos = 3.2f;

			transform.position = new Vector2(xpos, transform.position.y);
		}


    }
}
