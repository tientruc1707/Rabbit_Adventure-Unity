using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D Rigid;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D eCollider, pCollider;
    [SerializeField] private Transform pTransform;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private EnemyDetection enemyDetection;
    private float moveSpeed = 2f, health, maxHealth = 10f;
    private float leftLimit = 30f, rightLimit = 50f;
    private enum ParolState { MovingLeft, MovingRight, Idle }
    private ParolState currentState;


    void Awake()
    {
        Rigid = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        eCollider = this.GetComponent<Collider2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        enemyDetection = this.GetComponentInChildren<EnemyDetection>();
    }
    void Start()
    {
        animator.SetBool("Running", true);
        eCollider.gameObject.tag = "Enemy";
        health = maxHealth;
        currentState = ParolState.MovingLeft;
    }
    void Update()
    {
        switch (currentState)
        {
            case ParolState.MovingLeft:
                MoveLeft();
                break;
            case ParolState.MovingRight:
                MoveRight();
                break;
            case ParolState.Idle:
                Idle();
                break;
        }

    }
    void OnDrawGizmosSelected()
    {
        Rigid = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        eCollider = this.GetComponent<Collider2D>();
        sprite = this.GetComponent<SpriteRenderer>();
    }
    private void EnemyHit()
    {
        
    }
    private void MoveLeft()
    {
        this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (this.transform.position.x <= leftLimit)
        {
            currentState = ParolState.MovingRight;
            sprite.flipX = true;
        }
    }
    private void MoveRight()
    {
        this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (this.transform.position.x >= rightLimit)
        {
            currentState = ParolState.MovingLeft;
            sprite.flipX = false;
        }
    }
    private void Idle()
    {
        animator.SetBool("onRange", false);
    }
    public void TakeDmg()
    {
        this.health -= 10f;
    }
}
