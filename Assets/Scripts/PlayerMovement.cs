using UnityEngine;
using System.Collections;
/// <summary>
/// obvious, right?
/// </summary>
public class PlayerMovement : Player {

    private float _horizontal = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
    void Update() {
        _horizontal = Input.GetAxis("Horizontal");
    }
	void FixedUpdate () {
        rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);

        if (_horizontal != 0) { 
            this.rigidbody2D.AddForce(Vector2.right * _horizontal * 800f);
        } 
	}
}
