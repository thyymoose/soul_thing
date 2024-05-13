using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whip_weapon : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    private bool canattak = true;
    private int currentattack = 1;
    public Transform whip;
    public Animator ainm;
    public LayerMask enemy;
    Coroutine combotime;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(currentattack);
        if(!canattak)
        {
            return;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            ainm.SetFloat("attackcounter",currentattack);
            canattak = false;
        }
    }
    public void hit1()
    {
        var hit =Physics2D.OverlapBox(whip.position,new Vector2(3,0.5f),0,enemy);
            if(hit != null)
            {
                Ememy ememy = hit.GetComponent<Ememy>();
                ememy.TakeDamage(10);
                Debug.Log(hit);
            }
        src.clip = sfx1;
        src.Play();
       combotime = StartCoroutine(combo());
    }
    public void hit2()
    {
        var hit =Physics2D.OverlapBox(whip.position,new Vector2(3,0.5f),0,enemy);
            if(hit != null)
            {
                Ememy ememy = hit.GetComponent<Ememy>();
                ememy.TakeDamage(0);
                Debug.Log(hit);
            }
        src.clip = sfx1;
        src.Play();
        StopAllCoroutines();
        combotime = StartCoroutine(combo());
    }
    public void hit3()
    {
        var hit =Physics2D.OverlapBox(whip.position,new Vector2(3,0.5f),0,enemy);
            if(hit != null)
            {
                Ememy ememy = hit.GetComponent<Ememy>();
                ememy.TakeDamage(100);
                Debug.Log(hit);
            }
        src.clip = sfx1;
        src.Play();
        StopAllCoroutines(); 
        combotime = StartCoroutine(combo());
        currentattack = 1;
    }
    public void atackfinish()
    {
        ainm.SetFloat("attackcounter",0);
        canattak = true;        
    }
   IEnumerator combo()
   {
     yield return currentattack = currentattack + 1;
     yield return new WaitForSeconds(1.5f);
     yield return currentattack = 1;
   }


    
}
