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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    
    public void LoadGame() 
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

    public static void set_Turret_Saves_for_First_Time()
    {
        if (!PlayerPrefs.HasKey("Turret_1_Amount"))
        {
            PlayerPrefs.SetInt("Turret_1_Amount", 0);
        }
        if (!PlayerPrefs.HasKey("Turret_2_Amount"))
        {
            PlayerPrefs.SetInt("Turret_2_Amount", 0);
        }
        if (!PlayerPrefs.HasKey("Turret_3_Amount"))
        {
            PlayerPrefs.SetInt("Turret_3_Amount", 0);
        }
        if (!PlayerPrefs.HasKey("Turret_4_Amount"))
        {
            PlayerPrefs.SetInt("Turret_4_Amount", 0);
        }
    }

    public static void change_Turret_Amount(int turret_type, int change_amount)
    {
        string name = "Turret_" + turret_type + "_Amount";
        int old = PlayerPrefs.GetInt(name);
        old += change_amount;

        PlayerPrefs.SetInt(name, old);
    }

    public static int get_Turret_Amount(int turret_type)
    {
        string name = "Turret_" + turret_type + "_Amount";
        return PlayerPrefs.GetInt(name);
    }
}
