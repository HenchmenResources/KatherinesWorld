using UnityEngine;
using System.Collections;

public class TutorialTrigger : MonoBehaviour {
	public GameObject bTutorialObject;
	public bool bTutorialSeen = false;
	public float bTutorialShowTime;
	public Texture2D bTutorialText;
	private bool bTutorialShowing = false;
	private float bTimer;
	//public string[] bGamePads = Input.GetJoystickNames();


	// Use this for initialization
	void Start () {
		bTutorialObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (bTutorialShowing && bTimer > Time.time) {
			bTutorialObject.SetActive (true);
		}else if (bTutorialShowing && bTimer < Time.time) {
			bTutorialObject.SetActive (false);
			bTutorialSeen = true;
			bTutorialShowing = false;
		}
	}

	void OnTriggerEnter () {
		if (!bTutorialSeen) {
			bTutorialShowing = true;
			bTimer = Time.time + bTutorialShowTime;
			bTutorialObject.GetComponent<Renderer>().material.SetTexture("_MainTex", bTutorialText);
		}
	}
}
