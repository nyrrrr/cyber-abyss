using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private Player _player;
	private RobotFinalBoss _masterBoss;
	private GameObject _floor; 

	// Use this for initialization
	void Start () {
		_player = Player.Instance;
		_masterBoss = RobotFinalBoss.Instance;

		// We will just take the floor's gameobject. We don't need to code the Insatance. If it's okay
		_floor = GameObject.Find ("Floor");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (0, _player.transform.position.y - 5, -10);

	}
}
