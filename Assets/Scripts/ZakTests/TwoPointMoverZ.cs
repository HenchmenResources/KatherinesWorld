using UnityEngine;
using System.Collections;

public class TwoPointMoverZ : MonoBehaviour {

	public GameObject bTargetOne;
	public GameObject bTargetTwo;
	public GameObject bCurTarget;
	public bool canBeFrozen = true;
	public float bSpeed = 2.0f;
    public bool outgoing;
    public float bTriangleH;
    public float bTriangleX;
    public float bTriangleY;
    public float bAngle;
    public float bDistance;
    public float bDegrees;
	//private GameObject powerManager;

	// Use this for initialization
	void Start () {
		PowerUps powerupScript = GameObject.Find ("PowerManager").GetComponent<PowerUps> ();
		bCurTarget = bTargetTwo;
        bTriangleH = (bTargetTwo.transform.position - bTargetOne.transform.position).magnitude;
        bTriangleX = Mathf.Abs((bTargetTwo.transform.position.x - bTargetOne.transform.position.x));
        bTriangleY = Mathf.Abs((bTargetTwo.transform.position.y - bTargetOne.transform.position.y));
        bAngle = Mathf.Tan(bTriangleY / bTriangleX);
        if (float.IsNaN(bAngle))
            bAngle = Mathf.PI / 2;
        bDegrees = bAngle * (180 / Mathf.PI);
        outgoing = true;
	}
	
	// Update is called once per frame
	void Update () {
		PowerUps powerupScript = GameObject.Find ("PowerManager").GetComponent<PowerUps> ();
		if ((!powerupScript.enabledFreeze && canBeFrozen) || !canBeFrozen) {
			//ONLY MOVE FREEZABLE OBJECTS IF FREEZE IS NOT ENABLED
			float step = bSpeed * Time.deltaTime;
			bDistance = Vector3.Distance (bCurTarget.transform.position, transform.position);
			if (bDistance < 0.25f) {
				//CHANGE TARGET ONCE WE GET TO THE CURRENT TARGET
				if (bCurTarget == bTargetOne) {
					bCurTarget = bTargetTwo;
					outgoing = true;
				} else {
					bCurTarget = bTargetOne;
					outgoing = false;
				}
			} else {
				transform.position = Vector3.MoveTowards (transform.position, bCurTarget.transform.position, step);
			}
		}
	}
}
