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

        private float y;
        private float z;

        private void Start()
        {
            y = Random.RandomRange(-0.3f, 0);
            z = Random.RandomRange(0.4f, 0.8f);


            cam = FindObjectOfType<Camera>().transform;
        }

        private void Update()
        {
            alertText.text = text;
            DampenToCamera();
            transform.rotation = cam.transform.rotation;
        }

        private void DampenToCamera()
        {

            Vector3 targetPosition = cam.TransformPoint(new Vector3(0, y, z));
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxSpeed * Time.deltaTime);

                    }
    }
}
