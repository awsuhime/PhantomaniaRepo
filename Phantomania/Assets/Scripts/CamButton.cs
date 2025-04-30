using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamButton : MonoBehaviour
{
    public GameObject corCam;
    private PullUpCamera pullUp;
    private PlacedCam cam;
    public Image img;
    private bool synced;

    void Start()
    {
        pullUp = FindObjectOfType<PullUpCamera>();
        cam = corCam.GetComponent<PlacedCam>();
    }

    
    public void tryCam()
    {
        if (cam.synced)
        {
            cam.Switch();
            pullUp.currentCam = cam;
            pullUp.disableMainCam();
            pullUp.camUI.SetActive(false);
            pullUp.camVisibles(true);
        }
    }

    public void syncColor()
    {
        img.color = Color.green;
    }
}
