using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Abeille : Enemi
{
    //todo: bouger vers raycast
    private Rigidbody rb;
    private float _movementspeed;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        PlayerDetector();
    }

    private void FixedUpdate()
    {
        
        MouvementAbeille(mouvement);
    }

    private void MouvementAbeille(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction*_movementspeed*Time.deltaTime));
    }
}
