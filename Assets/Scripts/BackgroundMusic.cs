using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	private static BackgroundMusic instance = null;
	public static BackgroundMusic Instance {
		get { return instance; }
	}

	public AudioClip[] musicFile;
	private int fileSelector = 0;
	AudioSource audio;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		StartCoroutine(playMusic ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator playMusic () {
		audio.PlayOneShot(musicFile[fileSelector]);
		yield return new WaitForSeconds(musicFile[fileSelector].length);
		fileSelector++;
		while (fileSelector == 1) {
			audio.PlayOneShot(musicFile[fileSelector]);
			yield return new WaitForSeconds(musicFile[fileSelector].length);
		}

	}
}
