using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float Speed = 2f;
    public Transform EndSpot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, EndSpot.position, Speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, EndSpot.position) < 0.2f){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlateCircleController>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
