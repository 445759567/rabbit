using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour {

    Slider hungerSlider;
    // Use this for initialization
    void Start()
    {
        hungerSlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = GlobalStats.rabbitStat.hunger;
    }

}
