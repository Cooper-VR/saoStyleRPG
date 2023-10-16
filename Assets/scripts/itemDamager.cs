using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using SAOrpg.playerAPI.RPGsstuff;

namespace SAOrpg.items
{
    public class itemDamager : MonoBehaviour
    {
        public enum SharpDirection
        {
            forward,
            backward,
            right,
            left,
            up,
            down,
            none
        }

        public SharpDirection sharpDirection;

        public int strengthRequirement;
        public int duribility;
        public int maxDamage;

        private void OnTriggerEnter(Collider hitObject)
        {
            //adjust damge to strength

            //their level/levelRequirment
            //that^3
            //damge * that

            //might need to convert to float
            float damage = maxDamage * (GetComponent<PickupableObject>().alignmentObject.parent.gameObject.GetComponent<playerStats>().strength / strengthRequirement);

            Vector3 velocity = gameObject.GetComponent<VelocityEstimator>().GetVelocityEstimate();

            damage *= velocity.magnitude / GetComponent<PickupableObject>().alignmentObject.parent.gameObject.GetComponent<playerStats>().maxDamageSpeed;


            //find angle between velocty and the sharp direction
            //use unit circle to get damage decimal valve
            //maxDamage * circle deciaml value

            Vector3 sharp = new Vector3();

            switch (sharpDirection)
            {
                case SharpDirection.forward:
                    sharp = Vector3.forward;
                    break;
                case SharpDirection.backward:
                    sharp = Vector3.back;
                    break;
                case SharpDirection.up:
                    sharp = Vector3.up;
                    break;
                case SharpDirection.down:
                    sharp = Vector3.down;
                    break;
                case SharpDirection.left:
                    sharp = Vector3.left;
                    break;
                case SharpDirection.right:
                    sharp = Vector3.right;
                    break;
                case SharpDirection.none:
                    sharp = new Vector3(1, 1, 1);
                    break;
            }

            float angle = Mathf.Abs(Mathf.Acos(Vector3.Dot(velocity, sharp) / (velocity.magnitude * sharp.magnitude)));
            float percentage = Mathf.Cos(angle);

            damage = Mathf.Round(maxDamage * percentage);

            Damager hitDamager;
            //check if hitObject is is player, if so, continue. check if it has a component to deal  damage, if not "immortal object"
            if (hitObject.gameObject == gameObject.GetComponent<PickupableObject>().alignmentObject.parent)
            {
                Debug.Log("hit local player");
            }
            else if (hitObject.TryGetComponent<Damager>(out hitDamager))
            {
                //deal damge
                Debug.Log(damage);
            }
            else
            {
                Debug.Log("imortal obejct");
            }

        }
    }
}


