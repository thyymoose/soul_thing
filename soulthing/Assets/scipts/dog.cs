using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : enemyAIperent
{
    private float time;

    void Update()
    {
        if(gettinghit)
        {
            return;
        }
        if(playerclose()>attackrange && canhit)
        {
            state = currentstate.walking;
            switchstate();
        }
        if(playerclose()<=attackrange && canhit)
        {
            state = currentstate.attacking;
            switchstate();
        }
        if(!canhit)
        {
            state = currentstate.retreating;
            switchstate();
        }
        if(playerclose()> attackrange * 2)
        {
            canhit = true;
        }
        
    }
    public void hitstop()
    {
        state = currentstate.hitstop;
        switchstate();
        gettinghit = true;

    }
    
}
