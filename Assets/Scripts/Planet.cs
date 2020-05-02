using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 1)
        {
            var newScale = transform.localScale;
            newScale.x += newScale.x * speed * Time.fixedDeltaTime;
            newScale.y += newScale.y * speed * Time.fixedDeltaTime;
            transform.localScale = newScale;
        }
        
    }
}
