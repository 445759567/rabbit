using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //int hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
     
	}
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("coll: " + other);
        if (other.gameObject.name == "Rabbit")
        {
            Destroy(other.gameObject);
            Debug.Log("Rabbit is already killed");
            GlobalStats.rabbitStat.health = 0;
            GlobalStats.rabbitStat.hunger = 0;
        }
    }

}
