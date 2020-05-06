using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public GameObject Star;
    public float startX= 8.2f;
    public int maxStar = 100;
    int countStar = 0;

    private void Start()
    {
        StartCoroutine(CreateStar());
    }
    private void FixedUpdate()
    {
        
    }

    IEnumerator CreateStar()
    {
        while (countStar < maxStar)
        {
            var y = Random.Range(-4.9f, 5f);
            yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            GameObject.Instantiate(Star, new Vector2(startX, y), Quaternion.identity);
            countStar++;
        }
    }
}
