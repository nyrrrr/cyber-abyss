using UnityEngine;
using System.Collections;

public class RobotFinalBoss : MonoBehaviour {


	private static RobotFinalBoss _singleton = null;
	
	static RobotFinalBoss() { }
	private RobotFinalBoss() { }
	
	public static RobotFinalBoss Instance
	{
		get
		{
			return _singleton;
		}
	}


	//
	// ;____; sorry, have to copy the one on horizontalmovement.cs rather than using that. >____<
	// It's giving me weird behavior and I don't want to lengthen the codes on that one
	//
	private BossProjectile _projectile;
	private Player _player;

	private bool _detectedPlayer = false;
	private float _moveToPlayer;

	private Transform _spawn;
	private GameObject _projectilePrefab, _projectilePrefabSuper, _projectileObject;
	private GameObject _floorPrefab, _floorPrefabObject;
	private float _idleTime;
	private bool _isShooting = false;

	
	// We use inspector. For level design
	public int _speed = 1;
	public int _life = 5;

	void Awake()
	{
		_singleton = this;

		_projectile = BossProjectile.Instance;
		_player = Player.Instance;
		
		_projectilePrefab = Resources.Load("Projectile") as GameObject;
		_projectilePrefabSuper = Resources.Load("SuperProjectile") as GameObject;
		_spawn = transform.FindChild("BossProjectile");

		// floor
		_floorPrefab = Resources.Load("Floor") as GameObject;
	}

	// Use this for initialization
	void Start () 
	{


	}




	// Update is called once per frame
	void Update () {
		_CheckPlayer ();
		_CanMove ();

		// life
		if(_life <= 0)
		{
			// set wall
			_floorPrefabObject = GameObject.Instantiate(_floorPrefab, new Vector2(0, transform.position.y - 10), Quaternion.Euler(Vector2.zero)) as GameObject;
			Destroy(gameObject);
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}
	
	
	#region custom
	private void _CheckPlayer()
	{
		if(transform.position.y > _player.transform.position.y - 15)
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
					if(Random.Range(0,5) > 1)
					{
						_projectileObject = GameObject.Instantiate(_projectilePrefab, _spawn.position, Quaternion.Euler(Vector2.zero)) as GameObject;
					}
					else 
					{
						_projectileObject = GameObject.Instantiate(_projectilePrefabSuper, _spawn.position, Quaternion.Euler(Vector2.zero)) as GameObject;
					}

					_isShooting = false;
				}

				_followX = 0;
			}

			transform.position = new Vector2(transform.position.x + (_followX * Time.deltaTime), _player.transform.position.y - 10);
		}
	}
	#endregion
}
