using UnityEngine;
using System.Collections;
/// <summary>
/// Handles player state
/// </summary>
public class Player : MonoBehaviour {

    int count;

    public enum PlayerState { // not sure about those three yet; want to use them instead of booleans
        Attacking,
        Falling,
        Dead,
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TestMethod();
	}

    private void TestMethod() {
        count += Time.frameCount;
        if (count % 120 == 0) GameObject.Instantiate(Resources.Load("CollidableDummy"), new Vector3(5, transform.position.y - 10, transform.position.z), Quaternion.Euler(Vector3.zero));
        Debug.Log(rigidbody2D.velocity);
    }
}
