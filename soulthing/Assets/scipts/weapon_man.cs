using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_man : MonoBehaviour
{
    public Behaviour whip;
    public Behaviour lasso;
    public Behaviour pole;
    // Start is called before the first frame update
    void Start()
    {
        whip.enabled = false;
        lasso.enabled = false;
        pole.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("1"))
        {
            whip.enabled = true;
            lasso.enabled = false;
            pole.enabled = false;
            GameObject manger = GameObject.Find("player");
            lasso_weapon lassofuck = manger.GetComponent<lasso_weapon>();
            lassofuck.fuckinpulled();
        }
        if(Input.GetButtonDown("2"))
        {
            lasso.enabled = true;
            whip.enabled = false;
            pole.enabled = false;
        }
        if(Input.GetButtonDown("3"))
        {
            pole.enabled = true;
            whip.enabled = false;
            lasso.enabled = false;
            GameObject manger = GameObject.Find("player");
            lasso_weapon lassofuck = manger.GetComponent<lasso_weapon>();
            lassofuck.fuckinpulled();
        }
        if(Input.GetButtonDown("4"))
        {
            whip.enabled = false;
            lasso.enabled = false;
            pole.enabled = false;
            GameObject manger = GameObject.Find("player");
        lasso_weapon lassofuck = manger.GetComponent<lasso_weapon>();
            lassofuck.fuckinpulled();
        }
    }
}
