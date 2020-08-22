using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    void Update()
    {
        //cek burung mati atau tidak
        if (!bird.IsDead())
        {
            //menggerakan game object ke kiri
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetSize(float size)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        //Pengecekan Null variable
        if (collider != null)
        {
            //mengubah ukuran collider
            collider.size = new Vector2(collider.size.x, 8.62f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        //get score jika burung tidak null dan burung belum mati;
        if (bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }
}
