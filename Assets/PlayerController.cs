﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float bulletSpeed;

    Rigidbody2D rb;
    AudioSource au;

    public float fireRate;
    float timer;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v).normalized;

        rb.velocity = dir * moveSpeed;

        //软件限制位移，与物体限制相比不会出现抖动
        /*Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -28f, 28f);
        pos.y = Mathf.Clamp(pos.y, -14f, 14f);
        transform.position = pos;*/

        //Fire
        timer += Time.deltaTime;
        if(timer > fireRate && Input.GetKey(KeyCode.Mouse0))
        {
            timer = 0;
            Fire();
        }
    }

    void Fire()
    {
        au.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
        Destroy(bullet, 10f);
    }
}
