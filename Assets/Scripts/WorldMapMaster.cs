using UnityEngine;
using System.Collections;

public class WorldMapMaster : MonoBehaviour {
	private Vector3 mouseLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButtonDown(0)) {
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//Physics.Raycast(Camera.main.transform.position, Input.mousePosition, 100);
		//GameObject hitObject = RaycastHit.transform.parent;
		//Debug.Log (hitObject.name);
		//}
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)){
				if (hit.rigidbody != null){
					Debug.Log (hit.collider.gameObject.name);
					Application.LoadLevel(hit.collider.gameObject.name);
				}
			}
			
			
		}
	}
}


//Vector3 fwd = transform.TransformDirection (Vector3.forward);
//if (Physics.Raycast (Transform.position, fwd, 10)) {
//	GameObject hitObject = RaycastHit.transform.gameObject;
//	Debug.Log (hitObject.name);
//}