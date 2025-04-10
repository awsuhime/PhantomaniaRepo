using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlace : MonoBehaviour
{
    public GameObject model;
    public GameObject lightPrefab;
    private List<GameObject> placedLights = new List<GameObject>();
    private int lightsPlaced;
    public int maxLights;
    public float pickupDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float closestDistance = pickupDistance;
            GameObject closestLight = null;
            foreach (GameObject g in placedLights)
            {
                if (Vector3.Distance(model.transform.position, g.transform.position) < closestDistance)
                {
                    closestLight = g;
                    closestDistance = Vector3.Distance(model.transform.position, g.transform.position);
                }
            }

            if (closestLight != null)
            {
                placedLights.Remove(closestLight);
                lightsPlaced--;
                Destroy(closestLight);
            }
            else if (lightsPlaced < maxLights)    
            {
                lightsPlaced++;
                GameObject newLight = Instantiate(lightPrefab, model.transform.position, Quaternion.identity);
                placedLights.Add(newLight);
            }
        }
        
    }
}
