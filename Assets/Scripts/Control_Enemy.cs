using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D eRigid;
    [SerializeField] private Animator eAnm;
    [SerializeField] private Collider2D eCollider;
    [SerializeField] private Transform pTransform;
    [SerializeField] private Collider2D pCollider;
    [SerializeField] private SpriteRenderer eSprite;
    private bool _onRange = false;
    private float _detectRange = 5f;
    private float _eSpeed = 2f;
    private GameObject Eobject;

    void Start()
    {
        eRigid = this.GetComponent<Rigidbody2D>();
        eAnm = this.GetComponent<Animator>();
        eCollider = this.GetComponent<Collider2D>();
        eSprite = this.GetComponent<SpriteRenderer>();
        eCollider.gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = pTransform.position;
        Vector2 e = transform.position;
        float distance = Vector2.Distance(e, p);
        if (distance <= _detectRange && Math.Round(e.y, 4) == Math.Round(p.y, 4))
        {
            _onRange = true;
            Vector2 direction = (p - e).normalized;
            eRigid.velocity = direction * _eSpeed;
            if (p.x < e.x)
            {
                eSprite.flipX = false;
            }
            else
            {
                eSprite.flipX = true;
            }
        }
        else
        {
            _onRange = false;
            eRigid.velocity = Vector2.zero;
        }
        eAnm.SetBool("OnRange", _onRange);
    }
}
