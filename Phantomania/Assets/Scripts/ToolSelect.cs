using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolSelect : MonoBehaviour
{
    private int currentSelection;
    public int maxSelections = 3;
    public Image[] icons;
    private LightPlace lightPlace;
    private CameraPlace cameraPlace;
    private EMPGun empGun;
    private PullUpCamera pullUp;
    public bool canSelect = true;
    void Start()
    {
        lightPlace = GetComponent<LightPlace>();
        empGun = GetComponent<EMPGun>();
        cameraPlace = GetComponent<CameraPlace>();
        pullUp = GetComponent<PullUpCamera>();
    }

    void Update()
    {
        if (canSelect && !pullUp.pulledUp)
        {
            for (int i = 1; i <= maxSelections; i++)
            {
                if (Input.GetKeyDown("" + i))
                {
                    if (currentSelection == i)
                    {
                        icons[currentSelection - 1].color = Color.white;
                        Toggle(currentSelection, false);
                        currentSelection = 0;
                    }
                    else
                    {
                        if (currentSelection != 0)
                        {
                            icons[currentSelection - 1].color = Color.white;
                            Toggle(currentSelection, false);
                        }
                        currentSelection = i;
                        icons[currentSelection - 1].color = Color.blue;
                        Toggle(currentSelection, true);
                    }
                    Debug.Log(currentSelection);
                }
            }
        }
        
        
    }

    void Toggle(int i, bool state)
    {
        if (i == 1)
        {
            lightPlace.enabled = state;
        }
        else if (i == 2)
        {
            cameraPlace.enabled = state;
        }
        else if (i == 3)
        {
            empGun.enabled = state;

        }
    }

    public void Deselect()
    {
        if (currentSelection != 0)
        {
            icons[currentSelection - 1].color = Color.white;
            Toggle(currentSelection, false);
            currentSelection = 0;
        }
        
    }

}
