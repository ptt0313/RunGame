using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : State
{
    [SerializeField] float speed = 20f;
    [SerializeField] float limitSpeed = 60f;
    [SerializeField] float increaseValue = 5.0f;
    [SerializeField] float increaseTime = 10.0f;

    public float Speed
    {
        get { return speed; }
    }
    private void Awake()
    {
        StartCoroutine(Increase());
    }
    public IEnumerator Increase()
    {
        
        while (state == true && speed < limitSpeed)
        {
            yield return CoroutinCache.waitForSecond(10);

            speed += increaseValue;
        }
    
    }
}
