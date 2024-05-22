using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private float horizontal;
    public Rigidbody2D rb;
    public Transform firepoint;
    public Transform GUN;
    public GameObject bulletPrefab;
    Vector2 direction;
    public float Ammo = 10f;
    private bool isFacingRight = true;
    private float rotationZ;
    player_movement myPlayer;
    public GameObject player;
    public Rigidbody2D playerrb;

 

    private void FixedUpdate()
    {
 
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
    if (isFacingRight)
    {
         rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   
    }
    else
    {
        rotationZ = Mathf.Atan2(-difference.y, -difference.x) * Mathf.Rad2Deg;
    }
        if (rotationZ > -90 && rotationZ < 90)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = myPlayer.GetComponent<player_movement>(); 

    }

    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if (Input.GetButtonDown("Fire2"))
        {
            if (Ammo < 0)
            {

            }
            if (Ammo > 0)
            {
                Shoot();
                Ammo = Ammo - 1;
            }          

        }

        
    }

    void Shoot ()
    {
        //shooting
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        
        playerrb.AddForce(new Vector2(500*Mathf.Sin(rotationZ), 500*Mathf.Cos(rotationZ)));
        
    }

    void FaceMouse()
    {
        GUN.transform.right = direction;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
}

    