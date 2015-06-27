using UnityEngine;
using System.Collections;

public class AnimatorTest : MonoBehaviour {
	public float airSpeedMultiplier = 0.5f;
	public float maxSpeed = 5.9f;
	public float jumpForce = 600f;
	public float dragMultiplier = 0.1f;
	bool facingRight = true;
	public bool grabbing = false;
	float dragSpeed = 0.5f;
	Rigidbody m_Rigidbody;
	Quaternion m_rotation = Quaternion.identity;
	float dragDirect;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public LayerMask MovingObjects;
	Vector3 wallCast;
	GameObject hitName;
	bool wallHitLeft = false;

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		m_Rigidbody = GetComponent<Rigidbody>();
		//Lock the player to the X and Y axis and allow them to only turn to the left and right
		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX |RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
		//groundCheck = gameObject.transform.FindChild ("GroundCheck").transform;
		//anim["pushPull"].speed = 2.0f;
		//anim.speed = 2.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		grounded = IsGrounded ();
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("vSpeed", m_Rigidbody.velocity.y);
		
		if (facingRight) {
			dragSpeed = move * maxSpeed * dragMultiplier;
			dragDirect = move * maxSpeed * dragMultiplier;
		} else {
			dragSpeed = move * maxSpeed * dragMultiplier;
			dragDirect = move * maxSpeed * dragMultiplier * -1f;
		}
		anim.SetFloat ("dragSpeed", dragDirect);
		if (grounded) {
			if (OnMover ()) {
				Debug.Log ("On Mover");
				//DO THIS IF THE PLAYER IS ON A MOVER
				OnMoverMove ();
			}else{
				gameObject.transform.parent = null;
				if (!grabbing) {
					if (IsWalled()){
						if (wallHitLeft) {
							if (move < 0) {
								m_Rigidbody.velocity = new Vector3(0f, m_Rigidbody.velocity.y, 0f);
							}else{
								m_Rigidbody.velocity = new Vector3 (move * maxSpeed, m_Rigidbody.velocity.y, 0f);
							}
						}else{
							if (move > 0) {
								m_Rigidbody.velocity = new Vector3(0f, m_Rigidbody.velocity.y, 0f);
							}else{
								m_Rigidbody.velocity = new Vector3 (move * maxSpeed, m_Rigidbody.velocity.y, 0f);
							}
						}
					}else{
						m_Rigidbody.velocity = new Vector3 (move * maxSpeed, m_Rigidbody.velocity.y, 0f);
					}
				}else{
					m_Rigidbody.velocity = new Vector3 (dragSpeed, m_Rigidbody.velocity.y, 0f);
				}
			}   //END ON MOVER ELSE
		} else {

			if(IsWalled ())
			{
				// If so, stop the movement IN SAME DIRECTION
				if (wallHitLeft) {
					if (move < 0) {
						m_Rigidbody.velocity = new Vector3(0f, m_Rigidbody.velocity.y, 0f);
					}else{
						m_Rigidbody.velocity = new Vector3 (move * maxSpeed * airSpeedMultiplier, m_Rigidbody.velocity.y, 0f);
					}
				}else{
					if (move > 0) {
						m_Rigidbody.velocity = new Vector3(0f, m_Rigidbody.velocity.y, 0f);
					}else{
						m_Rigidbody.velocity = new Vector3 (move * maxSpeed * airSpeedMultiplier, m_Rigidbody.velocity.y, 0f);
					}
				}
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
			gameObject.transform.parent = null;
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

		//USE GROUNDED TRIGGER BOX TO DETERMINE GROUNDING
		GroundedTrigger GroundCheck = transform.FindChild("GroundCheck").gameObject.GetComponent<GroundedTrigger>();
		//return GroundCheck.bGrounded;

		//UNCOMMENT TO USE RAY CASTING TO CHECK IF PLAYER IS GROUNDED
		RaycastHit hit;
		if (GroundCheck.bGrounded || Physics.Raycast (groundCheck.position, -Vector3.up, out hit, groundRadius, whatIsGround)){
			return true;
		}else{
			return false;
		}

	}

	bool OnMover () {
		RaycastHit hit;
		return Physics.Raycast (groundCheck.position, -Vector3.up, groundRadius, MovingObjects);
	}

	void OnMoverMove () {
		Debug.Log ("Player to Mover");
		RaycastHit hit;
		Physics.Raycast (groundCheck.position, -Vector3.up, out hit, groundRadius, MovingObjects);
		hitName = hit.collider.gameObject;
		float move = Input.GetAxis ("Horizontal");
		gameObject.transform.parent = hitName.transform;
	}
	
	bool IsWalled () {
		NoWallStick WallCheck = GameObject.Find("Teflon").GetComponent<NoWallStick>();
		wallHitLeft = !facingRight;
		return WallCheck.hittingWall;
	}
}
