using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anm;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Transform Camera;
    [SerializeField] private float _speed = 5, _jumpForce = 250, moveX;
    private bool _isGround;
    private Vector2 movement;
    private Vector3 pos;


    // void Start()
    // {
    //     rb = this.GetComponent<Rigidbody2D>();
    //     anm = this.GetComponent<Animator>();
    //     sprite = this.GetComponent<SpriteRenderer>();
    //     pos = Camera.position;
    // }
    void OnDrawGizmos()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anm = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
        pos = Camera.position;
    }
    // Update is called once per frame
    void Update()
    {
        _moveX();
        _Jump();
    }
    private void FixedUpdate()
    {
        rb.velocity = movement;
        pos = this.transform.position;
        pos.z = -10;
        pos.y = Camera.position.y;
        Camera.position = pos;
    }
    void _moveX()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        movement.x = moveX * _speed;
        movement.y = rb.velocity.y;
        if (moveX == -1)
            sprite.flipX = true;
        if (moveX == 1)
            sprite.flipX = false;
        anm.SetFloat("Move", Mathf.Abs(moveX));
    }
    void _Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _isGround)
        {
            rb.AddForce(new(0, _jumpForce));
        }
        if (!_isGround)
        {
            anm.SetFloat("Jump", 1);
        }
        else
        {
            anm.SetFloat("Jump", -1);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        _isGround = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        _isGround = false;
    }
}
