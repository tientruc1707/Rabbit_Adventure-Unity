using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (this.transform.position.magnitude > 20f)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<EnemyController>().TakeDmg();
            this.gameObject.SetActive(false);
        }
    }
}
