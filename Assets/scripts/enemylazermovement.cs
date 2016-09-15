﻿using UnityEngine;
using System.Collections;

public class enemylazermovement : MonoBehaviour {

    GameObject body2D;
    public float speed = 0.1f;
    float angle;
    Vector3 enemyToPlayer;
    

    // Use this for initialization
    void Start()
    {
        enemyToPlayer = new Vector3(0f, 0f, 0f);
        body2D = GameObject.FindGameObjectWithTag("Player");
        enemyToPlayer = body2D.transform.position - transform.position;
        angle = Mathf.Sqrt((enemyToPlayer.x * enemyToPlayer.x) + (enemyToPlayer.y * enemyToPlayer.y));
        angle = Mathf.Atan2(enemyToPlayer.x, enemyToPlayer.y);
        if (angle < 0)
        {
            angle = Mathf.PI*2 + angle;
        }
        angle = (angle * 360)/(Mathf.PI*2);
        angle = 360 - angle;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    } 

    // Update is called once per frame
    void Update()
    {
        transform.position += enemyToPlayer.normalized * speed;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}