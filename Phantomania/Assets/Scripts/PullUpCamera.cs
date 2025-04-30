using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullUpCamera : MonoBehaviour
{
    public List<GameObject> cameras = new List<GameObject>();
    public Dictionary<GameObject, GameObject> uiCameras = new Dictionary<GameObject, GameObject>();
    public bool canPullUp = true;
    public bool pulledUp;
    public GameObject camUI;
    private Index index;
    public RectTransform camMarker;
    public RectTransform playerMarker;
    public GameObject model;
    public GameObject uiCamPrefab;
    public GameObject mainCanvas;
    public PlacedCam currentCam;
    public Camera mainCamera;

    private void Start()
    {
        index = GetComponent<Index>(); 
    }

    void Update()
    {
        if (!index.paused && canPullUp && Input.GetKeyDown(KeyCode.F))
        {
            //Putdown current camera if it is up
            if (currentCam != null)
            {
                currentCam.Disable();
                currentCam = null;
                mainCamera.enabled = true;
                camUI.SetActive(true);
                camVisibles(false);
            }
            //Pull up or put down camera
            else if (pulledUp)
            {
                
                pulledUp = false;
                camUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                
                pulledUp = true;
                camUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;

                
                playerMarker.localPosition = convertToMap(model.transform.position);
            }
        }
    }

    public void registerCam(GameObject cam)
    {
        cameras.Add(cam);
        GameObject newCamUI = Instantiate(uiCamPrefab);
        RectTransform newRect = newCamUI.GetComponent<RectTransform>();
        newCamUI.transform.SetParent(mainCanvas.transform, false);
        newRect.localPosition = convertToMap(cam.transform.localPosition);
        uiCameras[cam] = newCamUI;
        CamButton button = newCamUI.GetComponent<CamButton>();
        button.corCam = cam;
    }

    public void destroyCam(GameObject cam)
    {
        cameras.Remove(cam);
        Destroy(uiCameras[cam]);
        uiCameras.Remove(cam);
    }

    public void camVisibles(bool on)
    {
        CamVisible[] visibles = FindObjectsOfType<CamVisible>();
        foreach(CamVisible g in visibles)
        {
            g.Toggle(on);
        }
    }

    Vector3 convertToMap(Vector3 input)
    {
        //Get distance from bottom left corner in map
        float realX = input.x - 74.21f;
        float realY = input.z - 99.85f;

        //Add the distance to the bottom left corner of the ui map
        return new(-176.1f - (realX * 2.84782967486f), -175.7f - (realY * 2.93810013717f), 0);

    }

    public void disableMainCam()
    {
        mainCamera.enabled = false;
    }
}
