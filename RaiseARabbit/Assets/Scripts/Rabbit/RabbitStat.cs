using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitStat
{

    float hungerIndicator;

    float healthIndicator;

    public float hunger
    {
        get { return hungerIndicator; }
        set { hungerIndicator = value; }
    }

    public float health
    {
        get { return healthIndicator; }
        set { healthIndicator = value; }
    }

    public RabbitStat(float initHunger, float initHealth)
    {
        hungerIndicator = initHunger;
        healthIndicator = initHealth;
    }

}
