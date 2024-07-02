using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadNextLevel : MonoBehaviour
{
    public CircleCollider2D endLv;
    public Collider2D player;

    public int NextLvIs;
    // Start is called before the first frame update
    void Start()
    {
        string lv = SceneManager.GetActiveScene().name;
        NextLvIs = (int)lv[6] - '0' + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (endLv.IsTouching(player))
        {
            SceneManager.LoadScene("Level " + NextLvIs.ToString());
        }
    }
}
