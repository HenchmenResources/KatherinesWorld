using UnityEngine;
using System.Collections;

public class FreezeObject : MonoBehaviour {

	public GameObject PowerManager;
	public GameObject bThisObject;
	private Vector3 bStartPos;
	private bool bWait = false;
	// Use this for initialization
	void Start () {
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
		bStartPos = new Vector3(bThisObject.transform.position.x, bThisObject.transform.position.y, bThisObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
		if (powerupScript.enabledFreeze) {
			bThisObject.GetComponent<Rigidbody>().isKinematic = true;
		}else{
			bThisObject.GetComponent<Rigidbody>().isKinematic = false;
		}


		//TEST CODE This Code is for testing and makes the object fall 40 units then reset.
		if (bThisObject.transform.position.y < (bStartPos.x - 40)) {
			bThisObject.transform.position = bStartPos;
			bThisObject.GetComponent<Rigidbody>().isKinematic = true;
			bWait = true;
		}
		if (bWait) {
			bThisObject.GetComponent<Rigidbody>().isKinematic = false;
			bWait = false;
		}
		//END TEST CODE

	}
}
