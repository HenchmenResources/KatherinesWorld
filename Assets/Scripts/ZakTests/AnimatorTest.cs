using UnityEngine;
using System.Collections;

public class AnimatorTest : MonoBehaviour {
	public float airSpeedMultiplier = 0.5f;
	public float maxSpeed = 5.9f;
	public float jumpForce = 600f;
	bool facingRight = true;
	public bool grabbing = false;
	float dragSpeed = 0.5f;
	Rigidbody m_Rigidbody;
	Quaternion m_rotation = Quaternion.identity;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		m_Rigidbody = GetComponent<Rigidbody>();
		//Lock the player to the X and Y axis and allow them to only turn to the left and right
		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		grounded = IsGrounded ();
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("vSpeed", m_Rigidbody.velocity.y);
		
		if (facingRight) {
			dragSpeed = move * 0.3f;
		} else {
			dragSpeed = move * 0.3f * -1f;
		}
		anim.SetFloat ("dragSpeed", dragSpeed);

		if (grounded) {
			if (!grabbing) {
				m_Rigidbody.velocity = new Vector3 (move * maxSpeed, m_Rigidbody.velocity.y, 0f);
			}else{
				m_Rigidbody.velocity = new Vector3 (dragSpeed, m_Rigidbody.velocity.y, 0f);
			}
		} else {
			// Check if we're hitting a wall
			if(IsWalled())
			{
				Debug.Log ("You're Walled");
				// If so, stop the movement
				m_Rigidbody.velocity = new Vector3(0f, m_Rigidbody.velocity.y, 0f);
			}else{
				//ALTER SPEED FOR AIR CONTROL IN HERE
				m_Rigidbody.velocity = new Vector3 (move * maxSpeed * airSpeedMultiplier, m_Rigidbody.velocity.y, 0f);
			}
		}
			if (move > 0 && !facingRight && !grabbing)
				flip ();
			if (move < 0 && facingRight && !grabbing)
				flip ();

	}

	void Update () {


		if (grounded && Input.GetButtonDown ("Jump")) {
			anim.SetBool ("Grounded", false);
			PowerUps powerupScript = GameObject.Find ("PowerManager").GetComponent<PowerUps> ();
			if (powerupScript.enabledStrength){
				//DOUBLE JUMP HEIGHT WHEN USING STRENGTH POWERUP
				m_Rigidbody.AddForce(new Vector3(0, jumpForce * 1.5f, 0));
			}else{
				m_Rigidbody.AddForce(new Vector3(0, jumpForce, 0));
			}
		}

		if (Input.GetButtonDown ("Grab"))
		    anim.SetBool("doGrab", true);

		if (Input.GetButton("Grab")) {
			anim.SetBool("Grabbing", true);
			grabbing = true;
		}else{
			anim.SetBool("Grabbing", false);
			grabbing = false;
		}
	}

	void flip () {
		if (facingRight) {
			transform.eulerAngles = new Vector3 (0, -90, 0);
		} else {
			transform.eulerAngles = new Vector3 (0, 90, 0);
		}
		facingRight = !facingRight;
	}

	bool IsGrounded () {
		return Physics.Raycast (groundCheck.position, -Vector3.up, groundRadius, whatIsGround);
	}

	bool IsWalled () {
		Debug.Log ("Wall Check");
		if (facingRight) {
			return Physics.Raycast (gameObject.transform.position, Vector3.right, 0.5f);
		}else{
			return Physics.Raycast (gameObject.transform.position, Vector3.left, 0.5f);
		}
	}
}
