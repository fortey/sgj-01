using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public Transform[] startSpots;
    public Transform[] endSpots;
    public GameObject Meteor;

    public float repeatTime = 2f;
    float currentTime;

    public float EndTime = 10f;
    float time = 0;
    void Start()
    {
        currentTime = repeatTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0 && time < EndTime)
        {
            currentTime = repeatTime;

            var index = Random.Range(0, startSpots.Length);
            var meteor = GameObject.Instantiate(Meteor, startSpots[index].position, Quaternion.identity);
            meteor.GetComponent<Meteor>().EndSpot = endSpots[index];

        }

        time += Time.deltaTime;
    }
}
