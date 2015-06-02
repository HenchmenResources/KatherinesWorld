using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string playButton = "Play";
	public Texture playBtnText;
	public string loadButton = "Load";
	public Texture loadBtnText;
	public Texture quitBtnText;
	private bool isLoad = false;
	private float loadTime = 0.0F;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((loadTime + 5F) < Time.time) {
			isLoad = false;
			loadTime = 0F;
		}
	}

	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 60, 100, 30), playBtnText)) {
			Application.LoadLevel("Level1");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 30), loadBtnText)) {
			isLoad = true;
			loadTime = Time.time;
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 60, 100, 30), quitBtnText)) {
			Application.Quit();
		}
		if (isLoad) {
			GUI.Label(new Rect(Screen.width / 4, Screen.height / 5 * 4, Screen.width / 2, 20), "Load Functionality coming soon.");
		}
	}
}
