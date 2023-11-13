using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class openMenu : MonoBehaviour
    {
        public float threshold;
        VelocityEstimator leftHand;
        VelocityEstimator rightHand;

        private playerMovement movement;
        private IndexInput input;
        private Animator menu;

        private void Start()
        {
            movement = GetComponent<playerMovement>();
            input = GetComponent<IndexInput>();

            leftHand = transform.GetChild(0).gameObject.GetComponent<VelocityEstimator>();
            rightHand = transform.GetChild(1).gameObject.GetComponent<VelocityEstimator>();

            menu = GameObject.Find("playerMenu").GetComponent<Animator>();
        }

        private void Update()
        {
            Debug.Log(leftHand.GetVelocityEstimate().y);
            if ((leftHand.GetVelocityEstimate().y * -1 > threshold && input.isGrippingLeft) || Input.GetKeyDown(KeyCode.M))
            {
                menu.SetBool("open", true);
                menu.transform.position = leftHand.transform.position;
                menu.transform.LookAt(movement.camera);
            }
            else if ((rightHand.GetVelocityEstimate().y * -1 > threshold && input.isGrippingRight) || Input.GetKey(KeyCode.M))
            {
                menu.SetBool("open", true);
                menu.transform.position = rightHand.transform.position;
                menu.transform.LookAt(movement.camera);
            }

            if (leftHand.GetVelocityEstimate().y > threshold || Input.GetKey(KeyCode.N))
            {
                menu.SetBool("open", false);
            }
            else if (rightHand.GetVelocityEstimate().y > threshold || Input.GetKey(KeyCode.N))
            {
                menu.SetBool("open", false);
            }
        }
    }
}
