using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_weapon : MonoBehaviour
{
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
        if(Input.GetButtonDown("Fire1"))
        {
            
        }
    }
}
