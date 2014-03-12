using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {

    public double counter;

	// Use this for initialization
	void Awake () {
        counter = 0;
	}

    void Start() {
        StartCoroutine(Count());
    }
    IEnumerator Count() {
        while (true) {
            yield return new WaitForSeconds(1f);
            counter += (1 / Time.timeScale);
        }
    }
}
