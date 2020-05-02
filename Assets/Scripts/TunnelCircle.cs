using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCircle : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newScale = transform.localScale;
        newScale.x += newScale.x *speed * Time.fixedDeltaTime;
        newScale.y += newScale.y * speed * Time.fixedDeltaTime;
        transform.localScale = newScale;
        if (transform.localScale.x > 5)
        {
            Destroy(gameObject);
        }
    }
}
