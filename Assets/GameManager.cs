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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && toCombat == null)
        {
            toCombat = GameObject.FindGameObjectWithTag("toCombat").GetComponent<Button>();
            toCombat.onClick.AddListener(() => { LoadScene(2); });
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
        currentTurretsTypes.Clear();
        gunSlots = GameObject.FindGameObjectWithTag("guns");
        counter = 0;
        for (int i = 0; i < gunSlots.transform.childCount; i++)
        {
            currentTurretsTypes.Add(gunSlots.transform.GetChild(i).GetComponent<ActivateTurrets>().currentTurret.type);
            counter++;
        }
    }
    IEnumerator SetTypes()
    {
        yield return new WaitForSeconds(0.05f);

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            toShop = GameObject.FindGameObjectWithTag("toShop").GetComponent<Button>();
            toShop.onClick.AddListener(() => { LoadScene(1); });
        }

        gunSlots = GameObject.FindGameObjectWithTag("guns");
        for (int i = 0; i < gunSlots.transform.childCount; i++)
        {
            gunSlots.transform.GetChild(i).GetComponent<ActivateTurrets>().currentTurret.type = currentTurretsTypes[i];
        }
    }
}
