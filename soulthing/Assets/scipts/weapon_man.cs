using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_man : MonoBehaviour
{
    public Behaviour whip;
    public Behaviour lasso;
    public Behaviour pole;
    public Behaviour sword;
    // Start is called before the first frame update
    void Start()
    {
        whip.enabled = false;
        lasso.enabled = false;
        pole.enabled = false;
        sword.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("1"))
        {
            Debug.Log("WHIP");
            sword.enabled = false;
            whip.enabled = true;
            lasso.enabled = false;
            pole.enabled = false;
            GameObject manger = GameObject.Find("player");
            lasso_weapon lassofuck = manger.GetComponent<lasso_weapon>();
            lassofuck.fuckinpulled();
        }
        if(Input.GetButtonDown("2"))
        {
            Debug.Log("LASSO");
            sword.enabled = false;
            lasso.enabled = true;
            whip.enabled = false;
            pole.enabled = false;
        }
        if(Input.GetButtonDown("3"))
        {
            Debug.Log("SWORD");
            sword.enabled = true;
            pole.enabled = false;
            whip.enabled = false;
            lasso.enabled = false;
            GameObject manger = GameObject.Find("player");
            lasso_weapon lassofuck = manger.GetComponent<lasso_weapon>();
            lassofuck.fuckinpulled();
        }
        if(Input.GetButtonDown("4"))
        {
            Debug.Log("POLE");
            sword.enabled = false;
            whip.enabled = false;
            lasso.enabled = false;
            pole.enabled = true;
            GameObject manger = GameObject.Find("player");
        lasso_weapon lassofuck = manger.GetComponent<lasso_weapon>();
            lassofuck.fuckinpulled();
        }
    }
}
