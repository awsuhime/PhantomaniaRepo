using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Index : MonoBehaviour
{
    public GameObject index;

    public bool paused;
    public bool indUp = true;

    public GameObject currentPage;
    private void Start()
    {
       
    }
    void Update()
    {
        if (!paused)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                paused = true;
                Time.timeScale = 0;
                index.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                paused = false;
                Time.timeScale = 1;
                index.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;

            }
        }

        
    }

    public void flipTo(GameObject page)
    {
        currentPage.SetActive(false);
        page.SetActive(true);
        currentPage = page;
    }
}
