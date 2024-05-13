using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public LayerMask walls;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        Ememy ememy = hitInfo.GetComponent<Ememy>();
        if(hitInfo.gameObject.layer == 7)
        {
             if (ememy != null)
             {
                ememy.TakeDamage(10);
                Destroy(gameObject);  
             }  
        }
        else
        {
            Destroy(gameObject); 
        }

       
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
