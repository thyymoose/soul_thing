using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_man : MonoBehaviour
{
    public Behaviour whip;
    public Behaviour lasso;
    // Start is called before the first frame update
    void Start()
    {
        whip.enabled = false;
        lasso.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("1"))
        {
            whip.enabled = true;
            lasso.enabled = false;
        }
        if(Input.GetButtonDown("2"))
        {
            lasso.enabled = true;
            whip.enabled = false;
        }
        if(Input.GetButtonDown("3"))
        {
            whip.enabled = false;
            lasso.enabled = false;
        }
        if(Input.GetButtonDown("4"))
        {
            whip.enabled = false;
            lasso.enabled = false;
        }
    }
}
