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
    public Action onWin;
    public Action onLose;

    bool inPole { get; set; } = false;

    Rigidbody2D rb;
    Vector2 moveVelocity;

    public GameObject ProgressBar;
    public Transform progressFill;

    float progress = 0f;
    public float TimeToComplete = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            progress += Time.deltaTime;
            RefreshProgress();
        }
        if(progress>1f){
            onWin();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void EnterPole()
    {
        inPole = true;
        ProgressBar.SetActive(true);
        progress = 0f;
        RefreshProgress();
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
        Health--;
        progress = 0f;
        if (Health == 0)
        {
            onLose();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Bullet") && !collision.collider.CompareTag("Bound"))
        {
            TakeDamage();
        }
    }

}
