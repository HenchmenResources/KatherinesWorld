using UnityEngine;
using System.Collections;

public class ZakSandbox : MonoBehaviour {

	public float waitTimer = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		StartCoroutine ( DeathReset());
	}

	private IEnumerator DeathReset (){
		Debug.Log ("Death Timer Go!");
		yield return new WaitForSeconds(5f);
		Application.LoadLevel(Application.loadedLevelName);
	}
}
