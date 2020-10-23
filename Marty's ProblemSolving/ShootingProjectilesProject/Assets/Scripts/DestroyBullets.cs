using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    public float maxDistance = 8;
    public bool positive, negative;

    void Start()
    {
        var position = gameObject.transform.position;
        if (position.z >= 0)
        {
            positive = true;
            maxDistance = position.z + 8;
        }

        if (position.z < 0)
        {
            negative = true;
            maxDistance = position.z - 8;
        }
    }

    private void Update()
    {
        if (positive && gameObject.transform.position.z > maxDistance)
        {
            DestroyBullet();
        }

        if (negative && gameObject.transform.position.z > maxDistance)
        {
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        //if (transform.position.x > bulletDistance.transform.position.x + 8 || transform.position.x < (bulletDistance.transform.position.x + 8) * -1)
        Destroy(gameObject);
    }
    
    // void OnTriggerEnter(Collider other)
    // {
    //     Destroy(gameObject);
    // }

}
