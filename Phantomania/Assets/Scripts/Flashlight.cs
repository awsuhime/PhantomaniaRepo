using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool state = true;
    public KeyCode flashlightKey;
    public GameObject flashlight;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(flashlightKey))
        {
            state = !state;
            flashlight.SetActive(state);
        }
    }
}
