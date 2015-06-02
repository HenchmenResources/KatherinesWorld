using UnityEngine;
using System.Collections;

public class ManaPickup : MonoBehaviour {
	public GameObject PowerManager;
	public float bManaAmount = 2.0f;


	void OnTriggerEnter () {
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
		if (powerupScript.manaPool < powerupScript.maxManaPool) {
			powerupScript.manaPool = powerupScript.manaPool + bManaAmount;
			Destroy (gameObject);
		}
	}
}
