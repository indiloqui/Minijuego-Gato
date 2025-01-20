using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioClip menuClip;
    private AudioSource menuSource;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        menuSource = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("gatet");
        menuSource.PlayOneShot(menuClip);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
