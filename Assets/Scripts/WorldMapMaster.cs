using UnityEngine;
using System.Collections;

public class WorldMapMaster : MonoBehaviour {
	private Vector3 mouseLocation;
	//LevelActiveCheck will need to be replaced with code that checks the master level unlocked list.
	private bool LevelActiveCheck = true;
	public GameObject lightManager;
	private string nextLevel;

	//Track Which maps have been Completed
	public bool bActiveLevel1 = true;
	public bool bActiveLevel2 = false;
	public bool bActiveLevel3 = false;
	public bool bActiveLevel4 = false;
	public bool bActiveLevel5 = false;
	public bool bActiveLevel6 = false;
	public bool bActiveLevel7 = false;
	public bool bActiveLevel8 = false;
	public bool bActiveLevel9 = false;
	public bool bActiveLevel10 = false;
	public bool bActiveLevel11 = false;
	public bool bActiveLevel12 = false;

	//Setup Instancing
	private static WorldMapMaster instance = null;
	public static WorldMapMaster Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}


}
