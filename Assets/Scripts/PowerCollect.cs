using UnityEngine;
using System.Collections;

public class PowerCollect : MonoBehaviour {

	//Setup available Powerups
	public enum bSetPower : int {Strength, Freeze, Light, Shield};
	public bSetPower SetPower;
	//private int OldPower = SetPower;
	public GameObject PowerManager;
	public Renderer rend;
	public GameObject bThisObject;


	//Setup Texture set for Powerups
	public Texture2D textureStrength;
	public Texture2D textureStrengthEmit;
	public Texture2D textureFreeze;
	public Texture2D textureFreezeEmit;
	public Texture2D textureLight;
	public Texture2D textureLightEmit;
	public Texture2D textureShield;
	public Texture2D textureShieldEmit;


	// Use this for initialization
	void Start () {
		rend = PowerManager.GetComponent<Renderer>();
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
	}
	
	// Update is called once per frame
	void Update () {

			switch (SetPower) {
			case bSetPower.Strength:
				bThisObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureStrength);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", textureStrengthEmit);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_EmissionColor", textureStrengthEmit);
				break;
			case bSetPower.Freeze:
				bThisObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureFreeze);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", textureFreezeEmit);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_EmissionColor", textureFreezeEmit);
				break;
			case bSetPower.Light:
				//Material.SetTexture("_MainTex", textureLight);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureLight);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", textureLightEmit);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_EmissionColor", textureLightEmit);
				break;
			case bSetPower.Shield:
				bThisObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureShield);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", textureShieldEmit);
				bThisObject.GetComponent<Renderer>().material.SetTexture("_EmissionColor", textureShieldEmit);
				break;
			default:
				break;
			}

	}

	void OnTriggerEnter () {
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
		ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
		switch (SetPower) {
		case bSetPower.Strength:
			powerupScript.bHasStrength = true;
			powerupScript.powersEnabled = true;
			if (!substance.GetProceduralBoolean ("EnableColorFade")) {
				substance.SetProceduralBoolean ("EnableColorFade", true);
				substance.RebuildTextures ();
			}
			powerupScript.selectPower ("Strength", powerupScript.colorStrength);
			break;
		case bSetPower.Freeze:
			powerupScript.bHasFreeze = true;
			powerupScript.powersEnabled = true;
			if (!substance.GetProceduralBoolean ("EnableColorFade")) {
				substance.SetProceduralBoolean ("EnableColorFade", true);
				substance.RebuildTextures ();
			}
			powerupScript.selectPower ("Freeze", powerupScript.colorFreeze);
			break;
		case bSetPower.Light:
			powerupScript.bHasLight= true;
			powerupScript.powersEnabled = true;
			if (!substance.GetProceduralBoolean ("EnableColorFade")) {
				substance.SetProceduralBoolean ("EnableColorFade", true);
				substance.RebuildTextures ();
			}
			powerupScript.selectPower ("Light", powerupScript.colorLight);
			break;
		case bSetPower.Shield:
			powerupScript.bHasShield = true;
			powerupScript.powersEnabled = true;
			if (!substance.GetProceduralBoolean ("EnableColorFade")) {
				substance.SetProceduralBoolean ("EnableColorFade", true);
				substance.RebuildTextures ();
			}
			powerupScript.selectPower ("Shield", powerupScript.colorShield);
			break;
		default:
			break;
		}
		Destroy (gameObject);
	}

}
