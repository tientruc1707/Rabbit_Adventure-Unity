using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadNextLevel : MonoBehaviour
{
    [SerializeField] private int NextLvIs;
    // Start is called before the first frame update
    void Start()
    {
        string ThisLv = SceneManager.GetActiveScene().name;
        NextLvIs = (int)ThisLv[6] - '0' + 1;
    }
    void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene("Level " + NextLvIs.ToString());
    }
}
