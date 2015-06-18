using UnityEngine;
using System.Collections;

public class KillOnContact : MonoBehaviour {

    public SpawnPoint spawner;

    //void Awake()
    //{
    //    spawner = GameObject.FindGameObjectWithTag("SpawnPoint");
    //}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            c.gameObject.GetComponent<Player>().lives--;
            spawner.SpawnPlayer();
        }
    }
}