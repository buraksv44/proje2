using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton, quitButton, settingsButton;

    private void Awake()
    {
        //playButton = transform.GetChild(0).GetComponent<Button>();
        //settingsButton = transform.GetChild(1).GetComponent<Button>();
        //quitButton = transform.GetChild(2).GetComponent<Button>();
    }

    public void NewGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton() 
    {
        Application.Quit();
    }

    public void Settings() 
    {
    
    }
}
