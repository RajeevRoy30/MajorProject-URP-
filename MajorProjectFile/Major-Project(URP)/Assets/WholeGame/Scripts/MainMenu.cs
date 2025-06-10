using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        SceneTransitionManager.Instance.LoadSceneWithFade("Story");
    }

    public void OpenCredits()
    {
        SceneTransitionManager.Instance.LoadSceneWithFade("Credits 1");
    }

    public void OnBackButton()
    {
         SceneManager.LoadScene("MainMenu 1");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}