using UnityEngine;
using System.Collections;

public class PlayIntro : MonoBehaviour {
	public GameObject Katherine;

	//These Are for Testing purposes
	public bool bPlayIntro = false;
	public bool bPlaySleep = false;
	//END TESTING VARIABLES

	public bool introHasPlayed = false;
	private Animator anim;

	private static PlayIntro instance = null;
	public static PlayIntro Instance {
		get { return instance; }
	}




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
		anim = Katherine.GetComponent<Animator> ();
		Katherine = GameObject.Find ("Katherine_Intro");
	}
	
	// Update is called once per frame
	void Update () {
		if (introHasPlayed) {
			//PLAY THE SLEEP ANIMATION
			anim.SetBool("Sleep", true);
		}else{
			//PLAY THE INTRO ANIMATION
			StartCoroutine ( playIntroduction ());
		}
		if (bPlayIntro) {
			StartCoroutine ( playIntroduction ());
		}
	}

	private IEnumerator playIntroduction (){
		anim = Katherine.GetComponent<Animator> ();
		anim.SetBool("intro", true);
		yield return null;
		anim.SetBool(name, false);
		introHasPlayed = true;
	}
}
