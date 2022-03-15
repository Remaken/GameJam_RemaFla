using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 
    //todo raycast
    private new float speed =4f;
    private void Update()
    {
        PlayerMouvement();
    }


   

    private void PlayerMouvement()
    {
        //todo: mouvement du joueur
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0f,0f,.01f*speed));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0f,0f,-.01f*speed));
        }
      
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f,-0.2f*speed,0f));
        }
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0,0.2f*speed,0f));
        }
    }
}