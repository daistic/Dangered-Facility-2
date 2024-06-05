using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float lifetime = 0.3f;
    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
