using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCircle : MonoBehaviour
{
    public float speed = 3f;
    public float moveSpeed = 3f;

    public Transform EnpPosition;
    Vector2 End;

    void Start()
    {
        End = EnpPosition.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, End, moveSpeed * Time.fixedDeltaTime);
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
