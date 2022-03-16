using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.PlayerLoop;

public class EventManager : MonoBehaviour
{
    public delegate void Action(); 
    public static event Action CanWater;
   //todo: events
   //todo: Tableau de réactivation fleur -> avec eau
   //todo: Detection joueur??


   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.R))
       {
           CanWater?.Invoke();
       }
   }
}
