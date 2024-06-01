using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPerent : MonoBehaviour
{
    public float damage = 0;
    public LayerMask layer;
    public Transform pos;
    public void boxHit(Vector2 size)
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(pos.position,size,0,layer);
        for (int i = 0; i < hit.Length; i++)
        {
            hit[i].GetComponent<Ememy>().TakeDamage(damage);
            hit[i].GetComponent<dog>().hitstop(); 
        }
    }
    public void sphereHit(float size)
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(pos.position,size,0,layer);
        for (int i = 0; i < hit.Length; i++)
        {
            hit[i].GetComponent<Ememy>().TakeDamage(damage);
            hit[i].GetComponent<dog>().hitstop();
        } 
    }
    public void knockback(Vector2 size)
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(pos.position,size,0,layer);
        for (int i = 0; i < hit.Length; i++)
        {

        }
    }
}
