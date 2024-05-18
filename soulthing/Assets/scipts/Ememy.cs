using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ememy : MonoBehaviour
{

    public int health = 100;
    public Rigidbody2D rb;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    public void pull(float direction)
    {
       
        rb.AddForce(new Vector2(10*direction,10),ForceMode2D.Impulse);
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
