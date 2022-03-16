using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //s'il a l'eau il peut revive
    public delegate void WaterGather();

 public static event WaterGather canWater;
    //todo raycast
    private float speed =2f;
    private Rigidbody _rb;
    private float _jump=200f;
    private float _powerJump=5000f;
    private bool _canjump = false;
    private bool _canPowerJump = false;
    private bool _canWater = false;

    private void OnEnable()
    {
        Enemi.youCanRevive += EntityDead;
    } 
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMouvement();
        Jump();
    }

    private void PlayerMouvement()
    {
        //todo: mouvement du joueur
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0f,0f,.01f*speed));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0f,0f,-.01f*speed));
        }
      
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f,-0.2f*speed,0f));
        }
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0,0.2f*speed,0f));
        }
    }

    private void Jump()
    {
        if ((_canjump==true)&&(Input.GetKeyDown(KeyCode.Space)))
        { 
            _canjump = false;
            _rb.AddForce(Vector3.up*_jump);
            _canPowerJump = false;
        }
        if ((_canPowerJump==true)&&(Input.GetKeyDown(KeyCode.Space)))
        {
            _canPowerJump = false;
            _rb.AddForce(Vector3.up*_powerJump);   
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _canjump = true;
            _canPowerJump = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fontaine"))
        {
            _canWater = true;
        }

        if (other.gameObject.CompareTag("Jumper"))
        {
            _canjump = false;
            _canPowerJump = true;
        }
    }

    private void EntityDead()
    {
        if (_canWater==true)
        {
            print("water");
            canWater?.Invoke();
            _canWater = false;
        }
    }
    private void OnDisable()
    {
        Enemi.youCanRevive -= EntityDead;
    }
}