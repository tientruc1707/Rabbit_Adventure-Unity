using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    void Start()
    {
        buttons = this.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; ++i)
        {
            string levelIndex = (i + 1).ToString();
            buttons[i].onClick.AddListener(() => loadLevel(levelIndex));
        }
    }
    void loadLevel(string level)
    {
        SceneManager.LoadScene("Level " + level);
    }
    private void OnDrawGizmosSelected()
    {
        buttons = this.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; ++i)
        {
            Text level = buttons[i].GetComponentInChildren<Text>();
            level.text = (i + 1).ToString();
            buttons[i].name = "Level " + (i + 1).ToString();
        }
    }
}
