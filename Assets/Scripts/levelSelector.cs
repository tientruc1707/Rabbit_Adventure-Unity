using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSelector : MonoBehaviour
{
    public int level;
    public Text levelText;
    void Start()
    {
        levelText.text = level.ToString();
    }
    public void loadLevel()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
