using UnityEngine;
using System.Collections;

public class TwoPointMoverZ : MonoBehaviour {

	public GameObject bTargetOne;
	public GameObject bTargetTwo;
	public GameObject bCurTarget;
	public bool canBeFrozen = true;
	public float bSpeed = 2.0f;
    public float bDistance;
	Vector3 oldPos;
	Vector3 newPos;
	Vector3 media;
	[HideInInspector] public Vector3 velocity;
	//private GameObject powerManager;

	// Use this for initialization
	void Start () {
		PowerUps powerupScript = GameObject.Find ("PowerManager").GetComponent<PowerUps> ();
		bCurTarget = bTargetTwo;
		oldPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		PowerUps powerupScript = GameObject.Find ("PowerManager").GetComponent<PowerUps> ();
		if ((!powerupScript.enabledFreeze && canBeFrozen) || !canBeFrozen) {
			//ONLY MOVE FREEZABLE OBJECTS IF FREEZE IS NOT ENABLED
			float step = bSpeed * Time.deltaTime;
			bDistance = Vector3.Distance (bCurTarget.transform.position, transform.position);
			if (bDistance < 0.25f) {
				//START CHANGE TARGET ONCE WE GET TO THE CURRENT TARGET
				if (bCurTarget == bTargetOne) {
					bCurTarget = bTargetTwo;
				} else {
					bCurTarget = bTargetOne;
				}
				//END CHANGE TARGET ONCE WE GET TO THE CURRENT TARGET
			} else {
				//Move the Platform towars current target
				transform.position = Vector3.MoveTowards (transform.position, bCurTarget.transform.position, step);
			}
		}
		//START Calculate the velocity of the mover
		newPos = transform.position;
		media = newPos - oldPos;
		velocity = media / Time.deltaTime;
		oldPos = newPos;
		newPos = transform.position;
		//END Calculate the velocity of the mover
	}
}
