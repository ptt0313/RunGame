using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action action;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey) return;
        else action?.Invoke();

    }
}
