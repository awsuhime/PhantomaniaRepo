using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xSens;
    public float ySens;
    private float xRot;
    private float yRot;
    private float speed;
    public float regularSpeed = 4;
    public float sprintSpeed = 7;
    public float sprintAttRange = 10f;
    private Rigidbody rb;
    public GameObject camObject;
    public GameObject model;
    private GhostAI ghostAI;
    private PullUpCamera pullUp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ghostAI = FindObjectOfType<GhostAI>();
        Cursor.lockState = CursorLockMode.Locked;
        pullUp = GetComponent<PullUpCamera>();
    }

    void Update()
    {
        if (!pullUp.pulledUp)
        {
            //Sprinting
            if (Input.GetMouseButton(1))
            {
                speed = sprintSpeed;
                ghostAI.Attention(model.transform.position, sprintAttRange);
            }
            else
            {
                speed = regularSpeed;
            }
            float xMouse = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
            float yMouse = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

            yRot += xMouse;
            xRot -= yMouse;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            camObject.transform.rotation = Quaternion.Euler(xRot, yRot, 0);
            model.transform.rotation = Quaternion.Euler(0, yRot, 0);

            float hori = Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");

            Vector3 moveDir = (model.transform.forward * vert) + (model.transform.right * hori);

            rb.velocity = moveDir.normalized * speed;
        }
        

        
    }
}
