using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {

	private Player _player;
	
	private float _setPosition = 16;
	private float _zLayer = 100;
	private float _moveSlight;
	private bool _stopForever = false;
	
	// Use this for initialization
	void Start () {
		_player = Player.Instance;
	}
	
	// Update is called once per frame
	void Update () {


		if(_player.GetComponent<Player>().state != Player.PlayerState.End)
		{
			_moveSlight += 0.3f * Time.deltaTime;
			if(_moveSlight >= 14)
			{
				_moveSlight = 14;
			}
			transform.position = new Vector3 (0, _player.transform.position.y - _setPosition + _moveSlight, _zLayer);
		}
	}
}
