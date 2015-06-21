using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {
	private Animator anim;
	bool playerDead = false;
	public Texture deathMessage;


	void Start () {

	}

	void OnTriggerEnter(Collider other) {
		anim = other.GetComponent<Animator> ();
		if (other.tag == "Player") {
			anim.SetBool ("Dead", true);
			anim.SetBool ("isDead", true);
			playerDead = true;
			StartCoroutine ( DeathReset());
		}
	}

	void OnGUI () {
		if (playerDead) {
			GUI.DrawTexture(new Rect(Screen.width / 2 - 256, Screen.height / 3, 512, 128), deathMessage, ScaleMode.ScaleToFit);
			//GUI.DrawTexture(new Rect(10, 10, 512, 128), deathMessage, ScaleMode.ScaleToFit);
		}
	}

	private IEnumerator DeathReset (){
		Debug.Log ("Death Timer Go!");
		yield return new WaitForSeconds(5f);
		Application.LoadLevel(Application.loadedLevelName);
	}
}
