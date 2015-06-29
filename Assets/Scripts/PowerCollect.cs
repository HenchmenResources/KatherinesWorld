using UnityEngine;
using System.Collections;

public class PowerCollect : MonoBehaviour {

	//Setup available Powerups
	public enum bSetPower : int {Strength, Freeze, Light, Shield};
	public bSetPower SetPower;
	public GameObject PowerManager;
	private Renderer rend;


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
		PowerManager = GameObject.Find ("PowerManager");
		rend = PowerManager.GetComponent<Renderer>();
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
	}
	
	// Update is called once per frame
	void Update () {

		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
		rend = PowerManager.GetComponent<Renderer>();
			switch (SetPower) {
			case bSetPower.Strength:
				gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureStrength);
				gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", textureStrengthEmit);
				gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionColor", textureStrengthEmit);
				break;
			case bSetPower.Freeze:
				gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureFreeze);
				gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", textureFreezeEmit);
				gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionColor", textureFreezeEmit);
				break;
			case bSetPower.Light:
				//Material.SetTexture("_MainTex", textureLight);
				gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureLight);
				gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", textureLightEmit);
				gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionColor", textureLightEmit);
				break;
			case bSetPower.Shield:
				gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureShield);
				gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", textureShieldEmit);
				gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionColor", textureShieldEmit);
				break;
			default:
				break;
			}

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player"){
			PowerManager = GameObject.Find ("PowerManager");
			rend = PowerManager.GetComponent<Renderer>();
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
		ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
		switch (SetPower) {
		case bSetPower.Strength:
			powerupScript.bHasStrength = true;
			powerupScript.powersEnabled = true;
			if (!substance.GetProceduralBoolean ("EnablePowers")) {
				substance.SetProceduralBoolean ("EnablePowers", true);
				substance.RebuildTextures ();
			}
			powerupScript.selectPower ("Strength", powerupScript.colorStrength);
			break;
		case bSetPower.Freeze:
			powerupScript.bHasFreeze = true;
			powerupScript.powersEnabled = true;
			if (!substance.GetProceduralBoolean ("EnablePowers")) {
				substance.SetProceduralBoolean ("EnablePowers", true);
				substance.RebuildTextures ();
			}
			powerupScript.selectPower ("Freeze", powerupScript.colorFreeze);
			break;
		case bSetPower.Light:
			powerupScript.bHasLight = true;
			powerupScript.powersEnabled = true;
			if (!substance.GetProceduralBoolean ("EnablePowers")) {
				substance.SetProceduralBoolean ("EnablePowers", true);
				substance.RebuildTextures ();
			}
			powerupScript.selectPower ("Light", powerupScript.colorLight);
			break;
		case bSetPower.Shield:
			powerupScript.bHasShield = true;
			powerupScript.powersEnabled = true;
			if (!substance.GetProceduralBoolean ("EnablePowers")) {
				substance.SetProceduralBoolean ("EnableCPowers", true);
				substance.RebuildTextures ();
			}
			powerupScript.selectPower ("Shield", powerupScript.colorShield);
			break;
		default:
			break;
		}
			Debug.Log ("Power Added");
		Destroy (gameObject);
	}
	}

}
