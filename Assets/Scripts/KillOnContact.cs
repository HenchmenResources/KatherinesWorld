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
        c.gameObject.GetComponent<Player>().lives--;
        spawner.SpawnPlayer();
    }
}