using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    private Vector3 offset;

    private void Start()
    {
        offset = camera.transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        if (player!=null)
        {
            camera.transform.position = player.transform.position + offset;
        }
    }
}
