using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public GameObject _smallCircle;
    GameObject _gameManager;
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CreateSmallCircle();
        }
    }

    void CreateSmallCircle()
    {
        Instantiate(_smallCircle, transform.position, transform.rotation);
        _gameManager.GetComponent<GameManager>().ShowTextOnSmallCircle();
    }
}
