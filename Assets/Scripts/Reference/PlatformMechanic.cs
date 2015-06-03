using UnityEngine;
using System.Collections;

public class PlatformMechanic : MonoBehaviour {
	
	// These private variables will store whether the player is on a platform, and what platform they are on
	private bool onPlatform = false;
	private GameObject platformObject;
	
	// A "late update" function gets fired off after all the other "update" functions in the game
	void LateUpdate (){
		
		// If the player is on a platform this frame access the platform through the stored platformObject (checking to make sure it's not null)
		if (onPlatform) {
			if (platformObject != null){
				
				// Retrieve the movement rate of the platform (with that "get" function we put in the other script)
				Vector3 movement = platformObject.GetComponent<MovingPlatform>().GetMovmentRate();
				
				// Set the movement to translate the character in the same direction, and by the same ammount, as the platform
				this.gameObject.transform.Translate(movement,Space.World);
			}
		}
	}
	
	// This function gets called once when the player collides with something, in our case once they jump onto a platform
	void OnControllerColliderHit(ControllerColliderHit hit) {
		
		// Check if the object we just collided with is a tagged as "moving"
		if (hit.gameObject.tag == "moving") {
			
			// set our private variables to keep track of whether we're on the platform, and a reference to the platform we are on
			onPlatform = true;
			platformObject = hit.gameObject;
			
			// If we're not on a "moving" object we must be on the ground, set the onPlatform variable to false so we don't move 
		}else {
			onPlatform = false;
		}
	}
}
