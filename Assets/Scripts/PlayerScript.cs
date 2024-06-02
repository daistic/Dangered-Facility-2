using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 moveForward = transform.up * Input.GetAxis("Vertical");
        Vector3 moveSideways = transform.right * Input.GetAxis("Horizontal");
        rb.velocity = (moveForward + moveSideways) * moveSpeed;
    }
}
