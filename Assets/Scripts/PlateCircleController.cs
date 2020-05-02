using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCircleController : MonoBehaviour
{
    public Transform PlateParent;
    public float Speed=3f;

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

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var rotaion = PlateParent.rotation;
        rotaion.z = Mathf.Clamp(rotaion.z + h * Time.fixedDeltaTime, -0.40f, 0.40f);
           
        PlateParent.rotation = rotaion;
    }

    public void TakeDamage()
    {
        Health--;
        if (Health == 0)
        {
            onLose();
        }
    }
}
