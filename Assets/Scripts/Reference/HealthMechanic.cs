using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthMechanic : MonoBehaviour {
	
	// Initializes two public variables (they will show up in the editor, and can be edited live in-game) for the starting HP and the ammount of damage taken each frame
	public int startingHP = 100;
	public float damageRate = 0.5f;
	
	// Private variable that tracks the current HP of the character
	private float currentHP = 0;
	
	// Creates a variable reference to store the connection to the Health Text object
	private Text HealthText;
	
	// Stores the respawn position for the character
	private Vector3 respawnLocation;
	
	void Start () {
		
		// Saves the current transform of the character for when we need to respawn later
		respawnLocation = this.gameObject.transform.position;
		
		// Sets the current HP of the character to the starting HP
		currentHP = startingHP;
		
		// Uses the handy "Find" and "Get Component" functions to grab a reference to the HealthText game object and store it in our HealthText variable
		HealthText = GameObject.Find("HealthText").GetComponent<Text>();
		
		// Set the HUD to display the current amount of health
		HealthText.text = "" + currentHP + " HP";
		
	}
	
	// The OnTriggerStay function is called when the collider attached to this game object (whatever object the script is attached to) continuously another collider set to be a "trigger"
	void OnTriggerStay (Collider collider)
	{
		// We want to check if the thing we're colliding with is a damaging, this will differentiate it from other trigger objects which we might add in the future
		if (collider.tag == "damaging")
		{
			// Reduces the current health by the damage rate (remember this fires every frame!)
			currentHP -= damageRate;
			
			// Checks if the currentHP is below or equal to 0, respawns the player and resets health (note that this doesn't "reset" the level, the previously collected items remain collected).
			// If you do want to reset the level you can instead Application.LoadLevel("YourLevelName") or Application.LoadLevel(0) if you want to load the first level.
			if (currentHP <= 0){
				this.transform.position = respawnLocation;
				currentHP = startingHP;
			}
			
			// Set the HUD to display the current amount of health
			HealthText.text = "" + Mathf.Round(currentHP) + " HP";
		}
	}
}
