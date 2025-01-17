using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("gatet");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
