using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Hero hs;
    private Vector3 pathToHero;
    [SerializeField] private float speed = 1;
    

    private void Awake()
    {
        hs = GameObject.Find("Hero").GetComponent<Hero>();
    }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, hs.transform.position, Time.deltaTime * speed);
    }
}
