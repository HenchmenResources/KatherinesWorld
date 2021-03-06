﻿using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {
	public GameObject Door;
	public bool isLocked = false;
	public bool hasKey = false;
	public string keyname;

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = Door.GetComponent<Animator> ();
		anim.SetBool ("isClosed", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			if (!isLocked) {
				anim.SetBool ("doOpen", true);
			}
			if (isLocked && hasKey) {
				anim.SetBool ("doOpen", true);
			}
		}
	}
}
