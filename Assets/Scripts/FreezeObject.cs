using UnityEngine;
using System.Collections;

public class FreezeObject : MonoBehaviour {

	public GameObject PowerManager;
	public GameObject bThisObject;
	private Vector3 bStartPos;
	private bool bWait = false;
    public float storedRate;
	// Use this for initialization
	void Start () {
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
        storedRate = bThisObject.GetComponent<TwoPointMover>().bSpeed;
		bStartPos = new Vector3(bThisObject.transform.position.x, bThisObject.transform.position.y, bThisObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		PowerUps powerupScript = PowerManager.GetComponent<PowerUps> ();
		if (powerupScript.enabledFreeze) {
			bThisObject.GetComponent<TwoPointMover>().bSpeed = 0.0f;
		}else{
            bThisObject.GetComponent<TwoPointMover>().bSpeed = storedRate;
		}


        ////TEST CODE This Code is for testing and makes the object fall 40 units then reset.
        //if (bThisObject.transform.position.y < (bStartPos.x - 40)) {
        //    bThisObject.transform.position = bStartPos;
        //    bThisObject.GetComponent<Rigidbody>().isKinematic = true;
        //    bWait = true;
        //}
        //if (bWait) {
        //    bThisObject.GetComponent<Rigidbody>().isKinematic = false;
        //    bWait = false;
        //}
        ////END TEST CODE

	}

    //void OnGUI()
    //{
    //    GUI.Label(new Rect(0, 0, 100, 100), storedRate);
    //    GUI.Label(new Rect(20, 20, 100, 100), bThisObject.GetComponent<TwoPointMover>().bSpeed);
    //}
}
