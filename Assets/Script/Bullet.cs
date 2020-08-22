using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Bird bird;
    private Rigidbody2D rigidBullet;
    private float bulletSpeed = 4f;
    private float bulletVelY = 0f;
    private float bulletVelZ = 0f;
    private float bulletDestroy = 1.5f;

    void Start()
    {
        rigidBullet = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        rigidBullet.velocity = new Vector3(bulletSpeed, bulletVelY, bulletVelZ);
        Destroy(gameObject, bulletDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

    }

}

    
