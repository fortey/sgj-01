using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Toilet : MonoBehaviour
{
    public GameObject Open;
    public GameObject Close;

    public Transform EndPosition;
    public Transform PlayerCheck;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Close.SetActive(false);
            Open.SetActive(true);
            
            collision.GetComponent<PlatformerController>().ComeIn();

            StartCoroutine(ComeIn(collision.transform));
        }
    }

    IEnumerator ComeIn(Transform player)
    {
    
        while (Vector2.Distance(EndPosition.position, PlayerCheck.position) >0.2f)
        {
            Debug.Log(Vector2.Distance(EndPosition.position, PlayerCheck.position));
            player.position = Vector2.MoveTowards(player.position, EndPosition.position, 2 * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        //Debug.Log("plll");
        Close.SetActive(true);
        Open.SetActive(false);
        StartCoroutine(TheEnd());
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Titles");
    }
}
