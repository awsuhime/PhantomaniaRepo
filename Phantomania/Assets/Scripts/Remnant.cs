using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remnant : MonoBehaviour
{
    public GameObject model;
    private float startTime;
    public float timeToRemove = 5f;
    public float removeRange = 5f;
    private bool removing;
    private GhostTypes types;
    void Start()
    {
    }

    void Update()
    {
        if (!removing && Vector3.Distance(model.transform.position, transform.position) < removeRange)
        {
            Debug.Log("Remnant removal started");
            removing = true;
            startTime = Time.time;
        }

        if (removing)
        {
            if (Time.time  - startTime > timeToRemove)
            {
                Debug.Log("Remnant removed");
                types = FindObjectOfType<GhostTypes>();
                types.remnantsLeft--;
                Destroy(gameObject);
            }
            else if (Vector3.Distance(model.transform.position, transform.position) > removeRange)
            {
                removing = false;
            }
            
        }
    }
}
