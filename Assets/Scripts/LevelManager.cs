using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{   
    //todo: camera changer
    //todo: collecte eau

    public GameObject[] potager1;
    private bool onDeath;
    private bool _hasFlotte=true;
    public bool playercanwin;
    private int index;
    private static List<Renderer> potager;

    private void OnEnable()
    {
        Player.canWin += FlowerCheck;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (!_hasFlotte)
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

  


    private void FlowerCheck()
    {   
        int fleursouvertes = 0;
        for (int index = 0; index < potager.Count; index++)
        {
            
            if ( potager[index].material.IsKeywordEnabled("_EMISSION"))
            {
                fleursouvertes++;
            }
        }

        if ( fleursouvertes == potager.Count)
        {
            //Time.timeScale = 0;
        }
        
    }

    private void OnDisable()
    {
        Player.canWin -= FlowerCheck;
    }


}
