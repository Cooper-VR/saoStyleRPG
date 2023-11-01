using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class openMenu : MonoBehaviour
    {
        public float threshold;
        Rigidbody leftHand;
        Rigidbody rightHand;

        private playerMovement movement;
        private IndexInput input;
        private Animator menu;

        private void Start()
        {
            movement = GetComponent<playerMovement>();
            input = GetComponent<IndexInput>();

            leftHand = transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
            rightHand = transform.GetChild(1).gameObject.GetComponent<Rigidbody>();

            menu = GameObject.Find("playerMenu").GetComponent<Animator>();
        }

        private void Update()
        {
            if ((leftHand.velocity.y * -1 > threshold && input.isGrippingLeft) || Input.GetKeyDown(KeyCode.M))
            {
                menu.SetBool("open", true);
                menu.transform.position = leftHand.position;
                menu.transform.LookAt(movement.camera);
            }
            else if ((rightHand.velocity.y * -1 > threshold && input.isGrippingRight) || Input.GetKey(KeyCode.M))
            {
                menu.SetBool("open", true);
                menu.transform.position = rightHand.position;
                menu.transform.LookAt(movement.camera);
            }

            if (leftHand.velocity.y > threshold || Input.GetKey(KeyCode.N))
            {
                menu.SetBool("open", false);
            }
            else if (rightHand.velocity.y > threshold || Input.GetKey(KeyCode.N))
            {
                menu.SetBool("open", false);
            }
        }
    }
}
