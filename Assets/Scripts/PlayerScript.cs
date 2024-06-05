using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5;

    public Camera viewCam;
    public float mouseSensitivity = 10;

    public GameObject bulletImpact;
    public int ammo = 100;
    public float shotDelay = 5f;
    private float countdown = 5f;

    void Start()
    {
        
    }

    void Update()
    {

        //player movement control
        Vector3 moveForward = transform.right * Input.GetAxis("Vertical");
        Vector3 moveSideways = -(transform.up) * Input.GetAxis("Horizontal");
        rb.velocity = (moveForward + moveSideways) * moveSpeed;

        //player view control
        float rotateSideways = -(Input.GetAxisRaw("Mouse X")) * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, rotateSideways));

        float rotateVertical = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0, rotateVertical, 0));

        //player shoot
        if (countdown < shotDelay)
        {
            countdown += Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && ammo > 0)
            {
                Ray cameraRay = viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

                if (Physics.Raycast(cameraRay, out RaycastHit hit))
                {
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                }

                countdown = 0;
            }
        }
    }
}
