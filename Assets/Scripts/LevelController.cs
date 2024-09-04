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
            string levelNum = (i + 1).ToString();
            buttons[i].onClick.AddListener(() => loadLevel(levelNum));
        }
    }
    void loadLevel(string levelNum)
    {
        SceneManager.LoadScene("Level " + levelNum);
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
