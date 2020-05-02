using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    CharController Player;
    public Image[] Hearts;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>();
        Player.ShowHealth = UpdateHealthBar;
        UpdateHealthBar(Player.Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealthBar(int count)
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
             Hearts[i].enabled = i < count;           
        }
    }
}
