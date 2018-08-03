using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitMech : MonoBehaviour
{

    // Use this for initialization
    GameObject foodSource;
    public float maxHealth = 100;
    public float maxHunger = 100;
    float timeDiff;
    float timeCnt;

    public enum rabbitState
    {
        Resting,
        Eating,
        Shitting,

    }

    rabbitState currState;

    public rabbitState state
    {
        get { return currState; }
        set { currState = value; }
    }



    void Start()
    {
        foodSource = GameObject.Find("GrassBasket");
        currState = rabbitState.Resting;
        timeDiff = 1;
        timeCnt = 0;
    }

    void Update()
    {
        timeCnt += Time.deltaTime;

        if (timeCnt > timeDiff)
        {
            updateHunger();
            updateHealth();

            timeCnt = 0;
        }

    }


    void updateHunger()
    {


        if ((transform.position - foodSource.transform.position).magnitude <= 1)
        {
            GlobalStats.rabbitStat.hunger += 1;
        }
        else
        {
            GlobalStats.rabbitStat.hunger -= 5;
        }

        if (GlobalStats.rabbitStat.hunger > maxHunger)
        {
            GlobalStats.rabbitStat.hunger = maxHunger;
        }
        else if (GlobalStats.rabbitStat.hunger < 0)
        {
            GlobalStats.rabbitStat.hunger = 0;
        }

    }


    void updateHealth()
    {
        if (GlobalStats.rabbitStat.hunger <= 50)
        {
            GlobalStats.rabbitStat.health -= 5;
        }
        else
        {
            GlobalStats.rabbitStat.health += 0.5f;
        }

        //GlobalStats.rabbitStat.health -= 0.5f;

        if (GlobalStats.rabbitStat.health > maxHealth)
        {
            GlobalStats.rabbitStat.health = maxHealth;
        }
        else if (GlobalStats.rabbitStat.health < 0)
        {
            GlobalStats.rabbitStat.health = 0;
        }
    }


}
