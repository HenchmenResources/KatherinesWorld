using UnityEngine;
using System.Collections;

public class MapEnd : MonoBehaviour {

	public GameObject SuccessNotice;
	public float SuccessTime = 3f;
	public int nextMap;
	private bool bMapDone = false;
	private float endTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bMapDone) {
			SuccessNotice.SetActive (true);
			if (Input.anyKey && (endTimer+5 < Time.time)) {
				//Application.LoadLevel(nextMap);
				Application.LoadLevel ("worldMap");
			}
		}
	
	}

	void OnTriggerEnter() {
		bMapDone = true;
		endTimer = Time.time;
	}	
}
