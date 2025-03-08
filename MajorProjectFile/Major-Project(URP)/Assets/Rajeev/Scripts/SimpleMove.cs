using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
