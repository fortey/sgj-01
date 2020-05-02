using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public GameObject circle;
    public Transform startPosition;

    public AnimationCurve Curve;

    public float repiatTime = 3f;
    float currentTime;

    public float EndTime = 12f;
    float time = 0;
    void Start()
    {
        currentTime = repiatTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0 && time<EndTime)
        {
            currentTime = repiatTime;
            var _circle = GameObject.Instantiate(circle, startPosition.position, Quaternion.identity);
            //var newScale = _circle.transform.localScale;
            //newScale.x =0.2f;
            //newScale.y = 0.2f;
            //_circle.transform.localScale = newScale;
        }

        time += Time.deltaTime;
    }
}
