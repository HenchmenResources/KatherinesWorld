#pragma strict
var pushPower : float = 0.5;
var isGrabbing : boolean = false;
	function OnControllerColliderHit (hit : ControllerColliderHit) {
		var body : Rigidbody = hit.collider.attachedRigidbody;
		// no rigidbody
		if (body == null || body.isKinematic)
			return;
			
		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3) 
			return;
		
		// Calculate push direction from move direction, 
		// we only push objects on the X axis never the Y or Z
		var pushDir : Vector3 = Vector3 (hit.moveDirection.x, 0, 0);

		// If you know how fast your character is trying to move,
		// then you can also multiply the push velocity by that.
		
		// Apply the push
		body.velocity = pushDir * pushPower;
	}
function Start () {

}

function Update () {

}