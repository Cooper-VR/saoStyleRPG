using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI
{
    public class controllerScaler : MonoBehaviour
    {
        #region variables
        private CharacterController characterController;
        public Transform camera;
        #endregion

        #region start/update

        private void Start()
        {
            //get the character controller
            characterController = GetComponent<CharacterController>();

            //get the hight difference
            float height = camera.position.y - transform.position.y;
            characterController.height = height;
            Vector3 center = camera.position - transform.position;

            center.y = (height / 2);

            //set the center to the midpoint
            characterController.center = center;
        }

        private void FixedUpdate()
        {
            //get the hight difference between the head and floor
            float height = camera.position.y - transform.position.y;

            //set the controller hight to that 
            characterController.height = height;

            Vector3 center = camera.position - transform.position;

            center.y = (height / 2);

            //adjust the center accordinly
            characterController.center = center;
        }
        #endregion
    }
}

