using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private Player _player;

	private float _setPosition = 5;
	private float _zLayer = -10;

	public float horizontal;

	// Use this for initialization
	void Start () {
		_player = Player.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (0, _player.transform.position.y - _setPosition, _zLayer);

		horizontal = Input.GetAxis("Horizontal") * 1.5f;
		transform.rotation = Quaternion.Euler(0, 0, horizontal);
	}
}
