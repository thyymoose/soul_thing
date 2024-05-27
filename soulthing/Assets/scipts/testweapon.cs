using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testweapon : WeaponPerent
{
    public Vector2 size;
    private bool canattak = true;
    private int currentattack = 1;
    public Animator ainm;
    public AudioSource src;
    public AudioClip sfx1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canattak)
        {
            return;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            boxHit(size);
            ainm.SetFloat("attackcounter",currentattack);
            canattak = false;
        }
    }
}
