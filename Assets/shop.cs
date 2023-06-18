using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    Slot slot;
    public Button button;
    PlayerPrefs playerPrefs;
    
   internal int amount1 =0, amount2=0, amount3 = 0, amount4 = 0;
    TMPro.TextMeshPro text1, text2, text3, text4;
    bool check;
    public int type;



    private void Start()
    {
        slot = FindObjectOfType<Slot>();
    }
    private void OnMouseDown()
    {
        slot.mouseIsOut = false;
    }
    public void PurchaseLevel1Turret()
    {
        type = 1;
        button.gameObject.SetActive(true);

    }

    public void PurchaseLevel2Turret()
    {
        type = 2;
        button.gameObject.SetActive(true);
       
    }

    public void PurchaseLevel3Turret()
    {
        type = 3;
        button.gameObject.SetActive(true);
        
    }

    public void PurchaseLevel4Turret()
    {
        type = 4;
        button.gameObject.SetActive(true);
    }

    public void BuyTurret()
    {
        switch (type)
        {
            case 1:
                amount1++;
                PlayerPrefs.SetInt(nameof(amount1), amount1);
                break;

            case 2:
                amount2++;
                PlayerPrefs.SetInt(nameof(amount2), amount2);
                break;

            case 3:
                amount3++;
                PlayerPrefs.SetInt(nameof(amount3), amount3);
                break;

            case 4:
                amount4++;
                PlayerPrefs.SetInt(nameof(amount4), amount4);
                break;
        }
    }



    public void UseTurret()
    {
        switch (type)
        {
            case 1:
                if (amount1 > 0 && check == false)
                {
                    check = true;
                    slot.lvl1Tur.gameObject.SetActive(true);
                    amount1--;
                    PlayerPrefs.SetInt(nameof(amount1), amount1);
                }
                break;

            case 2:
                if (amount2 > 0 && check == false)
                {
                    check = true;
                    slot.lvl2Tur.gameObject.SetActive(true);
                    amount2--;
                    PlayerPrefs.SetInt(nameof(amount2), amount2);
                }
                break;

            case 3:
                if (amount3 > 0 && check == false)
                {
                    check = true;
                    slot.lvl3Tur.gameObject.SetActive(true);
                    amount3--;
                    PlayerPrefs.SetInt(nameof(amount3), amount3);
                }
                break;

            case 4:
                if (amount4 > 0 && check == false)
                {
                    check = true;
                    slot.lvl4Tur.gameObject.SetActive(true);
                    amount4--;
                    PlayerPrefs.SetInt(nameof(amount4), amount4);
                }
                break;
        }
    }

    public void RemoveTurret()
    {
        if (check == true)
        {
            slot.lvl1Tur.gameObject.SetActive(false);

            slot.lvl2Tur.gameObject.SetActive(false);

            slot.lvl3Tur.gameObject.SetActive(false);

            slot.lvl4Tur.gameObject.SetActive(false);
            
            check = false;
            BuyTurret();
        }


    }




    private void Update()
    {
        Debug.Log("1 = " + amount1);
        Debug.Log("2 = " + amount2);
        Debug.Log("3 = " + amount3);
        Debug.Log("4 = " + amount4);
    }
}
