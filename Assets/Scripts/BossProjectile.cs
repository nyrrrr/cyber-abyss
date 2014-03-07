﻿using UnityEngine;
using System.Collections;

public class BossProjectile : MonoBehaviour {

	private static BossProjectile _singleton = null;
	
	static BossProjectile() { }
	private BossProjectile() { }
	
	public static BossProjectile Instance
	{
		get
		{
			return _singleton;
		}
	}


	public bool _moveDown = false;
	private Player _player;
	private RobotFinalBoss _masterBoss;
	private float _ypos = 0;
	private float _idle = 0;

	public bool _isSuper = false;

	// Use this for initialization
	void Awake () {
		_singleton = this;
	}

	void Start()
	{
		_player = Player.Instance;
		_masterBoss = RobotFinalBoss.Instance;

		if(_isSuper)
		{
			_idle = (Time.time * 1000) + 300;
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.layer == LayerMask.NameToLayer("Boss"))
		{
			print ("boss");
		} else 
		{
			print ("asd");
		}
	}


	// Update is called once per frame
	void Update () 
	{
		if(_isSuper)
		{
			if(_idle > Time.time * 1000)
			{
				transform.position = new Vector2(_masterBoss.transform.position.x, _masterBoss.transform.position.y + 1);
			}
		}
		else 
		{
			if(_moveDown)
			{
				_ypos -= 20 * Time.deltaTime;
				transform.position = new Vector2(_player.transform.position.x, _player.transform.position.y - 10);
			}
		}
	}


	public void MoveDown()
	{
		_moveDown = true;
		_ypos = 0;
	}

}
