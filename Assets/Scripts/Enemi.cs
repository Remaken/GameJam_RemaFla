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
    protected Vector3 _mouvement;
    protected bool _isDead=false;
    protected float _hPReset;


    //Todo: raycast detecte joueur
   //estmorte et detecte joueur
   public delegate void ImDead();
   public static event ImDead youCanRevive ;

    private void Start()
    {
        _hPReset = _hitPoints;
    }

    protected void PlayerDetector()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(playerTransform.position - this.gameObject.transform.position);
        _mouvement = direction;
        if ( Physics.Raycast(this.gameObject.transform.position,direction, out hit,_dyingDistance ))
        {
            if (_hitPoints>0)
            {
                _hitPoints -= 1 * Time.deltaTime;
            }

            else if (_isDead==true)
            {
                print("je susi mort");
                youCanRevive?.Invoke();
            }
            // Debug.Log(_hitPoints);
        }
    }

    protected void EnemyDies()
    {
        if (_hitPoints<=0)
        {
            _hitPoints = 0;
            _isDead = true;
        }
    }
  
    protected void Revive()
    {
            _hitPoints = _hPReset;
            _isDead=false;
    }


}
