using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedCam : MonoBehaviour
{
    public float syncStart;
    public float timeToSync;
    public bool synced;
    private PullUpCamera pullUp;
    public CamButton myButton;

    public Camera cam;
    void Start()
    {
        syncStart = Time.time;
        pullUp = FindObjectOfType<PullUpCamera>();
        myButton = pullUp.uiCameras[gameObject].GetComponent<CamButton>();
    }

    void Update()
    {
        if (!synced && Time.time - syncStart > timeToSync)
        {
            synced = true;
            myButton.syncColor();
        }
    }

    public void Switch()
    {
        cam.enabled = true;
    }

    public void Disable()
    {
        cam.enabled = false;
    }
}
