using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class weather
{
    public Color32 hightCloudColor;
    public Color32 lowCloudColor;

    [Range(0, 2)]
    public float cloudDencityMin;
    [Range(0, 2)]
    public float cloudDencityMax;
}

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

    [Header("weatherRanges")]
    public float[] weatherPercentages = new float[3];

    [Header("clouds")]
    public Transform clouds;
    public Material highClouds;
    public Material lowClouds;

    [Header("WeatherPresets")]
    public weather[] weathers = new weather[3];

    #region private Vaiables
    private float max;
    private TimeSpan time;
    private System.DateTime date;
    public bool transitioning;
    public float currentTransitionTime;
    private float densityPerSec;
    public float transitionDuration;
    private float currentDensity;
    #endregion

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        highClouds.SetFloat("_Density", currentDensity);
        time = System.DateTime.Now.TimeOfDay;
        date = System.DateTime.Now.Date;

        colorSet();
        RotateObjects();
        FollowPlayer();

        if (transitioning)
        {
            currentDensity -= densityPerSec * Time.deltaTime;
        }
        else
        {
            StartCoroutine(ExampleCoroutine(10));
        }


        

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
    private void WeatherCalculations()
    {
        float weather = UnityEngine.Random.value * 100;
        float transitionTime = UnityEngine.Random.Range(0, 180f);
        transitionDuration = UnityEngine.Random.Range(2, 250);
        if (weather > weatherPercentages[0])
        {
            if (weather > weatherPercentages[1] + weatherPercentages[0])
            {
                transitionWeather(weathers[2], transitionTime);
            }
            transitionWeather(weathers[1], transitionTime);
        }
        else
        {
            transitionWeather(weathers[0], transitionTime);
        }

        
    }
    private void FollowPlayer()
    {
        clouds.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    private void transitionWeather(weather nextWeather, float transitionTime)
    {
        
        float highDensity = highClouds.GetFloat("_Density");
        float lowDensity = lowClouds.GetFloat("_Density");
        densityPerSec = (highDensity - UnityEngine.Random.Range(nextWeather.cloudDencityMin, nextWeather.cloudDencityMax)) / transitionTime;
        Debug.Log("set to true");
        transitioning = true;
    }

    IEnumerator ExampleCoroutine(float waitTime)
    {
        //Print the time of when the function is first called.
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitTime);
        Debug.Log("10 sec up");
        WeatherCalculations();


    }
    #endregion
}