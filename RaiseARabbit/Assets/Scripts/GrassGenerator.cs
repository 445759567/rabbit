using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour {

    public GameObject grassPrefab;
    // Use this for initialization
    public int grassCount = 10;
    public int seed = 42;
	void Start () {

        Random.InitState(seed);

        for (int i = 0; i < grassCount; i++) {
            Vector3 pos = new Vector3(Random.Range(-1.0f, 1.0f), 4, Random.Range(-1.0f, 1.0f));
            GameObject grassObj = Instantiate(grassPrefab, pos*0.7f+this.transform.position, Quaternion.identity, this.transform);

        }
	}
	
}
