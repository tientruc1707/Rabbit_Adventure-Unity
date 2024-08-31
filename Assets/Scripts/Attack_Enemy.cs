using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 center = collision.collider.bounds.center;

            if (contactPoint.y > center.y)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                GetComponent<healthBar>().HpValue -= 10;
            }
        }
    }

}
