using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garage : MonoBehaviour
{
    public Text amount;
    public Button satinAl, kullan, kaldir;
    public GameObject turret1, turret2, turret3, turret4;
    int turret1Amount, turret2Amount, turret3Amount, turret4Amount;
    internal int value;


    void Start()
    {
        turret1Amount = 0;
    }



    void Update()
    {
        TurretCheck();

    }

   public void SatinAl()
    {
        turret1Amount++;



        if (turret1Amount > 0)
        {
            kullan.enabled = true;
        }

    }

   public void Kullan()
    {
        turret1.SetActive(true);
        turret1Amount--;

    }

   public void Kaldir()
    {
        turret1.SetActive(false);
        if (turret1Amount <= 0)
        { 
            kullan.enabled = false; 
        }
        turret1Amount++;
    }





    void TurretCheck()
    {

        if (turret1.activeInHierarchy)
        {
            value = 1;
        }
        else if (turret2.activeInHierarchy)
        {
            value = 2;
        }
        else if (turret3.activeInHierarchy)
        {
            value = 3;

        }
        else if (turret4.activeInHierarchy)
        {
            value = 4;
        }



    }


}
