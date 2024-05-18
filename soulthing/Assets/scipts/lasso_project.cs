using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasso_project : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform lassoPos;
    void Start()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.AddForce(new Vector2(mousePos.x * 2,mousePos.y * 2),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        Ememy ememy = hitInfo.GetComponent<Ememy>();
        if(hitInfo.gameObject.layer == 7)
        {
             if (ememy != null)
             {
                rb.velocity = new Vector2(0,0);
                lassod(hitInfo.gameObject.transform);
                rb.gravityScale = 0;
                  
             }  
        }
        else
        {
            Destroy(gameObject); 
        }

       
    }
    void lassod(Transform attachpoint)
    {
        lassoPos.position = new Vector2(attachpoint.position.x,attachpoint.position.y);
        
    }
}
