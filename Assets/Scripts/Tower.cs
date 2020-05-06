using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    float timeBtwShoots;
    public float startTimeBtwShoots;

    //Transform plate;
    public GameObject Bullet;

    public AudioSource AudioSource;
    public AudioClip FireSound;

    void Start()
    {
        //plate = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShoots = startTimeBtwShoots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShoots <= 0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
            AudioSource.PlayOneShot(FireSound);
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
