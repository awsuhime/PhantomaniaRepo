using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool state = true;
    public KeyCode flashlightKey;
    public GameObject flashlight;
    public float lightFog = 0.1f;
    public float darkFog = 0.7f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(flashlightKey))
        {
            state = !state;
            flashlight.SetActive(state);
            if (state)
            {
                RenderSettings.fogDensity = lightFog;   
            }
            else
            {
                RenderSettings.fogDensity = darkFog;

            }
        }
    }
}
