using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {
	public GameObject Door;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = Door.GetComponent<Animator> ();
		anim.SetBool ("isClosed", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		//StartCoroutine ( TriggerAnimatorBool());
		anim.SetBool ("doOpen", true);
	}

	private IEnumerator TriggerAnimatorBool (){
		//anim.SetBool ("isClosed", false);
		anim.SetBool("doOpen", true);
		yield return null;
		anim.SetBool("doOpen", false);
		anim.SetBool("isOpen", true);
	}
}
