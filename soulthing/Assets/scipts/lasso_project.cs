using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasso_project : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform lassoPos;
    public LayerMask enemy;
    public LayerMask floor;
    public LayerMask player;
    public bool canlasso = true;
    public float direction = 1;
    public SpriteRenderer dicpic;
    Coroutine cooldown;
    void Start()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.AddForce(new Vector2(mousePos.x * 2,mousePos.y * 2),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(canlasso)
        {
            hitdetec();
        }
        
    }
    void hitdetec() 
    {

        
        var hitInfo =Physics2D.OverlapBox(lassoPos.position,new Vector2(0.5f,0.5f),0,enemy);
        if (hitInfo != null)
            {
                Ememy ops = hitInfo.GetComponent<Ememy>();
                rb.velocity = new Vector2(0,0);
                lassod(hitInfo.gameObject.transform);
                rb.gravityScale = 0;
                GameObject manger = GameObject.Find("player");
                lasso_weapon lasso = manger.GetComponent<lasso_weapon>();
                lasso.lassoOut = true;
                lasso.lassoOn = true;
                  
            }
        var hit =Physics2D.OverlapBox(lassoPos.position,new Vector2(0.5f,0.5f),0,floor);
        if(hit != null)
        {
            Destroy(gameObject);
            GameObject manger = GameObject.Find("player");
            lasso_weapon lasso = manger.GetComponent<lasso_weapon>();
            lasso.lassoOut = false;
        }
       
    }
    void lassod(Transform attachpoint)
    {
        lassoPos.position = new Vector2(attachpoint.position.x,attachpoint.position.y);
        
    }
    public void pull()
    {
        GameObject manger = GameObject.Find("player");
        lasso_weapon lasso = manger.GetComponent<lasso_weapon>();
         lasso.lassoOn = false;
        cooldown = StartCoroutine(endattack(lasso));
    }
    IEnumerator endattack(lasso_weapon lasso)
    {
        var hitInfo =Physics2D.OverlapBox(lassoPos.position,new Vector2(0.5f,0.5f),0,enemy);
        if (hitInfo != null)
            {
                Ememy ops = hitInfo.GetComponent<Ememy>();
                ops.pull(lasso.firepoint.position.x-hitInfo.gameObject.transform.position.x,lasso.firepoint.position.y-hitInfo.gameObject.transform.position.y);
                  
            }
        dicpic.enabled = false;
        yield return new WaitForSeconds(.5f);
        fuckinWork();
        Destroy(gameObject);
       
        
               
    }
    public void fuckinWork()
    {
        GameObject manger = GameObject.Find("player");
        lasso_weapon lasso = manger.GetComponent<lasso_weapon>();
        lasso.lassoOut = false;
        canlasso = true;
        
    }
   
}
