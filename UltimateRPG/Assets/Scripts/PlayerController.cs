﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10f;
    Vector3 deltaPos;
    const float LEFTLIMIT = -9.25f, RIGHTLIMIT = 9.1f;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GlobalScripts").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector3(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime;
        transform.Translate(deltaPos);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LEFTLIMIT, RIGHTLIMIT), transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gameManager.SendMessage("IncrementScore");
    }
}
