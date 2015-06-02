using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {
	public GameObject PlayerChar;
	//SETUP RENDERER
	public Renderer rend;
	//SETUP MANA POOL
	public float manaPool = 100F;
	public float maxManaPool = 100F;
	//public GUIStyle : myGUIStyle;

	//Track Color change direction
	public bool useColor1 = true; //Tells us which direction to move gradient
	public bool bColorChange = false;
	public float colorFadeLow; //private
	public float colorFadeHigh;
	public float colorFadeMid;
	public float fadeSpeed = 0.1f;

	private string loadedPower;

	public bool powersEnabled = false;

	//Track if the player has collected a power.
	public bool bHasStrength = false;
	public bool bHasFreeze = false;
	public bool bHasLight = false;
	public bool bHasShield = false;
	
	//Tracking variables used to determine when poweres are enabled
	public bool enabledStrength = false;
	public bool enabledFreeze = false;
	public bool enabledLight = false;
	public bool enabledShield = false;
	//Variables for tracking the start time of powerups
	public float timerStrength = 0.0F; //Private
	public float timerFreeze = 0.0F; //Private
	public float timerLight = 0.0F; //Private
	public float timerShield = 0.0F; //Private
	//Amount of time each power should last
	public float maxTimeStrength = 10F;
	public float maxTimeFreeze = 10F;
	public float maxTimeLight = 10F;
	public float maxTimeShield = 10F;
	//Amount of mana each power should use
	public float manaStrength = 15F;
	public float manaFreeze = 15F;
	public float manaLight = 0.01F;
	public float manaShield = 0.01F;
	//SETUP Color arrays
	public Color colorStrength;
	public Color colorFreeze;
	public Color colorLight;
	public Color colorShield;
	//Setup Reference to Particle Emiters
	private GameObject particleStrength;

	public bool ShowMatProp = false;
	public bool bOnScreenPowers = false;


	void Start() {
		colorFadeLow = 0.0f;
		colorFadeHigh = 0.0f;
		colorFadeMid = 0.5f;
		rend = GetComponent<Renderer>();
		ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
		//Setup initial Power Color in slot 2
		substance.SetProceduralFloat("DressFadeHigh", colorFadeHigh);
		substance.SetProceduralFloat("DressFadeMid", colorFadeMid);
		substance.SetProceduralFloat("DressFadeLow", colorFadeLow);
		substance.RebuildTextures();
		particleStrength = PlayerChar.transform.Find("Flames").gameObject;
		//colorStrength [0] = 1.0F;
		//colorStrength [1] = 0.0F;
		//colorStrength [2] = 0.0F;
		//colorStrength [3] = 1.0F;
		//colorFreeze [0] = 0.271F;
		//colorFreeze [1] = 0.831F;
		//colorFreeze [2] = 1.0F;
		//colorFreeze [3] = 1.0F;
		//colorLight [0] = 1.0F;
		//colorLight [1] = 1.0F;
		//colorLight [2] = 0.737F;
		//colorLight [3] = 1.0F;
		//colorShield [0] = 0.745F;
		//colorShield [1] = 1.0F;
		//colorShield [2] = 0.737F;
		//colorShield [3] = 1.0F;

	}

	void Update () {

		//Use selected power.
		if (Input.GetKeyDown (KeyCode.Mouse0) && loadedPower != null) {
			if (loadedPower == "Strength") {
				if (!enabledStrength && manaPool >= manaStrength) {
					enablePower ("Strength");
					manaPool = manaPool - manaStrength;
				}
			}
			if (loadedPower == "Freeze") {
				if (!enabledFreeze && manaPool >= manaFreeze) {
					enablePower ("Freeze");
					manaPool = manaPool - manaFreeze;
				}
			}
			if (loadedPower == "Light") {
				if (!enabledLight && manaPool >= manaLight) {
					enablePower ("Light");
				}else{
					disablePower ("Light");
				}
			}
			if (loadedPower == "Shield") {
				if (!enabledShield && manaPool >= manaShield) {
					enablePower ("Shield");
				}else{
					disablePower ("Shield");
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.F1) && bHasStrength) {
			selectPower ("Strength", colorStrength);
		}
		if (Input.GetKeyDown (KeyCode.F2) && bHasFreeze) {
			selectPower ("Freeze", colorFreeze);
		}
		if (Input.GetKeyDown (KeyCode.F3) && bHasLight) {
			selectPower ("Light", colorLight);
		}
		if (Input.GetKeyDown (KeyCode.F4) && bHasShield) {
			selectPower ("Shield", colorShield);
		}

		//Mana drain when using Light power Up
		if (enabledLight) {
			manaPool = manaPool - manaLight;
		}
		
		//Manage Timer for Strength Power UP
		if (enabledStrength && (maxTimeStrength + timerStrength) < Time.time) {
			disablePower("Strength");
		}

		//Manage Timer for Freeze Power UP
		if (enabledFreeze && (maxTimeFreeze + timerFreeze) < Time.time) {
			disablePower("Freeze");
		}

		//Mana drain when using Shield power Up
		if (enabledShield) {
			manaPool = manaPool - manaShield;
		}

		//Fade colors
		ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
		if (bColorChange) {
			if (useColor1) {
				if (colorFadeHigh < 1.0) {
					if (colorFadeLow < 1.0) {
						colorFadeLow = colorFadeLow + fadeSpeed;
						substance.SetProceduralFloat("DressFadeLow", colorFadeLow);
						substance.RebuildTextures();
					}else{
						colorFadeHigh = colorFadeHigh + fadeSpeed;
						substance.SetProceduralFloat("DressFadeHigh", colorFadeHigh);
						substance.RebuildTextures();
					} 
				} else {
					bColorChange = false;
					useColor1 = false;
					colorFadeHigh = 1.0f;
					colorFadeLow = 1.0f;
				}
			}else{
				if (colorFadeHigh > 0.0) {
					if (colorFadeLow > 0.0) {
						colorFadeLow = colorFadeLow - fadeSpeed;
						substance.SetProceduralFloat("DressFadeLow", colorFadeLow);
						substance.RebuildTextures();
					}else{
						colorFadeHigh = colorFadeHigh - fadeSpeed;
						substance.SetProceduralFloat("DressFadeHigh", colorFadeHigh);
						substance.RebuildTextures();
					} 
				} else {
					bColorChange = false;
					useColor1 = true;
					colorFadeHigh = 0.0f;
					colorFadeLow = 0.0f;
				}
			}
		}

		if (enabledFreeze) {

		}
		
	}

	void OnGUI() {
		if (ShowMatProp) {
			if (rend.sharedMaterial as ProceduralMaterial) {
				Rect windowRect = new Rect (Screen.width - 250, 30, 220, Screen.height - 60);
				GUI.Window (0, windowRect, ProceduralPropertiesGUI, "Procedural Properties");
			}
		}
		if (bOnScreenPowers) {
			ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
			if (GUI.Button (new Rect (25, 60, 100, 30), "Strength") && bHasStrength) {
				selectPower ("Strength", colorStrength);
			}

			if (GUI.Button (new Rect (25, 95, 100, 30), "Freeze") && bHasFreeze) {
				selectPower ("Freeze", colorFreeze);
			}
		
			if (GUI.Button (new Rect (25, 130, 100, 30), "Light") && bHasLight) {
				selectPower ("Light", colorLight);
			}
		
			if (GUI.Button (new Rect (25, 165, 100, 30), "Shield") && bHasShield) {
				selectPower ("Shield", colorShield);
			}

			GUI.Label (new Rect (25, 213, 100, 30), "Dress Fade Mid");
			float DressColorMid = substance.GetProceduralFloat ("DressFadeMid");
			float oldInputFloat = DressColorMid;
			DressColorMid = GUI.HorizontalSlider (new Rect (25, 200, 100, 30), DressColorMid, 0.0F, 1.0F);
		
			if (oldInputFloat != DressColorMid) {
				substance.SetProceduralFloat ("DressFadeMid", DressColorMid);
				substance.RebuildTextures ();
			}
		}
		
		//Mana Bar
		GUI.Box (new Rect (25, 25, manaPool * 2F, 20), "Mana " + Mathf.Round((manaPool/maxManaPool)*100F).ToString() + "%");
	}

	void ProceduralPropertiesGUI (int windowId) {
		ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
		ProceduralPropertyDescription[] inputs = substance.GetProceduralPropertyDescriptions();
		int i = 0;
		while (i < inputs.Length) {
			ProceduralPropertyDescription input = inputs[i];
			ProceduralPropertyType type = input.type;
			GUILayout.Label(input.name);
			i++;
		}
	}

	public void selectPower (string powerName, Color newColor) {
		ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
		if (!bColorChange) {
			if (useColor1) {
				if (substance) {
					substance.SetProceduralColor ("DressColor1", newColor);
					substance.RebuildTextures ();
				}
			} else {
				if (substance) {
					substance.SetProceduralColor ("DressColor2", newColor);
					substance.RebuildTextures ();
				}
			}
			bColorChange = true; //initiate color fade
			loadedPower = powerName;
		}
	}

	void enablePower (string PowerUp) {
		switch (PowerUp) {
		case "Strength":
			timerStrength = Time.time;
			enabledStrength = true;
			particleStrength.GetComponent<ParticleSystem>().Play();
			break;
		case "Freeze":
			timerFreeze = Time.time;
			enabledFreeze = true;
			break;
		case "Light":
			timerLight = Time.time;
			enabledLight = true;
			break;
		case "Shield":
			timerShield = Time.time;
			enabledShield = true;
			break;
		}
		
		//For freeze time objects
	}
	
	void disablePower (string PowerUp) {
		switch (PowerUp) {
		case "Strength":
			timerStrength = 0.0F;
			enabledStrength = false;
			particleStrength.GetComponent<ParticleSystem>().Stop();
			break;
		case "Freeze":
			timerFreeze = 0.0F;
			enabledFreeze = false;
			break;
		case "Light":
			timerLight = 0.0F;
			enabledLight = false;
			break;
		case "Shield":
			timerShield = 0.0F;
			enabledShield = false;
			break;
		}
	}

}