using UnityEngine;
using System.Collections;

public class TutorialPlace : MonoBehaviour {
	public GameObject bPlayer;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (bPlayer.transform.position.x, bPlayer.transform.position.y + 1.5f, bPlayer.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (bPlayer.transform.position.x, bPlayer.transform.position.y + 1.5f, bPlayer.transform.position.z);
	}
}
