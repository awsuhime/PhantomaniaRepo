using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EMPGun : MonoBehaviour
{
    private ToolSelect toolSelect;
    
    private bool charging;
    public float chargeTime = 3f;
    private float chargeStart;
    private bool charged;
    private float chargedStart;
    public float chargeHoldTime = 5f;
    private GhostAI ghost;
    public TextMeshProUGUI chargeText;
    public GameObject model;
    public float width = 5;
    public float length = 10;
    public float stunDuration = 5f;
    public LayerMask movers;
    private PullUpCamera pullUp;
    void Start()
    {
        toolSelect = GetComponent<ToolSelect>();
        ghost = FindObjectOfType<GhostAI>();
        pullUp = GetComponent<PullUpCamera>();
    }

    void Update()
    {
        if (!pullUp.pulledUp && !charging && !charged && Input.GetKeyDown(KeyCode.E))
        {
            toolSelect.canSelect = false;
            charging = true;
            chargeStart = Time.time;
            Debug.Log("Charging");
            pullUp.canPullUp = false;
        }
        if (charging)
        {
            chargeText.text = Mathf.Round((Time.time - chargeStart) / chargeTime * 100).ToString();
            if (Time.time - chargeStart > chargeTime)
            {
                charging = false;
                charged = true;
                Debug.Log("Charging Done");
                chargedStart = Time.time;
                
            }
            
            
        }
        if (charged)
        {
            
            chargeText.text = (5 - Mathf.Round((Time.time - chargedStart) / chargeHoldTime * 5)).ToString();
            if (Input.GetKeyDown(KeyCode.E) || Time.time - chargedStart > chargeHoldTime)
            {
                Debug.Log("Fired");
                Collider[] cols = Physics.OverlapBox(model.transform.position, new Vector3(width, 10, length), Quaternion.identity, movers);
                foreach (Collider col in cols)
                {
                    if (col.gameObject.GetComponent<GhostAI>() != null)
                    {
                        ghost.Stun(stunDuration);
                    }
                }
                ghost.Attention(model.transform.position, 150f);
                chargeText.text = "";
                charged = false;
                toolSelect.canSelect = true;
                pullUp.canPullUp = true;

            }
        }
    }
}
