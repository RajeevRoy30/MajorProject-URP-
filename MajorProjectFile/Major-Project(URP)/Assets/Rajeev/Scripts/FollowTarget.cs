using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    [SerializeField] private float rotationalSpeed = 10f;
    [SerializeField] private float BottomClamp = -40f;
    [SerializeField] private float TopClamp = 70f;

    private float cinemachineTargetPitch;
    private float cinemachineTargetYaw;


    private void LateUpdate()
    {
        Camera();
    }
    private void Camera()
    {
        float mouseX = GetMouseInput("Mouse X");
        float mouseY = GetMouseInput("Mouse Y");

        cinemachineTargetPitch = UpdateRotation(cinemachineTargetPitch, mouseY,BottomClamp, TopClamp,true);
        cinemachineTargetYaw = UpdateRotation(cinemachineTargetYaw, mouseX, float.MinValue, float.MaxValue, false);

        ApplyRotation(cinemachineTargetPitch, cinemachineTargetYaw);
    }

    private void ApplyRotation(float pitch,float yaw)
    {
        followTarget.rotation = Quaternion.Euler(pitch, yaw , followTarget.eulerAngles.z);
    }
    private float UpdateRotation(float currentRoation,float input,float min,float max, bool isXAxis )
    {
        currentRoation += isXAxis ? -input : input;
        return Mathf.Clamp(currentRoation, min, max);
    }
    private float GetMouseInput(string axis)
    {
        return Input.GetAxis(axis) * rotationalSpeed * Time.deltaTime;

    }

    
}
