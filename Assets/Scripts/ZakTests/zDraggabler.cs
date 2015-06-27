using UnityEngine;
using System.Collections;

public class zDraggabler : MonoBehaviour {

	bool bInGrabbingZone = false;
	Rigidbody m_rigidbody;
	GameObject ThisParent;
	public bool bIsLarge = false;


	// Use this for initialization
	void Start () {
		ThisParent = gameObject.transform.parent.gameObject;
		m_rigidbody = ThisParent.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//LOCK THE DRAGGABLE OBJECT TO GAME WORLD DIRECTIONS
		m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
		AnimatorTest PlayerScript = GameObject.Find ("Katherine").GetComponent<AnimatorTest> ();
		GroundedTrigger GroundCheck = ThisParent.transform.FindChild("GroundCheck").gameObject.GetComponent<GroundedTrigger>();
		if (bInGrabbingZone && PlayerScript.grabbing) {
			if (GroundCheck.bGrounded) {
				//IF THE PLAYER IS IN THE DRAG ZONE AND IS GRABBING MAKE THE PLAYER OBJECT THE PARENT TO THE BOX
				m_rigidbody.isKinematic = true;
				m_rigidbody.mass = 1.0f;
				ThisParent.transform.parent = GameObject.Find ("Katherine").transform;
				Debug.Log ("Box is grounded");
			}else{
				m_rigidbody.isKinematic = false;
				m_rigidbody.mass = 100.0f;
				ThisParent.transform.parent = null;
			}
		} else {
			m_rigidbody.mass = 100.0f;
			m_rigidbody.isKinematic = false;
			ThisParent.transform.parent = null;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			bInGrabbingZone = true;
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Player") {
			bInGrabbingZone = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			bInGrabbingZone = false;
		}
	}
}
