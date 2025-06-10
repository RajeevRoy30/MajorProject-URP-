using UnityEngine;

public class StorySceneManager : MonoBehaviour
{
    public void ContinueToControls()
    {
        SceneTransitionManager.Instance.LoadSceneWithFade("Controls");
    }
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}