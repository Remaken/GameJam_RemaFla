using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Fleur : Enemi
{
    private void Update()
    {
        PlayerDetector();
        EnemyDies();
        if (_isDead)
        {
           //gameObject.GetComponent<MeshRenderer>().material.GetColor("_Color")= new MeshRenderer().material.SetColor("_Color",Color.red);
        }
    }

}