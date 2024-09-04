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
    [SerializeField] private Collider2D colD;
    [SerializeField] private float speed = 10f, jumpForce = 5f, moveX;
    private bool jump = false;
    private Vector2 movement;
    private Vector3 pos;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anm = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
        colD = this.GetComponent<Collider2D>();
        pos = Camera.position;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            jump = true;
    }
    void FixedUpdate()
    {
        MoveX();
        CameraFollow();
        Jump();
    }
    void CameraFollow()
    {
        Vector3 pos = this.transform.position;
        pos.y = Camera.position.y;
        pos.z = -10;
        Camera.position = pos;
    }
    void MoveX()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y > -4.0f ? rb.velocity.y : -4.0f);
        if (moveX == -1)
            sprite.flipX = true;
        if (moveX == 1)
            sprite.flipX = false;
        anm.SetFloat("Move", Mathf.Abs(moveX));
    }
    void Jump()
    {
        if (Grounded())
        {
            anm.SetFloat("Jump", -1);
            if (jump)
            {
                rb.velocity = new(rb.velocity.x, jumpForce);
            }
            jump = false;
        }
        else
            anm.SetFloat("Jump", 1);
    }
    bool Grounded()
    {
        float rayLength = 0.5f;
        Color rayColor = Color.red;
        Vector2 startPos = (Vector2)this.transform.position - new Vector2(0, colD.bounds.extents.y + 0.05f);
        int layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(startPos, Vector2.down, rayLength, layerMask);
        if (hit.collider != null)
        {
            rayColor = Color.black;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(startPos, Vector2.down * rayLength, rayColor);
        return hit.collider != null;
    }
}
