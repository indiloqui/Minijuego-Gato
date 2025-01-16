using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
   private Animator animator;
   [SerializeField] private float movementSpeed = 3f;
   [SerializeField] private AudioClip stepClip;
   [SerializeField] private AudioClip meowClip;
   [SerializeField] private AudioClip layingClip;
   [SerializeField] private AudioClip stretchingClip;
    [SerializeField] private AudioClip runClip;

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
        if (!animator.GetBool("Sitting") && !animator.GetBool("Laying") && !animator.GetBool("Stretching"))
        {
            rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
            animator.SetBool("Walk", moveInput != 0);

            bool isRunning = moveInput != 0 && Keyboard.current.shiftKey.isPressed;
            animator.SetBool("Running", isRunning);

            if (moveInput != 0)
            {
                spriteRenderer.flipX = moveInput < 0;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnWalk(InputValue value)
    {
        if (!animator.GetBool("Sitting") && !animator.GetBool("Laying") && !animator.GetBool("Stretching"))
        {
            moveInput = value.Get<float>();
        }
        else
        {
            moveInput = 0;
        }
    }

    public void Step()
        {
            audioSource.PlayOneShot(stepClip);
        }

        private void OnMeow()
        {
            animator.SetTrigger("Meowing");
        }

        public void Meow()
        {
            audioSource.PlayOneShot(meowClip);
        }

    private void OnSit()
    {
        bool isSitting = animator.GetBool("Sitting");
        animator.SetBool("Sitting", !isSitting);

        if (!isSitting)
        {
            moveInput = 0;
        }
    }

    private void OnLay()
    {
        bool isLaying = animator.GetBool("Laying");
        animator.SetBool("Laying", !isLaying);

        if (!isLaying)
        {
            moveInput = 0;
        }
    }
    public void Lay()
    {
        audioSource.PlayOneShot(layingClip);
    }

    private void OnStretch()
    {
        bool isStretching = animator.GetBool("Stretching");
        animator.SetBool("Stretching", !isStretching);

        if (!isStretching)
        {
            moveInput = 0;
        }
    }
    public void Stretch()
    {
        audioSource.PlayOneShot(stretchingClip);
    }

    public void Run()
    {
        audioSource.PlayOneShot(runClip);
    }
}
