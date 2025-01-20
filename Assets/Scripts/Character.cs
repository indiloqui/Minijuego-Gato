using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
   private Animator animator;
   [SerializeField] private float movementSpeed = 3f;
   [SerializeField] private Strings strings;
   [SerializeField] private GameObject pauseMenu;


   [SerializeField] private AudioClip stepClip;
   [SerializeField] private AudioClip meowClip;
   [SerializeField] private AudioClip layingClip;
   [SerializeField] private AudioClip stretchingClip;
   [SerializeField] private AudioClip runClip;
   [SerializeField] private AudioClip stringClip;

    [SerializeField] private AudioClip generalMusicClip;
    [SerializeField] private AudioClip waterLevelClip;

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
            Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

            if (!animator.GetBool("Sitting") && !animator.GetBool("Laying") && !animator.GetBool("Stretching"))
            {
                bool isRunning = moveInput != 0 && (Keyboard.current.shiftKey.isPressed || Gamepad.current.leftShoulder.isPressed);

                float currentSpeed = isRunning ? movementSpeed * 2f : movementSpeed;

                rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);
                animator.SetBool("Walk", moveInput != 0);
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


    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("String"))
        {
            audioSource.PlayOneShot(stringClip);
            strings.Puntos();
            Destroy(collision.gameObject);
        }
    }
}
