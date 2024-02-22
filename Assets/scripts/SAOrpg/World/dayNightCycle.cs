using System;
using UnityEngine;

namespace SAOrpg.World
{
    public class dayNightCycle : MonoBehaviour
    {
        [Header("color gradients")]
        public Gradient starColor;
        public Gradient lightingColor;
        public Gradient moonColor;

        public Gradient skyTint;
        public Gradient exposure;
        public Gradient cloudColor;

        [Header("Stars")]
        public Transform stars;
        public ParticleSystem star;

        [Header("Sun/Moon")]
        public GameObject Sun;
        public GameObject Moon;
        public Material MoonMaterial;
        public Material skyBox;

        [Header("clouds")]
        public Material cloudMaterial1;
        public Material cloudMaterial2;
        public Transform clouds;


        #region private Vaiables

        private TimeSpan time;
        private System.DateTime date;

        public float currentTransitionTime;

        public float transitionDuration;

        #endregion


        // Update is called once per frame
        void Update()
        {
            clouds.position = transform.position;

            time = DateTime.Now.TimeOfDay;
            date = DateTime.Now.Date;

            colorSet();
            RotateObjects();
            FollowPlayer();


            if (time.TotalHours > 6 && time.TotalHours < 18)
            {
                Sun.SetActive(true);
                Moon.SetActive(false);
                RenderSettings.sun = Sun.GetComponent<Light>();
            }
            else
            {
                RenderSettings.sun = Moon.GetComponent<Light>();
                Sun.SetActive(false);
                Moon.SetActive(true);
            }
        }

        #region priavteHelpers
        private void colorSet()
        {
            MoonMaterial.SetColor("_EmissionColor", moonColor.Evaluate((float)time.TotalHours / 24));
            MoonMaterial.color = moonColor.Evaluate((float)time.TotalHours / 24);
            RenderSettings.ambientSkyColor = lightingColor.Evaluate((float)time.TotalHours / 24);
            RenderSettings.ambientLight = lightingColor.Evaluate((float)time.TotalHours / 24);



            cloudMaterial1.SetColor("_CloudColor", cloudColor.Evaluate((float)time.TotalHours / 24));
            cloudMaterial2.SetColor("_CloudColor", cloudColor.Evaluate((float)time.TotalHours / 24));

            //Debug.Log(exposure.Evaluate((float)time.TotalHours / 24).a);
            skyBox.SetFloat("_Exposure", exposure.Evaluate((float)time.TotalHours / 24).a - 0.2f / 0.9f + 0.3f);
            skyBox.SetFloat("_AtmosphereThickness", exposure.Evaluate((float)time.TotalHours / 24).a / 1f);
        }
        private void RotateObjects()
        {
            star.startColor = starColor.Evaluate((float)time.TotalHours / 24);
            stars.rotation = Quaternion.Euler((float)(time.TotalHours * ((float)360 / (float)24) * 2), 0, 0);
            transform.rotation = Quaternion.Euler((float)(time.TotalHours * ((float)360 / (float)24)), 0, 50f - (100f / 12f) * date.Month);
        }

        private void FollowPlayer()
        {
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        #endregion
    }
}