using UnityEngine;
using System.Collections;

public class StackableBoxes : MonoBehaviour {
	public bool bGrounded;
	public LayerMask GroundedMask;
	public LayerMask ParentalTest;
	public bool bShowDebug = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (IsInLayerMask (other.gameObject, GroundedMask)) {
			bGrounded = true;
			if (IsInLayerMask(other.gameObject, ParentalTest) && gameObject.transform.parent.gameObject.transform.parent.name != "Kathetrine"){
				//SET THE COLLIDED OBJECT AS THIS ONES PARENT
				gameObject.transform.parent = other.transform;
			}
		}
	}

	void OnTriggerStay (Collider other) {
		if (bShowDebug)
			Debug.Log (gameObject.transform.parent);
		if (IsInLayerMask (other.gameObject, GroundedMask)) {
			bGrounded = true;
			if (IsInLayerMask (other.gameObject, ParentalTest) && gameObject.transform.parent.gameObject.transform.parent.name != "Kathetrine") {
				gameObject.transform.parent = other.transform;
			}
		}
	}

	void OnTriggerExit () {
		bGrounded = false;
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
