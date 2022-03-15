using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.PlayerLoop;

public class EventManager : MonoBehaviour
{
   public static event Action OnRevive;
   public static event Action OnDeath;
   //todo: events
   //todo: Tableau de réactivation fleur -> avec eau


   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {
           OnRevive?.Invoke();
       }
   }


   public static void EnemyDeath()
   {
      OnDeath?.Invoke();
   }
}
