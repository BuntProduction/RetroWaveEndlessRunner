using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }
   
    public void CharacterGame()
    {
        SceneManager.LoadScene("Character Selection");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
