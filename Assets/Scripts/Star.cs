using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    
    public float StartX=8.2f;
    public float EndX = -8.2f;

    float speed = 1f;
    void Start()
    {
        var newScale = transform.localScale;
        newScale.x *= Random.Range(0.1f, 0.7f);
        newScale.y = newScale.x;
        transform.localScale = newScale;

        speed = Random.Range(1f, 10f);
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        position.x -= speed * Time.fixedDeltaTime;
        if (position.x < EndX) position.x = StartX;
        transform.position = position;

    }
}
