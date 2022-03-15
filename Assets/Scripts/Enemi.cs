using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Enemi : MonoBehaviour
{
    protected float _hitPoints = 5;
    private float _dyingDistance=2f;
    public Transform playerTransform;
    protected Vector3 mouvement;
    protected bool _isDead=false;
    private float _hPReset;


    //Todo: raycast detecte joueur
    private void OnEnable()
    {
        EventManager.OnRevive += Revive;
    }

    private void Start()
    {
        _hPReset = _hitPoints;
    }

    protected void PlayerDetector()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(playerTransform.position - this.gameObject.transform.position);
        mouvement = direction;
        if ( Physics.Raycast(this.gameObject.transform.position,direction, out hit,_dyingDistance ))
        {
            if (_hitPoints>0)
            {
                _hitPoints -= 1 * Time.deltaTime;
            }
            // Debug.Log(_hitPoints);
        }
    }

    protected void EnemyDies()
    {
        if (_hitPoints<=0)
        {
            gameObject.SetActive(false);
            _hitPoints = 0;
            _isDead = true;
        }
    }
  
    private void Revive()
    {
        if (_isDead)
        {
            _hitPoints = _hPReset;
            _isDead=false;
            gameObject.SetActive(true);
        }

    }

    private void OnDisable()
    {
        EventManager.OnRevive -= Revive;
    }
}
