using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ememy : MonoBehaviour
{

    public float health = 100;
    public Rigidbody2D rb;

    public void TakeDamage (float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    public void pull(float x, float y)
    {
       
        rb.AddForce(new Vector2(x * 2,y * 2),ForceMode2D.Impulse);
    }
    
    void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
