using UnityEngine;
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


	// Use this for initialization
	void Awake () {
		_singleton = this;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
