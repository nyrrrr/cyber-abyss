using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) Application.LoadLevel("game");
	}

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 200, 200), "ENTER TITLE HERE");
    }

}
