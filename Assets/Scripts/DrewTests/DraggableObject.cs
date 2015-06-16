using UnityEngine;
using System.Collections;

public class DraggableObject : MonoBehaviour {


	// Use this for initialization
	void Awake () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
            GetComponent<Collider>().attachedRigidbody.isKinematic = true;
    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("I am being triggered!");
        }
    }

    void OnTriggerExit()
    {
        GetComponent<Collider>().attachedRigidbody.isKinematic = true;
    }
}
