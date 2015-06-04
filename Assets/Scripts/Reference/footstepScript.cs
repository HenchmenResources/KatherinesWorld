using UnityEngine;
using System.Collections;

public class footstepScript : MonoBehaviour {
	public AudioClip AudioFile;
	
	void  Update (){
		
		if (Input.GetKeyDown (KeyCode.W)) {
			//Debug.Log("Playing");
			GetComponent<AudioSource> ().clip = AudioFile;
			GetComponent<AudioSource> ().Play ();			//audio.Play();
			
		} else if ( Input.GetKeyUp (KeyCode.W)){
			//Debug.Log("Stopped");
			GetComponent<AudioSource> ().Stop ();	

		}
		
	}
}