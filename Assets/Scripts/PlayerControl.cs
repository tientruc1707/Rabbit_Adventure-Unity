using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 6;
    public int jump_height = 2;
    public Animator anm;
    public float gravityScale = 7;
    public float fallGravityScale = 10;
    public float h;
    public float w;
    bool jumping;
    float pressedButtonTime;
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
        float buttonPressWindow = 1;
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.gravityScale = gravityScale;
            float jumpForce = Mathf.Sqrt(jump_height * (Physics2D.gravity.y * gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
            pressedButtonTime = 0;

        }
        if (jumping)
        {
            pressedButtonTime += Time.deltaTime;
            if (pressedButtonTime < buttonPressWindow && Input.GetKeyUp(KeyCode.Space))
            {
                rb.gravityScale = fallGravityScale;
            }
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = fallGravityScale;
                jumping = false;
            }
        }
        anm.SetFloat("Jump", Mathf.Abs(w));
        anm.SetFloat("Move", Mathf.Abs(h));
    }
}
