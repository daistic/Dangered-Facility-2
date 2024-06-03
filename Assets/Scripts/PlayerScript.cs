using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject viewCam;
    public float moveSpeed = 5;
    public float mouseSensitivity = 10;

    void Start()
    {
        
    }

    void Update()
    {
        //player movement control
        Vector3 moveForward = transform.right * Input.GetAxis("Vertical");
        Vector3 moveSideways = -(transform.right) * Input.GetAxis("Horizontal");
        rb.velocity = (moveForward + moveSideways) * moveSpeed;

        //player view control
        float rotateSideways = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, rotateSideways));

        float rotateVertical = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0, rotateVertical, 0));
    }
}
