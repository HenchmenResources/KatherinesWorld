using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	
	// Two public variables that we can set in the editor (on a per-instance basis to change the properties of each platform we drop in the level).
	public Vector3 direction;    // Controls the direction in X/Y/Z coordinates 
	public int movementTime;    // Controls the duration (in sectonds) that the platform will move for before returning
	
	// Private variables to track the timing, direction & movement rate of the platform 
	private float timer = 0;
	private bool outgoing = true;
	private Vector3 movementRate;
	
	// Our main update loop, this will fire every frame (30 times a second ideally)
	void Update () {
		
		// If the platform is outgoing aka. moving from its origin toward its destination
		if (outgoing) {
			
			// Basic "Translate" function that will move the object in 3D space by the ammounds specified in the Vector3 (X,Y,Z)
			// Mulitplied by delta Time to compensate for any fluctuations in frame rate 
			this.gameObject.transform.Translate (direction * Time.deltaTime);
			
			// Increase the timer by delta time each frame, this effectively counts accurately in seconds
			timer += Time.deltaTime;
			
			// Call the setMovmentRate function that will store the current translation ammount for this frame
			SetMovementRate(direction * Time.deltaTime);
			
			// If we've reached the end of our movement time we'll want to trip the "return" switch and set our outgoing boolean to false, also reset timer
			if (timer > movementTime){
				outgoing = false;
				timer = 0;
			}
		}
		
		// If the platform is returning to the origin
		else{
			
			// Translate the platform along the inverted direction (that's what the * -1 is doing)
			this.gameObject.transform.Translate (direction * Time.deltaTime * -1);
			
			timer += Time.deltaTime;
			
			// Call the setMovmentRate function that will store the current translation ammount for this frame
			SetMovementRate(direction * Time.deltaTime * -1);
			
			if (timer > movementTime){
				outgoing = true;
				timer = 0;
			}
		}
	}
	
	void SetMovementRate (Vector3 movement){
		movementRate = movement;
	}
	
	public Vector3 GetMovmentRate (){
		return movementRate;
	}
}
