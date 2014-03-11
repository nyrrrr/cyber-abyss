using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {

	private Player _player;
	
	private float _setPosition = 16;
	private float _zLayer = 100;
	private float _moveSlight;
	private bool _stopForever = false;

	private float horizontal;

	// BG: Uber fancy parallax x)
	private Transform bg0, bg1, bg2,bg3, moon;

	
	// Use this for initialization
	void Start () {
		_player = Player.Instance;

		bg0 = transform.FindChild ("bg0");
		bg1 = transform.FindChild ("bg1");
		bg2 = transform.FindChild ("bg2");
		bg3 = transform.FindChild ("bg3");
		moon = transform.FindChild ("moon");
	}
	
	// Update is called once per frame
	void Update () {


		if(_player.GetComponent<Player>().state != Player.PlayerState.End && _player.rigidbody2D.velocity.y < 0)
		{
			_moveSlight += 0.3f * Time.deltaTime;
			if(_moveSlight >= 14)
			{
				_moveSlight = 14;
			}


			transform.position = new Vector3 (0, _player.transform.position.y - _setPosition + _moveSlight, _zLayer);
			horizontal = Input.GetAxis("Horizontal") * 0.6f;
			moon.position = new Vector3 (Mathf.Lerp(moon.position.x, 0.1f - horizontal, Time.deltaTime), _player.transform.position.y + 2, _zLayer + 20);
			horizontal = Input.GetAxis("Horizontal") * 0.4f;
            bg0.position = new Vector3(Mathf.Lerp(bg0.position.x, 0f - horizontal, Time.deltaTime), _player.transform.position.y - _setPosition + _moveSlight - 1, _zLayer + 20);
			horizontal = Input.GetAxis("Horizontal") * 0.3f;
            bg1.position = new Vector3(Mathf.Lerp(bg1.position.x, 0f - horizontal, Time.deltaTime), _player.transform.position.y - _setPosition + _moveSlight - 2, _zLayer + 19);
			horizontal = Input.GetAxis("Horizontal") * 0.2f;
            bg2.position = new Vector3(Mathf.Lerp(bg2.position.x, 0f - horizontal, Time.deltaTime), _player.transform.position.y - _setPosition + _moveSlight - 3, _zLayer + 18);
			horizontal = Input.GetAxis("Horizontal") * 0.1f;
            bg3.position = new Vector3(Mathf.Lerp(bg3.position.x, 0f - horizontal, Time.deltaTime), _player.transform.position.y - _setPosition + _moveSlight - 4, _zLayer + 17);
		}
	}
}
