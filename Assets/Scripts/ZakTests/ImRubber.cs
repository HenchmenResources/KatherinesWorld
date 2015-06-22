using UnityEngine;
using System.Collections;

public class ImRubber : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (youHittingMe ()) {

		} else {

		}
	
	}

	bool youHittingMe () {
			return Physics.Raycast (gameObject.transform.position, Vector3.right, 0.5f);
			return Physics.Raycast (gameObject.transform.position, Vector3.left, 0.5f);
	}
}
