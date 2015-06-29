using UnityEngine;
using System.Collections;

public class StackableBoxes : MonoBehaviour {
	public bool bGrounded;
	public LayerMask GroundedMask;
	public LayerMask ParentalTest;
	public bool bShowDebug = false;
	public GameObject bParent;
	public bool bStacked = false;
	public Transform StackParent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (IsInLayerMask (other.gameObject, GroundedMask)) {
			bGrounded = true;
			bParent = gameObject.transform.parent.gameObject;
			if (IsInLayerMask(other.gameObject, ParentalTest) && gameObject.transform.parent.parent == null){
				//SET THE COLLIDED OBJECT AS THIS ONES PARENT
				//bParent.transform.parent = other.gameObject.transform;
				StackParent = other.gameObject.transform;
				//bParent.GetComponent<Rigidbody>().isKinematic = true;
				bStacked = true;
			}
		}
	}

	void OnTriggerStay (Collider other) {
		if (IsInLayerMask (other.gameObject, GroundedMask)) {
			bGrounded = true;
			bParent = gameObject.transform.parent.gameObject;
			if (IsInLayerMask (other.gameObject, ParentalTest) && gameObject.transform.parent.parent == null) {
				//bParent.transform.parent = other.gameObject.transform;
				if (bShowDebug)
					Debug.Log (bParent.transform.parent);
				//bParent.GetComponent<Rigidbody>().isKinematic = true;
				StackParent = other.gameObject.transform;
				bStacked = true;

			}
		}
	}

	void OnTriggerExit () {
		bGrounded = false;
		//bParent.GetComponent<Rigidbody> ().isKinematic = false;
		bStacked = false;
	}

	private bool IsInLayerMask(GameObject obj, LayerMask layerMask)
	{
		// Convert the object's layer to a bitfield for comparison
		int objLayerMask = (1 << obj.layer);
		if ((layerMask.value & objLayerMask) > 0)  // Extra round brackets required!
			return true;
		else
			return false;
	}

}
