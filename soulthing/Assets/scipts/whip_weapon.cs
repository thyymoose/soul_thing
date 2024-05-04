using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whip_weapon : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    private bool canattak = true;
    private string currentattack = "whip1";
    public Transform whip;
    public Animator ainm;
    public LayerMask enemy;
    public Vector3 fakepow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canattak)
        return;
        if(Input.GetButtonDown("Fire1"))
        {
            ainm.SetBool("whip1",true);
            canattak = false;
        }

    
    }
    public void hit1()
    {
        var hit =Physics2D.OverlapBox(whip.position,new Vector2(3,0.5f),0,enemy);
            if(hit != null)
            {
                Debug.Log(hit);
            }
        src.clip = sfx1;
        src.Play();
        currentattack = "whip1";
    }
    public void atackfinish()
    {
        ainm.SetBool(currentattack,false);
        canattak = true;
    }
    public void OnDrawGizmos()
    {
    Gizmos.DrawCube(whip.position, fakepow);

    }
}
