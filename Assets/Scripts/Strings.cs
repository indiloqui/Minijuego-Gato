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

        if (currentScene == "gatet" && strings == 4)
        {
            SceneManager.LoadScene("mapa");
        }
        else if (currentScene == "mapa" && strings == 7)
        {
            SceneManager.LoadScene("win");
        }
    }

    public void Puntos()
    {
        strings++;
        stringText.text = strings + "/7";
    }
}