using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightCycle : MonoBehaviour
{
    [Header("color gradients")]
    public Gradient starColor;
    public Gradient lightingColor;
    public Gradient moonColor;

    [Header("Stars")]
    public Transform stars;
    public ParticleSystem star;

    [Header("Sun/Moon")]
    public GameObject Sun;
    public GameObject Moon;
    public Material MoonMaterial;


    #region private Vaiables

    private TimeSpan time;
    private System.DateTime date;

    public float currentTransitionTime;

    public float transitionDuration;

    #endregion


    // Update is called once per frame
    void Update()
    {
        
        time = System.DateTime.Now.TimeOfDay;
        date = System.DateTime.Now.Date;

        colorSet();
        RotateObjects();
        FollowPlayer();


        if (time.TotalHours > 6 && time.TotalHours < 18)
        {
            Sun.SetActive(true);
            Moon.SetActive(false);
        }
        else
        {
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