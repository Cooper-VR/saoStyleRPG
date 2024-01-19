using SAOrpg.playerAPI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace SAOrpg.UI
{
    public class confirmationWindowControl : MonoBehaviour
    {
        public collisionChecker yes;
        public collisionChecker no;
        public TMP_Text alertText;
        public string text;
        public Transform cam;
        public float maxSpeed = 1f;

        private void Update()
        {
            alertText.text = text;
            DampenToCamera();
            transform.rotation = cam.transform.rotation;
        }

        private void DampenToCamera()
        {
            Vector3 targetPosition = cam.TransformPoint(new Vector3(0, -0.2f, 0.7f));
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxSpeed * Time.deltaTime);

                    }
    }
}
