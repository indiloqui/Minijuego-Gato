using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Strings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stringText;
    private int strings = 0;

    private void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (SceneManager.GetActiveScene().name == "gatet")
        {
            if(strings == 4)
            {
             SceneManager.LoadScene("nivel2");
            }
        }
        if (SceneManager.GetActiveScene().name == "nivel2")
        {
            if (strings == 7)
            {
                SceneManager.LoadScene("win");
            }
        }
    }

    public void Puntos()
    {
        strings++;
        stringText.text = strings + "/7";
    }
}