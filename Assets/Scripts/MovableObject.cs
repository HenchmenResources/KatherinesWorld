using UnityEngine;
using System.Collections;

public class MovableObject : MonoBehaviour {

    public float pushPower = 0.5f;
    public bool isGrabbing = false;
	void OnControllerColliderHit (ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		// no rigidbody
		if (body == null || body.isKinematic)
			return;
			
		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3) 
			return; 
		
		// Calculate push direction from move direction, 
		// we only push objects on the X axis never the Y or Z
	    Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, 0);

		// If you know how fast your character is trying to move,
		// then you can also multiply the push velocity by that.
		
		// Apply the push
		body.velocity = pushDir * pushPower;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
