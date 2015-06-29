using UnityEngine;
using System.Collections;

public class zDraggabler : MonoBehaviour {

	bool bInGrabbingZone = false;
	Rigidbody m_rigidbody;
	GameObject ThisParent;
	public bool bIsLarge = false;
	private GameObject PlayerObj;

	void Awake () {
		PlayerObj = GameObject.Find ("Katherine");
	}
	// Use this for initialization
	void Start () {
		ThisParent = gameObject.transform.parent.gameObject;
		m_rigidbody = ThisParent.GetComponent<Rigidbody> ();
		PlayerObj = GameObject.Find ("Katherine");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerObj = GameObject.Find ("Katherine");
		//LOCK THE DRAGGABLE OBJECT TO GAME WORLD DIRECTIONS
		m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
		AnimatorTest PlayerScript = GameObject.Find ("Katherine").GetComponent<AnimatorTest> ();
		StackableBoxes GroundCheck = ThisParent.transform.FindChild("GroundCheck").gameObject.GetComponent<StackableBoxes>();
		if (bInGrabbingZone && PlayerScript.grabbing) {
			if (GroundCheck.bGrounded) {
				//IF THE PLAYER IS IN THE DRAG ZONE AND IS GRABBING MAKE THE PLAYER OBJECT THE PARENT TO THE BOX
				if (!bIsLarge) {
					//If the box is a small box make the player it's parent and move it
					m_rigidbody.isKinematic = true;
					m_rigidbody.mass = 1.0f;
					ThisParent.transform.parent = PlayerObj.transform;
					PlayerObj.GetComponent<AnimatorTest>().ActiveDragMultiplier = PlayerObj.GetComponent<AnimatorTest>().dragMultiplier;
				}else if (bIsLarge && GameObject.Find ("PowerManager").GetComponent<PowerUps>().enabledStrength) {
					//If the box is a Large box and the player has strength enabled make the player it's parent and move it
					m_rigidbody.isKinematic = true;
					m_rigidbody.mass = 1.0f;
					ThisParent.transform.parent = PlayerObj.transform;
					PlayerObj.GetComponent<AnimatorTest>().ActiveDragMultiplier = PlayerObj.GetComponent<AnimatorTest>().dragMultiplier;
				}else{
					PlayerObj.GetComponent<AnimatorTest>().ActiveDragMultiplier = 0.0f;
				}

			}else{
				if (!GroundCheck.bStacked) {
					m_rigidbody.isKinematic = false;
					ThisParent.transform.parent = null;
				}
				m_rigidbody.mass = 100.0f;

			}
		} else {
			if (GroundCheck.bStacked) {
				ThisParent.transform.parent = GroundCheck.StackParent;
				m_rigidbody.isKinematic = true;
				m_rigidbody.mass = 1.0f;
			}else{
			m_rigidbody.mass = 100.0f;
			m_rigidbody.isKinematic = false;
			ThisParent.transform.parent = null;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			bInGrabbingZone = true;
			other.gameObject.GetComponent<AnimatorTest>().bInGrabZone = true;
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Player") {
			bInGrabbingZone = true;
			other.gameObject.GetComponent<AnimatorTest>().bInGrabZone = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			bInGrabbingZone = false;
			other.gameObject.GetComponent<AnimatorTest>().bInGrabZone = false;
		}
	}

	void doDragging () {

	}
}
