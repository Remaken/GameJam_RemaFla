using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{   
    //todo: camera changer
    //todo: collecte eau

    private bool onDeath;
    public bool playercanwin;
    private static List<Renderer> potager;
    public Button restart;

    private void OnEnable()
    {
        Player.canWin += FlowerCheck;
        Player.playerDied += ButtonActivate;
    }
    /*
     Passer d'un niveau à l'autre 
     Abeille supérieure
     
     */

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
            playercanwin = true;
            Time.timeScale = 0;
        }
        
    }

    private void ButtonActivate()
    {
        restart.gameObject.SetActive(true);
    }  
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    private void OnDisable()
    {
        Player.canWin -= FlowerCheck;
        Player.playerDied -= ButtonActivate;
    }

   


}
