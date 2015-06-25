using UnityEngine;
using System.Collections;

public class GroundedTrigger : MonoBehaviour {
	public bool bGrounded;
	public LayerMask WallMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (IsInLayerMask (other.gameObject, WallMask)) {
			bGrounded = true;
		}
	}

	void OnTriggerStay (Collider other) {
		if (IsInLayerMask (other.gameObject, WallMask)) {
			bGrounded = true;
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
