using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    //todo: camera changer
    //todo: collecte eau

    public GameObject[] potager1;
    private bool onDeath;
    private int index;
    private bool hasFlotte;
    
    

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (!hasFlotte)
            {
                FlowerRespawn();
            }
        }
    }


    /*
     Passer d'un niveau à l'autre 
     Abeille supérieure
     
     */

    private void FlowerRespawn()
    {
        for (int index = 0; index < potager1.Length; index++)
        { 
            potager1[index].gameObject.SetActive(true); 
        }
    }







}
