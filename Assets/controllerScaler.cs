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

        float height = camera.position.y - transform.position.y;
        characterController.height = height;
        Vector3 center = camera.position - transform.position;

        center.y = (height / 2);

        characterController.center = center;
    }

    private void FixedUpdate()
    {
        float height = camera.position.y - transform.position.y;

        characterController.height = height;

        Vector3 center = camera.position - transform.position;

        center.y = (height / 2);

        characterController.center = center;
    }
}
