using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamVisible : MonoBehaviour
{
    public MeshRenderer render;

    public bool realOnly;
    void Start()
    {
        
    }

    public void Toggle(bool cam)
    {
        if (cam)
        {
            render.enabled = !realOnly;
        }
        else
        {
            render.enabled = realOnly;
        }
        
    }
}
