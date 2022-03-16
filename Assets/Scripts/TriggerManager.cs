using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void Triggered();

    public static event Triggered PlayerOnPlant ;


    private void OnTriggerEnter(Collider other)
    {
        PlayerOnPlant?.Invoke();
    }
}
