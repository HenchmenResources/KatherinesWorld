using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Awake () 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SpawnPlayer();
	}
	
	// Update is called once per frame
	public void SpawnPlayer () 
    {
        Player.transform.position = this.transform.position;
        //this.enabled = false;
	}
}
