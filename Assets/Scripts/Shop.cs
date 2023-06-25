using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    Slot slot;
    public Button buyButton;
    public Button placeTurret;
    public TMP_Text text1, text2, text3, text4;
    public TurretSpecs selectedTurret;
    internal int amount = 0;
    public List<Image> shopButtonIcons;
    public List<Transform> shopBuyTransform;

    
    private void Awake()
    {
        slot = FindObjectOfType<Slot>();
    }


    private void Update()
    {
        UIElements();
    }

   
    public void SelectLevel1Turret()
    {
        selectedTurret = slot.lvl1Tur;
    }

    public void SelectLevel2Turret()
    {
        selectedTurret = slot.lvl2Tur;
    }

    public void SelectLevel3Turret()
    {
        selectedTurret = slot.lvl3Tur;
    }

    public void SelectLevel4Turret()
    {
        selectedTurret = slot.lvl4Tur;
    }

    public void BuyTurret()
    {
        selectedTurret.amount++;
    }

    public void PlaceTurret()
    {
        if (Slot.selectedSlot.currentTurret != null && selectedTurret.amount > 0)
        {
            StashTurret();
        }
        
        switch (selectedTurret.type)
        {
            case 1:
                Slot.selectedSlot.currentTurret = slot.lvl1Tur;
                break;
            case 2:
                Slot.selectedSlot.currentTurret = slot.lvl2Tur;
                break;
            case 3:
                Slot.selectedSlot.currentTurret = slot.lvl3Tur;
                break;
            case 4:
                Slot.selectedSlot.currentTurret = slot.lvl4Tur;
                break;
        }
        
        Slot.selectedSlot = null;
        selectedTurret = null;
        slot.shopPanel.SetActive(false);
    }
    

    void UIElements()
    {
        text1.text = slot.lvl1Tur.amount.ToString();
        text2.text = slot.lvl2Tur.amount.ToString();
        text3.text = slot.lvl3Tur.amount.ToString();
        text4.text = slot.lvl4Tur.amount.ToString();

        if (selectedTurret != null && Slot.selectedSlot != null && selectedTurret.amount > 0)
        {
            placeTurret.gameObject.transform.position = Slot.selectedSlot.gameObject.transform.position+new Vector3(-0.5f,1,0);
            placeTurret.gameObject.SetActive(true);
        }
        else 
        { 
            placeTurret.gameObject.SetActive(false); 
        }

        if (selectedTurret == null)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            switch (selectedTurret.type) 
            {
                case 1:
                    buyButton.transform.position = shopBuyTransform[0].position; break;
                case 2:
                    buyButton.transform.position = shopBuyTransform[1].position; break;
                case 3:
                    buyButton.transform.position = shopBuyTransform[2].position; break;
                case 4:
                    buyButton.transform.position = shopBuyTransform[3].position; break;
            }
            
        }
    }
    void StashTurret()
    {
        switch (Slot.selectedSlot.currentTurret.type)
        {
            case 1:
                Slot.selectedSlot.lvl1Tur.turret.SetActive(false);

                break;
            case 2:
                Slot.selectedSlot.lvl2Tur.turret.SetActive(false);

                break;
            case 3:
                Slot.selectedSlot.lvl3Tur.turret.SetActive(false);

                break;
            case 4:
                Slot.selectedSlot.lvl4Tur.turret.SetActive(false);

                break;
        }
        Slot.selectedSlot.currentTurret.amount++;
        selectedTurret.amount--;
    }
}
