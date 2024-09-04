
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void Play()
    {
        SceneManager.LoadScene("Select Level");
    }
    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
