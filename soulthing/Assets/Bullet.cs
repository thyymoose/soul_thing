using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        Ememy ememy = hitInfo.GetComponent<Ememy>();
        if (ememy != null)
        {
            ememy.TakeDamage(10);
        }

        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
