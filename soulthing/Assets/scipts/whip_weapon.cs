using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whip_weapon : WeaponPerent
{
    public Vector2 size;
    private bool canattak = true;
    private int currentattack = 1;
    public Animator ainm;
    public AudioSource src;
    public AudioClip sfx1;
    Coroutine combotime;
    void Update()
    {
        if(!canattak)
        {
            return;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            boxHit(size);
            canattak = false;
            src.clip = sfx1;
            src.Play();
            StopAllCoroutines();
            if(currentattack <=3)
            {
                ainm.SetFloat("attackcounter",currentattack);
            }
            else
            {
                currentattack = 1;
                ainm.SetFloat("attackcounter",currentattack);
            }
            combotime = StartCoroutine(combo());
        }
    }
    IEnumerator combo()
    {
        yield return currentattack = currentattack + 1;
        yield return new WaitForSeconds(.5f);
        canattak = true;
        ainm.SetFloat("attackcounter",0);
        yield return new WaitForSeconds(1f);
        yield return currentattack = 1;
    }
}
