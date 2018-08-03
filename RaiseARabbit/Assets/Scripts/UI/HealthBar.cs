using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {


    Slider healthSlider;
	// Use this for initialization
	void Start () {
        healthSlider = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value = GlobalStats.rabbitStat.health;
	}
}
