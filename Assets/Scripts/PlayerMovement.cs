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

	void Awake ()
	{
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		faceSprite = Resources.LoadAll<Sprite> ("Textures/hero");
		print (faceSprite.Length);
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

		if(horizontalRaw == 1)
		{
            _spriteRenderer.sprite = faceSprite[2];
		}
		else if(horizontalRaw == -1)
		{
            _spriteRenderer.sprite = faceSprite[0];
		}
		else
		{
            _spriteRenderer.sprite = faceSprite[1];
		}

        if (horizontal != 0) 
		{
			// prevent over lapping
			float xpos = transform.position.x + horizontal * Time.deltaTime * 5f;

			if(xpos < -3) xpos = -3;
			else if(xpos > 3) xpos = 3;

			transform.position = new Vector2(xpos, transform.position.y);
		}


    }
}
