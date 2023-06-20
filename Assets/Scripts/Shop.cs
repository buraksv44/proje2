using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    Slot slot;
    public Button buyButton;
    public Button placeTurret;
    internal int amount1, amount2, amount3, amount4;
    public TMP_Text text1, text2, text3, text4;
    TurretSpecs selectedTurret;
    internal int amount = 0;
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
        buyButton.gameObject.SetActive(true);
    }

    public void SelectLevel2Turret()
    {
        selectedTurret = slot.lvl2Tur;
        buyButton.gameObject.SetActive(true);
    }

    public void SelectLevel3Turret()
    {
        selectedTurret = slot.lvl3Tur;
        buyButton.gameObject.SetActive(true);
    }

    public void SelectLevel4Turret()
    {
        selectedTurret = slot.lvl4Tur;
        buyButton.gameObject.SetActive(true);
    }

    public void BuyTurret()
    {
        switch (selectedTurret.type)
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

    public void PlaceTurret()
    {
        if (Slot.selectedSlot.currentTurret != null && GetCurrentAmount() > 0)
        {
            StashTurret();
        }

        switch (selectedTurret.type)
        {
            case 1:

                if (amount1 > 0)
                {
                    Slot.selectedSlot.currentTurret = slot.lvl1Tur;
                    amount1--;
                }
                break;

            case 2:

                if (amount2 > 0)
                {
                    Slot.selectedSlot.currentTurret = slot.lvl2Tur;
                    amount2--;
                }
                break;
            case 3:
                if (amount3 > 0)
                {
                    Slot.selectedSlot.currentTurret = slot.lvl3Tur;
                    amount3--;
                }
                break;
            case 4:
                if (amount4 > 0)
                {
                    Slot.selectedSlot.currentTurret = slot.lvl4Tur;
                    amount4--;
                }
                break;
        }

    }
    void UIElements()
    {
        text1.text = amount1.ToString();
        text2.text = amount2.ToString();
        text3.text = amount3.ToString();
        text4.text = amount4.ToString();

        if (amount1 > 0 || amount2 > 0 || amount3 > 0 || amount4 > 0)
        {
            placeTurret.gameObject.SetActive(true);
        }
    }
    void StashTurret()
    {
        switch (Slot.selectedSlot.currentTurret.type)
        {
            case 1:
                Slot.selectedSlot.lvl1Tur.turret.SetActive(false);
                amount1++;
                break;
            case 2:
                Slot.selectedSlot.lvl2Tur.turret.SetActive(false);
                amount2++;
                break;
            case 3:
                Slot.selectedSlot.lvl3Tur.turret.SetActive(false);
                amount3++;
                break;
            case 4:
                Slot.selectedSlot.lvl4Tur.turret.SetActive(false);
                amount4++;
                break;
        }
    }
    internal int GetCurrentAmount()
    {

        switch (selectedTurret.type)
        {
            case 1:
                amount = amount1;
                break;

            case 2:
                amount = amount2;
                break;
            case 3:
                amount = amount3;
                break;
            case 4:
                amount = amount4;
                break;
        }
        return amount;
    }
}
