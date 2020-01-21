using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    protected float moveSpeed = 2f;
    //protected float rotSpeed = 45f;
    protected float boostCooldown;
    protected float boostTime;
    protected float shotCooldown;
    protected float spinCooldown;

    public GameObject cannon;
    public GameObject missile;
    public GameObject atkIcon;
    public GameObject bstIcon;

    public KeyCode forward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode boost;
    public KeyCode fire;

    void Start() {
        boostCooldown = 0f;
        boostTime = 0f;
        shotCooldown = 0f;
        spinCooldown = 0f;

        atkIcon.SetActive(true);
        bstIcon.SetActive(true);
    }

        void Update()
    {     
        boostCooldown -= Time.deltaTime;
        boostTime -= Time.deltaTime;
        shotCooldown -= Time.deltaTime;
        spinCooldown -= Time.deltaTime;

        if(boostTime > 0){
            moveSpeed = 8f;
        }
        else {
            moveSpeed = 2f;
        }

        if(spinCooldown > 0)
        {
            this.transform.eulerAngles += Vector3.forward * 45f;
        }

        
        if(Input.GetKey(forward))
        {
            MoveForward();
        }

        if(Input.GetKeyDown(left)) {
            TurnLeft();
        }

        if(Input.GetKeyDown(right)) {
            TurnRight();
        }

        if(Input.GetKeyDown(boost) && boostCooldown <= 0) {
            Boost();
        }

        if(Input.GetKeyDown(fire) && shotCooldown <= 0){
            Fire();
        }

        if(boostCooldown <= 0)
            bstIcon.SetActive(true);

        if(shotCooldown <= 0)
            atkIcon.SetActive(true);
        
    }

    public void TakeHit() {
        spinCooldown = 1f;
    }

    protected void MoveForward() {
        if(spinCooldown <= 0)
            this.transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    protected void TurnLeft() {
        if(spinCooldown <= 0)
            this.transform.eulerAngles += Vector3.forward * 45;
    }

    protected void TurnRight() {
        if(spinCooldown <= 0)
            this.transform.eulerAngles -= Vector3.forward * 45;
    }

    protected void Boost() {
        if(spinCooldown <= 0 && boostCooldown <= 0) {
            boostTime = 1f;
            boostCooldown = 5f;
            bstIcon.SetActive(false);  
        }
        
    }

    protected void Fire() {
        if(spinCooldown <= 0 && shotCooldown <= 0) {
            Instantiate(missile, cannon.transform.position, cannon.transform.rotation);
            shotCooldown = 5f;
            atkIcon.SetActive(false);
        }       
    }
}
