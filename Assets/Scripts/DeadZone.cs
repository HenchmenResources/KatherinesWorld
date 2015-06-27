using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {
	private Animator anim;
	//bool playerDead = false;
	public Texture deathMessage;
	public float deathTimer = 4f;


	void Start () {

	}

	void OnTriggerEnter(Collider other) {
		AnimatorTest PlayControl = GameObject.Find ("Katherine").GetComponent<AnimatorTest> ();
		anim = other.GetComponent<Animator> ();
		if (other.gameObject.tag == "Player") {
			anim.SetBool ("Dead", true);
			anim.SetBool ("isDead", true);
			PlayControl.playerDead = true;
			StartCoroutine ( DeathReset());
		}
	}

	void OnGUI () {
		AnimatorTest PlayControl = GameObject.Find ("Katherine").GetComponent<AnimatorTest> ();
		if (PlayControl.playerDead) {
			GUI.DrawTexture(new Rect(Screen.width / 2 - 256, Screen.height / 3, 512, 128), deathMessage, ScaleMode.ScaleToFit);
			//GUI.DrawTexture(new Rect(10, 10, 512, 128), deathMessage, ScaleMode.ScaleToFit);
		}
	}

	private IEnumerator DeathReset (){
		yield return new WaitForSeconds(deathTimer);
		Application.LoadLevel(Application.loadedLevelName);
	}
}
