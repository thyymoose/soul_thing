using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ememy_ai : MonoBehaviour
{

    public Rigidbody2D rb;
    private Transform playerpos;
    private float distnaceX = 0;
    private float distnaceY = 0;
    private int move = 0;
    private float maxplayerSpeed = 10f;
    private float acellrate = 5; 
    private bool attacked = false;
    private bool runaway = false;
    private bool hitstopped = false;
    Coroutine enemyAI;
    // Start is called before the first frame update
    void Start()
    {
        GameObject manger = GameObject.Find("player");
        playerpos = manger.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      
     player_find();
    }
    void player_find()
    {
        distnaceX = transform.position.x - playerpos.position.x;
        distnaceY = transform.position.y - playerpos.position.y;
        if(distnaceX > 0)
        {
            move = 1;
        }
        else
        {
            move = -1;
        }
        if(!hitstopped)
        {
            return;
        }
        if(!attacked)
        {
            if(distnaceX * move > 5)
            {
               moveEmemy(-move);
            }
            if(distnaceX * move < 2.5f && transform.position. y < distnaceY)
            {
                var number = Random.Range(0,11);
                if(number >= 5)
                {
                    jumpStrike();
                }
                else
                {
                   ramStrike(); 
                }
                
                attacked = true;
                enemyAI = StartCoroutine(enemyWait());
            }
        }
        if(attacked && runaway)
        {
            if(distnaceX * move < 5)
            {
             moveEmemy(move);
            }
            if(distnaceX * move > 5)
            {
                Debug.Log("reset");
                attacked = false;
                runaway = false;
            }
        }
    }
    IEnumerator enemyWait()
    {
        yield return new WaitForSeconds(1f);
        runaway = true;

    }
    void moveEmemy(float move)
    {
        var speeddirection = maxplayerSpeed * move;
        var speeddif = speeddirection - rb.velocity.x;
        var movment = speeddif * acellrate;
         rb.AddForce(new Vector2(movment, 0)); 
    }
    void jumpStrike()
    {
        rb.AddForce(new Vector2 (5 + distnaceX * -move, 5 + distnaceY), ForceMode2D.Impulse);
    }
    void ramStrike()
    {
        rb.AddForce(new Vector2 ((10 + distnaceX) * -move,0), ForceMode2D.Impulse);
    }
    public void hitstop()
    {
        rb.velocity = new Vector2(0,0);
        hitstopped = true;
        StopAllCoroutines();
        enemyAI = StartCoroutine(hit());
    }
    IEnumerator hit()
    {
        yield return new WaitForSeconds(.5f);
        hitstopped = false;
    }
}
