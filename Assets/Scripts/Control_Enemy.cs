using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D EnemyRb;
    private Animator EnemyAnimator;
    private bool onRange = false;
    private float detectRange = 5f;
    private float ESpeed = 2f;

    public Transform Player;

    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        EnemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = Player.position;
        Vector2 e = transform.position;
        float distance = Vector2.Distance(e, p);
        //Khoang cach va kiem tra duong thang
        if (distance <= detectRange && Math.Round(e.y, 4) == Math.Round(p.y, 4))
        {
            onRange = true;
            Vector2 direction = (p - e).normalized;
            EnemyRb.velocity = direction * ESpeed;
            if (p.x < e.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            onRange = false;
            EnemyRb.velocity = Vector2.zero;
        }
        EnemyAnimator.SetBool("OnRange", onRange);
    }
}
