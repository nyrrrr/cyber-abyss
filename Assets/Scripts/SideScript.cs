using UnityEngine;
using System.Collections;

public class SideScript : MonoBehaviour {

	private Player _player;
	private GameObject _sidePrefab, _sidePrefabObject;
	private bool _canCreate = true;
	
	// Use this for initialization
	void Start () {
		_player = Player.Instance;
		_sidePrefab = Resources.Load("SideObject") as GameObject;

		transform.position = new Vector3 (0, _player.transform.position.y - 20, 10);
	}
	
	// Update is called once per frame
	void Update () {
		//

		if(transform.position.y > _player.transform.position.y + 3 && _canCreate)
		{
			if(_canCreate)
			{
				_sidePrefabObject = GameObject.Instantiate(_sidePrefab, new Vector2(0, _player.transform.position.y - 20), Quaternion.Euler(Vector2.zero)) as GameObject;
				_canCreate = false;
			}
		}

		if(transform.position.y > 36 && !_canCreate)
		{
			Destroy(gameObject);
		}
	}
}
