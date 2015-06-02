using UnityEngine;
using System.Collections;

public class TwoPointMover : MonoBehaviour {

	public GameObject bTargetOne;
	public GameObject bTargetTwo;
	private GameObject bCurTarget;
	public float bSpeed = 2.0f;


	// Use this for initialization
	void Start () {
		bCurTarget = bTargetTwo;
	}
	
	// Update is called once per frame
	void Update () {
		float step = bSpeed * Time.deltaTime;
		float bDistance = Vector3.Distance (bCurTarget.transform.position, transform.position);
		if (bDistance < 0.5f) {
			if (bCurTarget == bTargetOne) {
				bCurTarget = bTargetTwo;
			}else{
				bCurTarget = bTargetOne;
			}
		}else{
			if (!gameObject.GetComponent<Rigidbody>().isKinematic) {
				transform.position = Vector3.MoveTowards(transform.position, bCurTarget.transform.position, step);
			}
		}
	}
}
