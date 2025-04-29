using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraPlace : MonoBehaviour
{
    public GameObject model;
    public GameObject camPrefab;
    private List<GameObject> placedCams = new List<GameObject>();
    private int camsPlaced;
    public int maxCams;
    public float pickupDistance = 5f;
    private GhostAI ghost;
    public TextMeshProUGUI camText;
    private PullUpCamera cameraPull;

    // Start is called before the first frame update
    void Start()
    {
        ghost = FindObjectOfType<GhostAI>();
        camText.text = (maxCams - camsPlaced).ToString();
        cameraPull = GetComponent<PullUpCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float closestDistance = pickupDistance;
            GameObject closestLight = null;
            foreach (GameObject g in placedCams)
            {
                if (Vector3.Distance(model.transform.position, g.transform.position) < closestDistance)
                {
                    closestLight = g;
                    closestDistance = Vector3.Distance(model.transform.position, g.transform.position);
                }
            }

            if (closestLight != null)
            {
                placedCams.Remove(closestLight);
                camsPlaced--;
                camText.text = (maxCams - camsPlaced).ToString();
                Destroy(closestLight);

            }
            else if (camsPlaced < maxCams)
            {
                camsPlaced++;
                camText.text = (maxCams - camsPlaced).ToString();
                GameObject newLight = Instantiate(camPrefab, model.transform.position, model.transform.rotation);
                placedCams.Add(newLight);
                cameraPull.registerCam(newLight);
            }
        }

    }
}
