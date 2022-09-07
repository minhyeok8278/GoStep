using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip dieClip;
    public float jumpForce = 700f;


    private int jumpCount = 0;
    private bool isGround = false; //플레이어가 땅에 닿아있는지 판단하는 변수
    private bool isDead = false; //플레이어가 죽었는지 판단하는 변수

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(isDead == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)&& jumpCount <2)
        {
            jumpCount++;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0f, jumpForce));
            anim.SetBool("isJump", true);
            audioSource.Play();
        }
        else if (Input.GetMouseButtonUp(0) && rb.velocity.y > 0)
        {
            rb.velocity = rb.velocity * 0.5f; //점프를 꾹 누르면 높게 짧게 누르면 낮게
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGround = true;
            jumpCount = 0;
            anim.SetBool("isJump",false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead"&& isDead == false)
        {
            Die();
        }
    }
    private void Die()
    {
        anim.SetTrigger("isDie");
        audioSource.clip = dieClip;
        audioSource.Play();

        rb.velocity = Vector2.zero;
        isDead = true;
        GameManager.Instance.OnPlayerDead();
    }
}
