using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private PipeWithBulletEffect pipeUp, pipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] public float holeSize = 1f;
    [SerializeField] private float MaxMinOffset = 1;

    
    [SerializeField] private Point point;

    private Coroutine CR_Spawn;

    private void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {



        PipeWithBulletEffect newPipeUp = Instantiate (pipeUp, transform.position, Quaternion.Euler(0, 0, 180));
        newPipeUp.gameObject.SetActive(true);
        PipeWithBulletEffect newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);
        newPipeDown.gameObject.SetActive(true);

        ////Hole normal
        //newPipeUp.transform.position += Vector3.up * (holeSize / 2) ;
        //newPipeDown.transform.position += Vector3.down * (holeSize / 2) ;

        //Hole Size Random yang disesuaikan khusus float y Random.range
        float holeSize = UnityEngine.Random.Range(1f, 2.4f);
        newPipeUp.transform.position += Vector3.up * holeSize /2 ;
        newPipeDown.transform.position += Vector3.down * holeSize /2 ;

        //fungsi y pilih salah satu 
        //float y = maxminoffset * mathf.cos(time.time) ;
        //float y = maxminoffset * mathf.sin(time.time) ;
        float y = UnityEngine.Random.Range(-0.8f, 1.2f) ;
        
        newPipeUp.transform.position += Vector3.up * y ;
        newPipeDown.transform.position += Vector3.up * y;

        //score
        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y ;

        
    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            if (bird.IsDead())
            {
                StopSpawn();
            }

            SpawnPipe();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

    
