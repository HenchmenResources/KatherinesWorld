using UnityEngine;
using System.Collections;

public class ZakSandbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		//gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionScaleUI", 10f);
		DynamicGI.SetEmissive (GetComponent<Renderer>(), new Color(0.0f, 0.9f, 0.6f)*1f);
	}

	void OnMouseExit () {
		//gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionScaleUI", 0f);
	}
}
