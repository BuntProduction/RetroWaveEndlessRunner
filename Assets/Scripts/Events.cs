using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void CharacterGame()
    {
        SceneManager.LoadScene("Character Selection");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Rate()
    {
    	Application.OpenURL ("market://details?id=com.BuntProduction.RetroWaveRun");
    }
}
