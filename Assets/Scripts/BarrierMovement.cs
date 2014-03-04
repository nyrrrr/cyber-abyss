using UnityEngine;
using System.Collections;

public class BarrierMovement : MonoBehaviour {

	public bool _isLeft = true;
	private bool _canMove = false;
	private GameObject _player;

	// Use this for initialization
	void Awake () {
		// I'm get NullReferenceError when I use 
		_player = GameObject.Find("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		_CheckPosition ();
		_CanMove ();
	}


	#region custom
	private void _CheckPosition()
	{
		if(transform.position.y > _player.transform.position.y - 10)
		{
			_canMove = true;
		}
	}

	private void _CanMove()
	{
		if(_canMove)
		{
			float xpos;
			
			if (_isLeft) xpos = -1; 
			else xpos = 1;
			
			transform.position = new Vector2(transform.position.x + xpos * Time.deltaTime * 10f, transform.position.y);
		}
	}
	#endregion
}
