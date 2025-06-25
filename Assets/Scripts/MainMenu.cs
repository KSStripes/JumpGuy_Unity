using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // press start
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    // press quit
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Time.timeScale = 0f; // freeze all movement
        AudioListener.pause = true; // end all sounds
        Application.Quit();
    }
}
