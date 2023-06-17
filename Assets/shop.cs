using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    Slot slot;
    public Button button;
    int amount1, amount2, amount3, amount4;
    TMPro.TextMeshPro text1, text2, text3, text4;
    GameObject currentTurret;

    int type;




    private void OnMouseDown()
    {
        slot.mouseIsOut = false;
    }
    public void PurchaseLevel1Turret()
    {
        if (amount1 > 0)
        {
            
            if (currentTurret != null)
            {
                //currentTurret = slot.lvl1Tur;
                Slot.lvl1Tur.gameObject.SetActive(true);
               // currentTurret.SetActive(true);
            }
        }
        
        type = 1;
        button.gameObject.SetActive(true);
        if (Slot.selectedSlot != null)
        {
            Debug.Log("lvl1 alýndý" + Slot.selectedSlot.name);
        }

    }

    public void PurchaseLevel2Turret()
    {
        type = 2;
        button.gameObject.SetActive(true);
        if (Slot.selectedSlot != null)
        {
            Debug.Log("lvl2 alýndý" + Slot.selectedSlot.name);
        }
    }

    public void PurchaseLevel3Turret()
    {
        type = 3;
        button.gameObject.SetActive(true);
        if (Slot.selectedSlot != null)
        {
            Debug.Log("lvl3 alýndý" + Slot.selectedSlot.name);
        }
    }

    public void PurchaseLevel4Turret()
    {

        type = 4;
        button.gameObject.SetActive(true);
        if (Slot.selectedSlot != null)
        {
            Debug.Log("lvl4 alýndý" + Slot.selectedSlot.name);
        }
    }

    public void BuyTurret()
    {
        switch (type)
        {
            case 1:
                amount1++;
                break;
            case 2:
                amount2++;
                break;
            case 3:
                amount3++;
                break;
            case 4:
                amount4++;
                break;

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
