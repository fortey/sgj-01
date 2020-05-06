using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour
{
    public float moveSpeed = 10f;
    int health = 3;
    public int Health {
        get => health;
        set {
            health = value<0 ? 0 : value;
            ShowHealth(health);
        } 
    }

    public Action<int> ShowHealth;
    public Action<string> onWin;
    public Action onLose;

    bool inPole { get; set; } = false;

    Rigidbody2D rb;
    Vector2 moveVelocity;

    public GameObject ProgressBar;
    public Transform progressFill;

    float progress = 0f;
    public float TimeToComplete = 3f;

    Vector2 startPosition;

    public AudioSource ASource;
    public AudioClip DamageSound;
    public AudioClip Capture;

    public string currentArea;
    bool isWin = false;

    public GameObject LeftBound;
    public GameObject Light;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
  
        var moveVector = new Vector2(h, v);
        moveVelocity = moveVector.normalized * moveSpeed;

        //rb.velocity = Vector2.ClampMagnitude(newVelocity, moveSpeed);
        if (inPole && Input.GetKey(KeyCode.Space))
        {
            Light.SetActive(true);
            if (progress == 0)
            {
                ASource.PlayOneShot(Capture);
            }
            progress += Time.deltaTime;
            RefreshProgress();
        }
        else
        {
            Light.SetActive(false);
        }
        if(progress>1f){
            isWin = true;
            if (currentArea == "cows")
            {
                LeftBound.SetActive(false);
                rb.velocity = Vector2.right * moveSpeed;
            }
            onWin(currentArea);
        }
    }

    private void FixedUpdate()
    {
        if (!isWin)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }

    public void EnterPole(string areaName)
    {
        inPole = true;
        ProgressBar.SetActive(true);
        progress = 0f;
        RefreshProgress();
        currentArea = areaName;
    }

    public void ExitPole()
    {
        inPole = false;
        ProgressBar.SetActive(false);

    }

    void RefreshProgress()
    {
        var newScale = progressFill.localScale;
        newScale.x = Mathf.Clamp(progress, 0f, 1f);
        progressFill.localScale = newScale;
    }

    public void TakeDamage()
    {
        if (isWin) return;
        ASource.PlayOneShot(DamageSound);
        Health--;
        progress = 0f;
        if (Health == 0)
        {
            //onLose();
            transform.position = startPosition;
            Health = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Bullet") && !collision.collider.CompareTag("Bound"))
        {
            TakeDamage();
        }
    }

    IEnumerator ExitLevel()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            rb.MovePosition(rb.position + Vector2.right * moveSpeed*Time.fixedDeltaTime);
        }
    }

}
