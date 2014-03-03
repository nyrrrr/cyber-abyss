using UnityEngine;
using System.Collections;
/// <summary>
/// obvious, right?
/// </summary>
public class PlayerMovement : Player
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
            transform.position = new Vector2(transform.position.x + horizontal * Time.deltaTime * 5f, transform.position.y);

        }
    }
}
