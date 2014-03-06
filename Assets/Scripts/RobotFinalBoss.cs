using UnityEngine;
using System.Collections;

public class RobotFinalBoss : MonoBehaviour {

	private BossProjectile _projectile;
	private Player _player;

	private Transform _spawn;
	private GameObject _projectilePrefab, _projectileObject;
	private float _idleTime;
	private bool _isShooting = false;


	//
	// ;____; sorry, have to copy the one on horizontalmovement.cs rather than using that. >____<
	// It's giving me weird behavior and I don't want to lengthen the codes on that one
	//
	private bool _detectedPlayer = false;
	private float _moveToPlayer;
	
	
	// We use inspector. For level design
	public int _speed = 2; // speed if it follows player


	// Use this for initialization
	void Start () 
	{
		_projectile = BossProjectile.Instance;
		_player = Player.Instance;

		_projectilePrefab = Resources.Load("Projectile") as GameObject;
		_spawn = transform.FindChild("BossProjectile");

	}

	// Update is called once per frame
	void Update () {
		_CheckPlayer ();
		_CanMove ();
	}
	
	
	#region custom
	private void _CheckPlayer()
	{
		if(transform.position.y > _player.transform.position.y - 10)
		{
			if(!_detectedPlayer)
			{
				_detectedPlayer = true;
			}
		}
	}
	
	private void _CanMove()
	{
		if(_detectedPlayer)
		{
			int _followX = -(_speed);
			if(transform.position.x < _player.transform.position.x) _followX = _speed;
			if(transform.position.x < _player.transform.position.x + 0.2 &&
			   transform.position.x > _player.transform.position.x - 0.2) 
			{
				if(!_isShooting)
				{
					_isShooting = true;
					_idleTime = (Time.time * 1000) + 800;
				}
			}

			if(_isShooting)
			{
				if(_idleTime < Time.time * 1000)
				{
					_projectileObject = GameObject.Instantiate(_projectilePrefab, _spawn.position, Quaternion.Euler(Vector2.zero)) as GameObject;
					_isShooting = false;
				}

				_followX = 0;
			}

			transform.position = new Vector2(transform.position.x + (_followX * Time.deltaTime), _player.transform.position.y - 10);
		}
	}
	#endregion
}
