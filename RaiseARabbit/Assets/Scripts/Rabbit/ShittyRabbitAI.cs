using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShittyRabbitAI : MonoBehaviour
{

    // Use this for initialization


    public int seed = 42;
    public float forceMag = 1f;

    public int timeOfAction = 3;
    float actionTimer;

    Vector3 currDir;
    Rigidbody rb;
    GameObject foodSource;
    GameObject toilet;

    RabbitMech rabbitMech;

    void Start()
    {
        UnityEngine.Random.InitState(seed);
        rb = this.GetComponent<Rigidbody>();
        currDir = Vector3.zero;

        foodSource = GameObject.Find("GrassBasket");
        toilet = GameObject.Find("RabbitToilet");

        rabbitMech = this.GetComponent<RabbitMech>();

        actionTimer = timeOfAction;
    }

    // Update is called once per frame
    void Update()
    {

        actionTimer += Time.deltaTime;

        Vector3 direction = Vector3.zero;
        if (actionTimer > timeOfAction)
        {
            Array stateArr = Enum.GetValues(typeof(RabbitMech.rabbitState));

            int stateId = UnityEngine.Random.Range(0, stateArr.Length);

            rabbitMech.state = (RabbitMech.rabbitState)stateArr.GetValue(stateId);

            //Debug.Log("Current rabbit state is: " + rabbitMech.state);
            direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;

            actionTimer = 0;

            Debug.Log("State: " + rabbitMech.state);
        }


        if (rabbitMech.state == RabbitMech.rabbitState.Eating)
        {
            eatingActionUpdate();
        }
        else if (rabbitMech.state == RabbitMech.rabbitState.Shitting)
        {
            shittingActionUpdate();
        }
        else if (rabbitMech.state == RabbitMech.rabbitState.Resting)
        {
            restingActionUpdate(direction);
        }

    }


    void eatingActionUpdate()
    {

        currDir = (foodSource.transform.position - this.transform.position).normalized;
        rb.AddForce(currDir * forceMag, ForceMode.Impulse);

        //Vector3 delPos = currDir * velocityMag * Time.deltaTime;
        //this.transform.position += new Vector3(delPos.x,0,delPos.z);

    }

    void shittingActionUpdate()
    {
        currDir = (toilet.transform.position - this.transform.position).normalized;

        rb.AddForce(currDir * forceMag, ForceMode.Impulse);
        //Vector3 delPos = currDir * velocityMag * Time.deltaTime;
        //this.transform.position += new Vector3(delPos.x, 0, delPos.z);

    }

    void restingActionUpdate(Vector3 direction)
    {
        currDir = (-this.transform.position).normalized;
        rb.AddForce(currDir * forceMag, ForceMode.Impulse);

        //Vector3 delPos = currDir * velocityMag * Time.deltaTime;
        //this.transform.position += new Vector3(delPos.x, 0, delPos.z);

        if (this.transform.position.magnitude <= 0.3f)
        {
            currDir = direction;

        }
    }


}
