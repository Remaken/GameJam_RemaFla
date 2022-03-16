using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
public class Abeille : Enemi
{
    //todo: bouger vers raycast
    private float _detectionDistance= 10f;
    private bool _playerfollow = false;
    public NavMeshAgent abeille;

    private void Start()
    {
        _hitPoints = _hitPoints*2;
    }
    private void Update()
    {
        PlayerDetector();
        MouvementAbeille(_mouvement);
        if (_playerfollow)
        {
            abeille.SetDestination(playerTransform.position);
        }
        EnemyDies();
        if (_isDead==true)
        {
            Destroy(this.gameObject);
        }
    }


    private void MouvementAbeille(Vector3 direction)
    {

        RaycastHit hit;
        Vector3 detect = Vector3.Normalize(playerTransform.position - this.gameObject.transform.position);
        if (Physics.Raycast(this.gameObject.transform.position, direction, out hit, _detectionDistance))
        {
            _playerfollow = true;
        }
    }



    
    /*Vector3 targetposition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            this.gameObject.transform.LookAt(targetposition);
            rb.MovePosition(transform.forward + targetposition);
            (mouvement * _movementspeed * Time.fixedDeltaTime)*/
}
