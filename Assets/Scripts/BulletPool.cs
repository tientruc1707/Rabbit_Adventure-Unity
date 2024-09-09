using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }
    public GameObject bulletPrefap;
    public int poolSize = 30;
    private List<GameObject> bulletPool;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //init pool
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; ++i)
        {
            GameObject bullet = Instantiate(bulletPrefap);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        GameObject newbullet = Instantiate(bulletPrefap);
        newbullet.SetActive(false);
        bulletPool.Add(newbullet);
        return newbullet;
    }
}
