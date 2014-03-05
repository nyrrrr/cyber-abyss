using UnityEngine;
using System.Collections;

public class RobotMovementHorizontal : MonoBehaviour {

	private Player _player;
	private bool _detectedPlayer = false;
	private bool _stopForever = false;
	private float _followPlayer;

	public int _speed = 0; // We use inspector. For level design

	// Use this for initialization
	void Start () {
		_player = Player.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		_CheckPlayer ();
		_CanMove ();
	}


	#region custom
	private void _CheckPlayer()
	{
		if(!_stopForever)
		{
			if(transform.position.y > _player.transform.position.y - 10)
			{
				if(!_detectedPlayer)
				{
					_detectedPlayer = true;

					// this is weird xD
					float speed = 100; // milliseconds
					if(_speed == 1) 		speed = 200;
					else if(_speed == 2)	speed = 400;
					else if(_speed == 3)	speed = 600;
					else if(_speed == 4)	speed = 800;
					else if(_speed == 5)	speed = 1000;

					_followPlayer = (Time.time * 1000) + speed; 
				}
				
			}
		}
	}

	private void _CanMove()
	{
		if(_detectedPlayer)
		{
			int _followX = -2;
			if(transform.position.x < _player.transform.position.x) _followX = 2;

			transform.position = new Vector2(transform.position.x + (_followX * Time.deltaTime), _player.transform.position.y - 10);
			
			// I like to use Time x) sorry
			if(_followPlayer < Time.time * 1000)
			{
				_detectedPlayer = false;
				_stopForever = true;
			}
		}
	}

	#endregion
}
