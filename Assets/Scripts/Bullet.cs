using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 5f;

    Transform plate;
    Vector3 target;

    Rigidbody2D rb;
    void Start()
    {
        plate = GameObject.FindGameObjectWithTag("Player").transform;
        target = plate.position;//new Vector2(plate.position.x, plate.position.y);
        rb = GetComponent<Rigidbody2D>();
        var heading = target - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        rb.velocity = direction* Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position = Vector2.MoveTowards(transform.position, target, Speed*Time.deltaTime);
        //if(transform.position.x==target.x && transform.position.y == target.y)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CharController>().TakeDamage();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }
}
