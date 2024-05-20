using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasso_weapon : MonoBehaviour
{
    public GameObject lasso;
    public Transform firepoint;
    public bool lassoOut = false;
    public bool lassoOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && lassoOut == false)
        {
           Instantiate(lasso, firepoint.position, firepoint.rotation);
           lassoOut = true;
        }
        if(Input.GetButtonDown("Fire1") && lassoOn)
        {
            GameObject lasso = GameObject.FindGameObjectWithTag("lasso");
            lasso_project l = lasso.GetComponent<lasso_project>();
            lassoOn = false;
            l.canlasso = false;
            l.pull();
            
        }        
    }
    public void fuckinpulled()
    {
        GameObject lasso = GameObject.FindGameObjectWithTag("lasso");
        lasso_project l = lasso.GetComponent<lasso_project>();
        lassoOn = false;
        l.canlasso = false;
        l.pull();
    }
    

}
