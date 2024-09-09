using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Collider2D gun;
    void Update()
    {
        if (Input.GetMouseButton(-1))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = new Vector3(gun.bounds.extents.x, 0, 0);
        bullet.SetActive(true);
    }
}
