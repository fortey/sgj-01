using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCircleController : MonoBehaviour
{
    public Transform PlateParent;
    public float Speed=3f;

    public Transform LandingPoint;
    bool isLanding = false;

    int health = 3;
    public int Health
    {
        get => health;
        set
        {
            health = value < 0 ? 0 : value;
            ShowHealth(health);
        }
    }

    public Action<int> ShowHealth;
    public Action onWin;
    public Action onLose;

    public AudioSource ASource;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!isLanding)
        {
            var h = Input.GetAxisRaw("Horizontal");
            var rotaion = PlateParent.rotation;
            rotaion.z = Mathf.Clamp(rotaion.z + h * Time.fixedDeltaTime, -0.40f, 0.40f);

            PlateParent.rotation = rotaion;
        }
    }

    public void TakeDamage()
    {
        ASource.Play();
        Health--;
        if (Health == 0)
        {
            onLose();
        }
    }

    public void Landing()
    {
        if (!isLanding)
        {
            isLanding = true;
            StartCoroutine(MoveOnLanding());
        }
    }

    IEnumerator MoveOnLanding()
    {
        while (Vector2.Distance(LandingPoint.position, transform.position) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, LandingPoint.position, 3 * Time.fixedDeltaTime);
            var newScale = transform.localScale;
            newScale.x = Mathf.Clamp(newScale.x - 1 * Time.fixedDeltaTime, 0, 1);
            newScale.y = Mathf.Clamp(newScale.y - 1 * Time.fixedDeltaTime, 0, 1);
            transform.localScale = newScale;
            yield return new WaitForFixedUpdate();
        }
    }
}
