using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_pole : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    public Transform pullpoint;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public Animator ainm;
    private bool canattak = true;
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
        if(Input.GetButtonDown("Fire1") && pull_push())
        {
         rb.AddForce(new Vector2(rb.velocity.x * 5, 10),ForceMode2D.Impulse);
         ainm.SetFloat("attackcounter", 3.5f);
         src.clip = sfx1;
         src.Play();
         canattak = false;
        }
    }
    bool pull_push()
    {
       return Physics2D.OverlapCircle(pullpoint.position, 0.3f, groundLayer);
    }
    public void pole_atackfinish()
    {
        ainm.SetFloat("attackcounter",0);
        canattak = true;        
    }
}
