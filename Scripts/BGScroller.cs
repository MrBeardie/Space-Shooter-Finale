﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        
        if (GameObject.Find("GameController").GetComponent<GameController>().score >= 100)
        {
            scrollSpeed = -4;
            if (GameObject.Find("GameController").GetComponent<GameController>().score >= 150)
            {
                scrollSpeed = -8;
                if (GameObject.Find("GameController").GetComponent<GameController>().score >= 200)
                {
                    scrollSpeed = -12;
                }
                
            }
        }



    }
}