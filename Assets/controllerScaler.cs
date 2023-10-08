using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerScaler : MonoBehaviour
{
    CharacterController characterController;
    public Transform camera;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        float height = camera.position.y - transform.position.y;

        characterController.height = height;

        Vector3 center = camera.position - transform.position;

        center.y = transform.position.y;

        center.y += height / 2;

        characterController.center = center;
    }
}
