using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<int> currentTurretsTypes;
    GameObject gunSlots;
    Button toShop;
    Button toCombat;
    int counter;
    
    private void Awake()
    {
        MainMenu.set_Turret_Saves_for_First_Time();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (currentTurretsTypes.Count <= 0)
        {
            for (int i = 0; i < 6; i++)
            {
                currentTurretsTypes.Add(0);
            }
        }
    }

    
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && toCombat == null)
        {
            toCombat = GameObject.FindGameObjectWithTag("toCombat").GetComponent<Button>();
            toCombat.onClick.AddListener(() => { LoadScene(2); });

            for (int i = 0; i < currentTurretsTypes.Count; i++)
            {
                currentTurretsTypes[i] = PlayerPrefs.GetInt($"slot{i + 1}");
            }
            StartCoroutine("SetTypes");
        }
        else return;
    }

    public void LoadScene(int sceneIndex)
    {
        GetTypes();
        if (counter == currentTurretsTypes.Count) 
        {
            SceneManager.LoadScene(sceneIndex);
            StartCoroutine("SetTypes");
        }
    }
    public void GetTypes()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            gunSlots = GameObject.FindGameObjectWithTag("guns");
            
            counter = 0;
            for (int i = 0; i < gunSlots.transform.childCount; i++)
            {
                PlayerPrefs.SetInt($"slot{i + 1}", gunSlots.transform.GetChild(i).GetComponent<ActivateTurrets>().currentTurret.type);
                counter++;
            }
        }

    }
    IEnumerator SetTypes()
    {
        yield return new WaitForSeconds(0.05f);

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            gunSlots = GameObject.FindGameObjectWithTag("guns");
            for (int i = 0; i < currentTurretsTypes.Count; i++)
                {
                    gunSlots.transform.GetChild(i).GetComponent<ActivateTurrets>().currentTurret.type = PlayerPrefs.GetInt($"slot{i + 1}");
                }
        }

        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            toShop = GameObject.FindGameObjectWithTag("toShop").GetComponent<Button>();
            toShop.onClick.AddListener(() => { LoadScene(1); });
        }
    }
    
    private void OnApplicationQuit()
    {
        gunSlots = GameObject.FindGameObjectWithTag("guns");
        
        for (int i = 0; i < gunSlots.transform.childCount; i++)
        {
            PlayerPrefs.SetInt($"slot{i + 1}", gunSlots.transform.GetChild(i).GetComponent<ActivateTurrets>().currentTurret.type);
        }
    }
}
