using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Strings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stringText;
    private int strings = 0;

    public static int totalStrings = 0;

    private void Start()
    {
        strings = totalStrings;
        UpdateText();
    }

    public void Puntos()
    {
        strings++;
        totalStrings = strings;
        UpdateText();

        CheckLevelProgress();
    }

    private void UpdateText()
    {
        int goal = SceneManager.GetActiveScene().name == "nivel2" ? 7 : 4;
        stringText.text = strings + "/" + goal;
    }

    private void CheckLevelProgress()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "gatet" && strings == 4)
        {
            LoadNextScene("nivel2");
        }
        else if (currentScene == "nivel2" && strings == 7)
        {
            LoadNextScene("win");
        }
    }

    private void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetProgress()
    {
        totalStrings = 0;
    }
}
