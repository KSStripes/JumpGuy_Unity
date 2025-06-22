using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // press start
    public void StartGame()
    {
        SceneManager.LoadScene("Assignment Base");
    }

    // press quit
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
