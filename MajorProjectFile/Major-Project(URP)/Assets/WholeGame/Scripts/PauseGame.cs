using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu; // Assign in Inspector

    private bool isPaused = false;

    void Update()
    {
        // Optional: Toggle pause with ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Freeze the game
            pauseMenu.SetActive(true); // Show pause menu
        }
        else
        {
            Time.timeScale = 1; // Resume normal time
            pauseMenu.SetActive(false); // Hide pause menu
        }
    }

    public void ResumeGame()
    {
        TogglePause(); // Unpause the game
    }

    public void QuitGame()
    {
        Time.timeScale = 1; // Reset time before quitting
        SceneManager.LoadScene("MainMenu 1"); // Replace with your menu scene
        // OR: Application.Quit(); (for standalone builds)
    }
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}