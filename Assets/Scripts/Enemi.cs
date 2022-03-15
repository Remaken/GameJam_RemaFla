using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemi : MonoBehaviour
{
    private float _hitPoints = 10;
    public float _detectionDistance=2f;
    public Transform playerTransform;
    protected Vector3 mouvement;


    //Todo: raycast detecte joueur

    private void Update()
    {
    }

    protected void PlayerDetector()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(playerTransform.position - this.gameObject.transform.position);
        mouvement = direction;
        if ( Physics.Raycast(this.gameObject.transform.position,direction, out hit,_detectionDistance ))
        {
            _hitPoints -= 1 * Time.deltaTime;
            Debug.Log(_hitPoints);
        }
    }
}
