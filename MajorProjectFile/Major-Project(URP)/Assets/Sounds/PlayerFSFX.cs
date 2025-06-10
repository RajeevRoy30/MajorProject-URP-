using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] FootstepAudioClips;

    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

    [SerializeField] private AudioSource punch;

    CharacterController _controller;
    private void OnEnable()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void PlayFootSteps(UnityEngine.AnimationEvent animationEvent)
    {
        if (FootstepAudioClips.Length > 0)
        {
            var index = Random.Range(0, FootstepAudioClips.Length);
            if (_controller != null)
            {
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
            }
            else
            {
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.position, FootstepAudioVolume);
            }
        }
    }

    private void SprintSFX(UnityEngine.AnimationEvent animationEvent)
    {

        if (FootstepAudioClips.Length > 0)
        {
            var index = Random.Range(0, FootstepAudioClips.Length);
            AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
        }
    }
    public void PlayPunch()
    {
        punch.Play();
    }
}