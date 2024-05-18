using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasso_weapon : MonoBehaviour
{
    public GameObject lasso;
    public Transform firepoint;
    public bool lassoOut = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lassoOut)
        {
            return;
        }
         if(Input.GetButtonDown("Fire1"))
        {
           Instantiate(lasso, firepoint.position, firepoint.rotation);
           lassoOut = true;
        }
        
    }
    

}
