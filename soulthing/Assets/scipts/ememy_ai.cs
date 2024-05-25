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
    private bool attacked = false;
    private bool runaway = false;
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
        if(!attacked)
        {
            if(distnaceX * move > 3)
            {
               moveEmemy(-move);
            }
            if(distnaceX * move < 2 && transform.position. y < distnaceY)
            {
                jumpStrike();
                attacked = true;
                enemyAI = StartCoroutine(enemyWait());
            }
        }
        if(attacked && runaway)
        {
            if(distnaceX * move < 3)
            {
             moveEmemy(move);
            }
            if(distnaceX * move > 3)
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
         rb.AddForce(new Vector2(3 * move, 0)); 
    }
    void jumpStrike()
    {
        rb.AddForce(new Vector2 (5 + distnaceX * -move, 5 + distnaceY), ForceMode2D.Impulse);
    }
}
