using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private AudioClip winClip;
    private AudioSource winSource;

    private void Awake()
    {
        winSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Exit()
    {
        winSource.PlayOneShot(winClip);
        Application.Quit();
    }
}
