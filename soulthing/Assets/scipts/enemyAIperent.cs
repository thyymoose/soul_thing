using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIperent : MonoBehaviour
{
    public Transform enemypos;
    public Transform attackpos;
    public Transform playerpos;
    public currentstate state;
    public float attackrange;
    public float attacksize;
    public float damage;
    public LayerMask player;
    public float speed;
    public Rigidbody2D rb;
    public bool canhit = true;
    public bool gettinghit = false;
    private int direction;
    Coroutine coroutine;

    public float playerclose()
    {
       float distance = playerpos.position.x-enemypos.position.x;
       if(distance < 0)
       {
         direction = -1;
         return distance * direction;
       }
       else
       {
         direction = 1;
         return distance;
       }
    }
    public void switchstate()
    {
        switch(state)
        {
            case currentstate.walking:
                Debug.Log("walking");
                walk();
                break;
            case currentstate.attacking:
                Debug.Log("attacking");
                if(canhit)
                {
                 attack();
                 canhit = false;
                }
                break;
            case currentstate.retreating:
                Debug.Log("retreating");
                retreat();
                break;
             case currentstate.hitstop:
                Debug.Log("hit");
                coroutine = StartCoroutine(hitstop());
                break;
        }
    }
    public void walk()
    {
        var speeddirection = speed * direction;
        var speeddif = speeddirection - rb.velocity.x;
        var movment = speeddif * 5;
        rb.AddForce(new Vector2(movment, 0));
    }
    public void attack()
    {
       var hit = Physics2D.OverlapCircle(attackpos.position,attacksize,player);
       if(hit != null )
       {
         hit.GetComponent<playerhealth>().TakeDamage(damage);
       }
    }
    public void retreat()
    {
        var speeddirection = speed * -direction;
        var speeddif = speeddirection - rb.velocity.x;
        var movment = speeddif * 5;
        rb.AddForce(new Vector2(movment, 0));
    }
    public enum currentstate
    {
        walking,
        attacking,
        retreating,
        hitstop 
    }
    IEnumerator hitstop()
    {
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(.2f);
        state = currentstate.walking;
        switchstate();
        gettinghit = false;
    }
}
