using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Fleur : Enemi
{
    

    private void OnEnable()
    {
        Player.canWater += FlowerRevive;
    } 

    private void Update()
    {
        PlayerDetector();
        EnemyDies();
        if (_isDead==true)
        {
           gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.red);
           gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
           _isDead = false;
           _canRevive = true;
        }

    }

    private void FlowerRevive()
    {
        if (_canRevive==true)
        {
            Revive();
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            _canRevive = false;
        }
            
    }
    private void OnDisable()
    {
        Player.canWater += FlowerRevive;
    }

}