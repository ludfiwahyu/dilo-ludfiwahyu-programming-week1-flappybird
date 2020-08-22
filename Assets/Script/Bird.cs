using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 1;
    [SerializeField] private bool isDead;
    [SerializeField] private Text scoreText;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent OnJump, OnDead, OnAddPoint;

    private Rigidbody2D rigidBody2d;
    private Animator animator;

    [SerializeField] private GameObject bullet;
    private Vector3 bulletPos;

    void Start()
    {
        //Get Component while game running
        rigidBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (!isDead && Input.GetKeyDown(KeyCode.Space))
        {
            bulletPos = transform.position;
            bulletPos += new Vector3(+0.4f, 0f, 0f);
            Instantiate(bullet, bulletPos, Quaternion.identity);
        }
    }

    void Jump()
    {
        if (rigidBody2d)
        {
            rigidBody2d.velocity = Vector2.zero;
            rigidBody2d.AddForce(new Vector2(0, upForce));
        }

        if (OnJump != null)
        {
            OnJump.Invoke();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Dead ()
    {
        if (!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }
        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.enabled = false;
    }

    public void AddScore(int value)
    {
        //Menambahkan Score value
        score += value;

        //Pengecekan Null Value
        if (OnAddPoint != null)
        {
            //Memanggil semua event pada OnAddPoint
            OnAddPoint.Invoke();
        }

        //Mengubah nilai text pada score text
        scoreText.text = score.ToString();
    }

}
