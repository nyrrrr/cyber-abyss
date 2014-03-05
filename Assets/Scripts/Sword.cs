using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.None;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("Destroyable")) {
            Destroy(col.gameObject);
        }
    }
}
