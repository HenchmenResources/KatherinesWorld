using UnityEngine;
using System.Collections;

public class ProcedMatTest : MonoBehaviour {
	public Renderer rend;
	public ProceduralMaterial _substanceReference;
	public ProceduralMaterial [] _materials;
	public Color colorLight;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		colorLight [0] = 1.0F;
		colorLight [1] = 1.0F;
		colorLight [2] = 0.737F;
		colorLight [3] = 1.0F;
	}
	
	// Update is called once per frame
	void Update () {
		ProceduralMaterial substance = rend.sharedMaterial as ProceduralMaterial;
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			//if (substance.HasProceduralProperty("DressColor1")){
				substance.SetProceduralColor ("DressColor1", colorLight);
				substance.RebuildTextures ();
			//}
		}
	}
}
