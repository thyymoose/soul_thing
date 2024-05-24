using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_weapon : MonoBehaviour
{
    public float poer;
    float Maxpoer = 10;
    bool held;
    float chargesped = 5;
    float ataktimer;
    public float startataktimer;
    public Transform atakpos;
    public float atakrang;
    public LayerMask enemy;
    public Animator anim; 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(held && poer <= Maxpoer)
        {
            poer += Time.deltaTime * chargesped;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            held = true;

        }

        if (Input.GetButtonUp("Fire1"))
        {
            held = false;
            anim.SetFloat("attackcounter", 5);
            
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atakpos.position, atakrang);
    }

    void ragg()
    {
        Collider2D[] enemies2dam = Physics2D.OverlapCircleAll(atakpos.position, atakrang, enemy);
        for (int i = 0; i < enemies2dam.Length; i++)
        {
            enemies2dam[i].GetComponent<Ememy>().TakeDamage(poer);
        }
    }

    void asf()
    {
        anim.SetFloat("attackcounter", 0);
        poer = 5;
    }
    
}
