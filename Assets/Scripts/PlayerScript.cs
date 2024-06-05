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
    private float nextShot = 0f;

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
        float rotateSideways = -(Input.GetAxisRaw("Mouse X")) * mouseSensitivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, rotateSideways));

        float rotateVertical = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0, rotateVertical, 0));

        //player shoot
        if (Time.time > nextShot)
        {
            if (Input.GetMouseButtonDown(0) && ammo > 0)
            {
                Ray cameraRay = viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

                if (Physics.Raycast(cameraRay, out RaycastHit hit))
                {
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                }

                nextShot = Time.time + shotDelay;
            }
        }
    }
}
