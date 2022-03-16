using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Fleur : Enemi
{
    private bool _canRevive = false;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_canRevive==true)
            {
                Revive();
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);
                gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                _canRevive = false;
            }
            
        }
        
    }

}