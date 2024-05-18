using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasso_project : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform lassoPos;
    public LayerMask enemy;
    public LayerMask floor;
    void Start()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.AddForce(new Vector2(mousePos.x * 2,mousePos.y * 2),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        hitdetec();
    }
    void hitdetec() 
    {
        var hitInfo =Physics2D.OverlapBox(lassoPos.position,new Vector2(0.5f,0.5f),0,enemy);
        if (hitInfo != null)
            {
                Ememy ememy = hitInfo.GetComponent<Ememy>();
                rb.velocity = new Vector2(0,0);
                lassod(hitInfo.gameObject.transform);
                rb.gravityScale = 0;
                  
            }
        var hit =Physics2D.OverlapBox(lassoPos.position,new Vector2(0.5f,0.5f),0,floor);
        if(hit != null)
        {
            Destroy(gameObject);
        }  
        
       
    }
    void lassod(Transform attachpoint)
    {
        lassoPos.position = new Vector2(attachpoint.position.x,attachpoint.position.y);
        
    }
}
