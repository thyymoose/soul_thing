using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform firepoint;
    public Transform GUN;
    public GameObject bulletPrefab;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos -  (Vector2)GUN.position;
        FaceMouse();

        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();

        }

        
    }

    void Shoot ()
    {
        //shooting
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

    void FaceMouse()
    {
        GUN.transform.right = direction;
    }
}

    