using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public float health = 100;
    // Start is called before the first frame update
    public void TakeDamage (float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
