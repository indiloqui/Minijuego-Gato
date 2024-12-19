using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private AudioClip stepClip;
    [SerializeField] private GameObject meowVFX;

    private float moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
        animator.SetBool("Walk", moveInput != 0);

        if(moveInput != 0 ) 
        {
            spriteRenderer.flipX = moveInput < 0;
        }
    }

    private void OnWalk(InputValue Value) 
    { 
        moveInput = Value.Get<float>();
    }

    public void Step()
    {
        audioSource.PlayOneShot(stepClip);
    }

    public void Meow()
    {
        Instantiate(meowVFX, transform.position, Quaternion.identity);
    }
}
