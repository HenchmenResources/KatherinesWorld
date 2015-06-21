using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {
	private Animator anim;

	void Start () {

	}

	void OnTriggerEnter(Collider other) {
		anim = other.GetComponent<Animator> ();
		if (other.tag == "Player") {
			anim.SetBool ("Dead", true);
			anim.SetBool ("isDead", true);
			Debug.Log ("You Died");
		}
	}
}
