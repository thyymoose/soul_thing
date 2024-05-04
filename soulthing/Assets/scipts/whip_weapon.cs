using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whip_weapon : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    private float attackwindow = 2;
    private bool attaked = false;
    public Transform whip;
    public Animator ainm;
    public LayerMask enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ainm.SetBool("whip1",true);
        }
    
    }
    public void spank()
    {
        var hit = Physics2D.OverlapCircle(whip.position, 3, enemy);
        if(hit != null)
        {
            Debug.Log(hit);
        }
        Debug.Log("suck");
        src.clip = sfx1;
        src.Play();
    }
    public void atackonefinish()
    {
        ainm.SetBool("whip1",false);
    }
}
