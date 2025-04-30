using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamVisible : MonoBehaviour
{
    public MeshRenderer render;
    public SkinnedMeshRenderer skinRender;

    public bool realOnly;
    void Start()
    {
        
    }

    public void Toggle(bool cam)
    {
        if (cam)
        {
            if (render != null)
            {
                render.enabled = !realOnly;

            }
            if (skinRender != null)
            {
                skinRender.enabled = !realOnly;
            }
        }
        else
        {
            if (render != null)
            {
                render.enabled = realOnly;

            }
            if (skinRender != null)
            {
                skinRender.enabled = realOnly;
            }
            
        }
        
    }
}
