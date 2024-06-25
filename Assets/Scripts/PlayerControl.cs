using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 6;
    public int jump_height = 5;
    public Animator anm;

    public float h;
    public float w;
    public bool flip = true; //see right
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");//-1, 0, 1
        rb.velocity = new Vector2(speed * h, rb.velocity.y);
        if (rb.velocity.x < 0)
            rb.velocity.Set(0, rb.velocity.y);
        if (flip && h == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            flip = false;
        }
        if (!flip && h == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            flip = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jump_height);
            anm.SetFloat("Jump", 1);
        }
        anm.SetFloat("Move", Mathf.Abs(h));
    }
}
