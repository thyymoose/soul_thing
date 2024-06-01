using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIperent : MonoBehaviour
{
    public Transform enemypos;
    public Transform attackpos;
    public Transform playerpos;
    public Transform groundcheck;
    public currentstate state;
    public float attackrange;
    public float attacksize;
    public float damage;
    public LayerMask player;
    public LayerMask ground;
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
                walk();
                break;
            case currentstate.attacking:
                if(canhit)
                {
                 attack();
                 canhit = false;
                }
                break;
            case currentstate.retreating:
                retreat();
                break;
            case currentstate.inair:
                canhit = false;
                break;
             case currentstate.hitstop:
                coroutine = StartCoroutine(hitstop(new Vector2(0,0)));
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
    public bool isgrounded()
    {
       return Physics2D.OverlapCircle(groundcheck.position,.1f,ground);
    }
    public enum currentstate
    {
        walking,
        attacking,
        retreating,
        hitstop,
        inair
    }
    IEnumerator hitstop(Vector2 vec)
    {
        rb.velocity = vec;
        yield return new WaitForSeconds(.3f);
        state = currentstate.walking;
        switchstate();
        gettinghit = false;
    }
}
