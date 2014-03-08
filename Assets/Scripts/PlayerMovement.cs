using UnityEngine;
using System.Collections;
/// <summary>
/// obvious, right?
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    float horizontal;

    // Use this for initialization
    void Start()
    {
        horizontal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

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
