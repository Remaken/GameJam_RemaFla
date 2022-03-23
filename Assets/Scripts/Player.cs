using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Player : MonoBehaviour
{
    //s'il a l'eau il peut revive
    public delegate void PlayerWin();
    public static event PlayerWin canWin;
    public static event PlayerWin playerDied;
    public static event PlayerWin canWater;
    
    
    [SerializeField] private float speed =8f;
    [SerializeField] private float _jump=5f;
    [SerializeField] private float _powerJump=12f;
    private Rigidbody _rb;
    private bool _canjump = false;
    private bool _canPowerJump = false;
    private bool _canWater = false;
    public MeshRenderer bucket;
    private int life = 2;

    private void OnEnable()
    {
        Enemi.youCanRevive += EntityDead;
        Abeille.uneAbeilleMorte += DecesJoueur;
    } 
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMouvement();
    }

    private void Update()
    {
        Jump();
    }

    private void PlayerMouvement()
    {
        //todo: mouvement du joueur
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0f,0f,speed*Time.fixedDeltaTime));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0f,0f,-speed*Time.fixedDeltaTime));
        }
      
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f,-10*speed*Time.fixedDeltaTime,0f));
        }
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0,10*speed*Time.fixedDeltaTime,0f));
        }
    }

    private void Jump()
    {
        if ((_canPowerJump==true)&&(Input.GetKeyDown(KeyCode.Space)))
        {
            _canPowerJump = false;
            _rb.AddForce(Vector3.up * _powerJump, ForceMode.Impulse);
        }
        if ((_canjump==true)&&(Input.GetKeyDown(KeyCode.Space)))
        { 
            _canjump = false;
            _canPowerJump = false;
            _rb.AddForce(Vector3.up*_jump, ForceMode.Impulse);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //_canPowerJump = true;
            _canjump = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fontaine"))
        {
            _canWater = true;
            bucket.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }

        if (other.gameObject.CompareTag("Jumper"))
        {
            _canjump = false;
            _canPowerJump = true;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            canWin?.Invoke();
        }
    }

    private void EntityDead()
    {
        if (_canWater==true)
        {
            canWater?.Invoke();
            _canWater = false;
            bucket.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
    }
    private void DecesJoueur()
    {
        life--;
        if (life<=0)
        {
            Destroy(gameObject);
            playerDied?.Invoke();
        }
    }

    private void OnDisable()
    {
        Enemi.youCanRevive -= EntityDead;
        Abeille.uneAbeilleMorte -= DecesJoueur;
    }


}