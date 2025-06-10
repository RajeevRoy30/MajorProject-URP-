using UnityEngine;

public class ControlsSceneManager : MonoBehaviour
{
    public void ContinueToGameplay()
    {
        SceneTransitionManager.Instance.LoadSceneWithFade("Gameplay");
    }

    public void BackToMainMenu()
    {
        SceneTransitionManager.Instance.LoadSceneWithFade("MainMenu 1");
    }
}