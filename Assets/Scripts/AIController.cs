using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public GameObject target;

    void Update()
    {        
        if(target == null || target.gameObject.tag == "Dead")
        {
            target = GameObject.FindGameObjectWithTag("Enemy");
        }

        if(target != null)
            

        if(spinCooldown > 0)
        {
            TakeHit();
        }

        if(spinCooldown <= 0)
        {
            MoveForward();
        }

        //if(boostCooldown <= 0)
        //{
        //    Boost();
        //}
    }

    public void LeftTurn() 
    {
        TurnLeft();
    }

    public void RightTurn() 
    {
        TurnRight();
    }
}
