using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsSceneManager : MonoBehaviour
{
    public void ContinueToGameplay()
    {
        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.LoadSceneWithFade("Gameplay");
        }
        else
        {
            Debug.LogError("SceneTransitionManager instance is missing!");
            // Fallback - load without fade
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void BackToMainMenu()
    {
        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.LoadSceneWithFade("MainMenu 1");
        }
        else
        {
           // Debug.LogError("SceneTransitionManager instance is missing!");
            // Fallback - load without fade
            SceneManager.LoadScene("MainMenu 1");
        }
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}