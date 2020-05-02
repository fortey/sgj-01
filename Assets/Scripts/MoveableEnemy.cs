using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableEnemy : MonoBehaviour
{
    public float Speed = 2f;
    public Transform[] Spots;

    int spotIndex;

    void Start()
    {
        spotIndex = Random.Range(0, Spots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Spots[spotIndex].position, Speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, Spots[spotIndex].position)< 0.2f)
        {
            spotIndex = Random.Range(0, Spots.Length);
        }
    }
}
