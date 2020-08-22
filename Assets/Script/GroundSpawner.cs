﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private Ground groundRef;
    private Ground prevGround;

    private void SpawnGround()
    {
        if (prevGround != null)
        {
            Ground newGround = Instantiate(groundRef);
            newGround.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Ground ground = collision.GetComponent<Ground>();
        if (ground)
        {
            prevGround = ground;
            SpawnGround();
        }
    }
}