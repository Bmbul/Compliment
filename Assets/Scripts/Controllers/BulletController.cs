using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Threading.Tasks;
using DG.Tweening;
using Photon.Pun;
using System;

public class BulletController : MonoBehaviour
{
    Light2D light2D;
    float startingRadius;
    [SerializeField] float fadeTime;

    private void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    private void Start()
    {
        startingRadius = light2D.pointLightOuterRadius;
    }

    async void FadeOut()
    {
        float startTime = Time.time;
        while (Time.time - startTime < fadeTime)
        {
            light2D.pointLightOuterRadius = startingRadius * (1 - (Time.time - startTime)/fadeTime);
            await Task.Yield();
        }
        try
        {
            gameObject.SetActive(false);
        }
        catch(Exception e)
        {

        }
    }
}
