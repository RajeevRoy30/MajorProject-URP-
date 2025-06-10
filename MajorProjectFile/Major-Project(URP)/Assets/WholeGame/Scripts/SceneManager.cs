using UnityEngine;

public class StorySceneManager : MonoBehaviour
{
    public void ContinueToControls()
    {
        SceneTransitionManager.Instance.LoadSceneWithFade("Controls");
    }
}