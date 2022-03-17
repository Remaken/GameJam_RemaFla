using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Fleur : Enemi
{
    public GameObject fleur;
    private void Start()
    {
    }

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
           fleur.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.red);
           fleur.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
           _isDead = false;
           _canRevive = true;
        }

    }

    private void FlowerRevive()
    {
        if (_canRevive==true)
        {
            print("fe");
            Revive();
            fleur.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);
            fleur.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            _canRevive = false;
        }
            
    }
    private void OnDisable()
    {
        Player.canWater += FlowerRevive;
    }

}