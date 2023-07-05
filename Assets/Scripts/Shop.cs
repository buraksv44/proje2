using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Shop : MonoBehaviour
{
    ActivateTurrets activateTurrets;
    public GameObject buyButton;
    public GameObject sellButton;
    public GameObject removeButton;
    public GameObject openShopButton;
    public GameObject turretPanel;
    public GameObject selectIcon;
    public GameObject placeButton;
    TMP_Text placeButtonText;
    public TMP_Text text1, text2, text3, text4;
    public TurretSpecs selectedTurret;
    internal Animator shopAnimator;
    internal GameObject shopPanel;
    CanvasGroup shopCanvasGroup;
    bool inInventory = false;
    public List<Button> shopButtons;
    public bool shopOpened = false;


    private void Awake()
    {
        activateTurrets = FindObjectOfType<ActivateTurrets>();
        shopPanel = transform.GetChild(0).gameObject;
        shopAnimator = shopPanel.GetComponent<Animator>();
        shopCanvasGroup = GetComponent<CanvasGroup>();
        placeButtonText = placeButton.transform.GetChild(0).GetComponent<TMP_Text>();

    }

    private void Start()
    {
        shopCanvasGroup.alpha = 0f;
    }
    private void Update()
    {
        UIElements();
    }

    void MoveSelectIconTo(Button button)
    {
        if (!selectIcon.activeInHierarchy)
            selectIcon.SetActive(true);

        selectIcon.transform.position = button.transform.position;
    }

    public void SelectLevel1Turret()
    {
        selectedTurret = activateTurrets.lvl1Tur;
        MoveSelectIconTo(shopButtons[0]);
    }

    public void SelectLevel2Turret()
    {
        selectedTurret = activateTurrets.lvl2Tur;
        MoveSelectIconTo(shopButtons[1]);
    }

    public void SelectLevel3Turret()
    {
        selectedTurret = activateTurrets.lvl3Tur;
        MoveSelectIconTo(shopButtons[2]);
    }

    public void SelectLevel4Turret()
    {
        selectedTurret = activateTurrets.lvl4Tur;
        MoveSelectIconTo(shopButtons[3]);
    }

    public void BuyTurret()
    {
        selectedTurret.amount++;
    }
    public void SellTurret()
    {
        Slot.selectedSlot.currentTurret = Slot.selectedSlot.noTurret;
        Slot.selectedSlot = null;
    }
    public void RemoveTurret()
    {
        Slot.selectedSlot.currentTurret.amount++;
        Slot.selectedSlot.currentTurret = Slot.selectedSlot.noTurret;
        Slot.selectedSlot = null;
    }
    void StashTurret()
    {
        if (Slot.selectedSlot.currentTurret.type != 0f)
        {
            Slot.selectedSlot.turrets[Slot.selectedSlot.currentTurret.type - 1].turret.SetActive(false);
            Slot.selectedSlot.currentTurret.amount++;
        }
    }
    public void PlaceTurret()
    {
        if (Slot.selectedSlot.currentTurret != null && selectedTurret.amount > 0)
        {
            StashTurret();
            selectedTurret.amount--;
        }
        Slot.selectedSlot.currentTurret = activateTurrets.turrets[selectedTurret.type - 1];
        Slot.selectedSlot = null;
    }
    public void OpenShop()
    {
        if (inInventory || !shopPanel.activeInHierarchy)
        {
            StartCoroutine("HideShop");
            StartCoroutine("SetShop");
        }
    }
    public void CloseShop()
    {
        StartCoroutine("HideShop");
        Slot.selectedSlot = null;
        selectedTurret = null;
        shopOpened = false;
    }
    public void OpenInventory()
    {
        if (!inInventory)
        {
            StartCoroutine("HideShop");
            StartCoroutine("SetInventory");
        }
    }
    IEnumerator HideShop()
    {
        shopAnimator.SetTrigger("shopClose");
        yield return new WaitForSeconds(0.15f);
        shopPanel.SetActive(false);
        shopCanvasGroup.alpha = 0f;
    }
    IEnumerator SetShop()
    {
        yield return new WaitForSeconds(0.15f);
        foreach (TurretSpecs turret in activateTurrets.turrets)
        {
            turret.shopButton.gameObject.SetActive(true);
        }
        shopPanel.SetActive(true);
        inInventory = false;
        shopCanvasGroup.alpha = 1.0f;
        selectedTurret = null;
    }
    IEnumerator SetInventory()
    {
        yield return new WaitForSeconds(0.15f);
        foreach (TurretSpecs turret in activateTurrets.turrets)
        {
            if (turret.amount <= 0)
            {
                turret.shopButton.gameObject.SetActive(false);
            }
        }
        shopPanel.SetActive(true);
        inInventory = true;
        shopCanvasGroup.alpha = 1.0f;
        selectedTurret = null;
    }
    void UIElements()
    {
        text1.text = activateTurrets.lvl1Tur.amount.ToString();
        text2.text = activateTurrets.lvl2Tur.amount.ToString();
        text3.text = activateTurrets.lvl3Tur.amount.ToString();
        text4.text = activateTurrets.lvl4Tur.amount.ToString();

        if (selectedTurret != null && Slot.selectedSlot != null && selectedTurret.amount > 0 && selectedTurret.type != Slot.selectedSlot.currentTurret.type)
        {
            placeButton.gameObject.SetActive(true);
            if (Slot.selectedSlot.currentTurret.type != 0)
            {
                placeButtonText.text = "Replace";
            }
            else
            {
                placeButtonText.text = "Place";
            }
        }
        else
        {
            placeButton.gameObject.SetActive(false);
        }

        if (selectedTurret == null || inInventory || selectedTurret.turret == null)
        {
            buyButton.SetActive(false);
        }
        else
        {
            buyButton.SetActive(true);
            buyButton.transform.position = shopButtons[selectedTurret.type - 1].transform.position;
        }


        if (selectedTurret != null && selectedTurret.turret != null)
        {
            selectIcon.gameObject.SetActive(true);
        }

        else
        {
            selectIcon.gameObject.SetActive(false);
        }

        if (Slot.selectedSlot != null)
        {
            turretPanel.SetActive(true);

            if (Slot.selectedSlot.currentTurret.type == 0)
            {
                sellButton.SetActive(false);
                removeButton.SetActive(false);
            }
            else
            {
                sellButton.SetActive(true);
                removeButton.SetActive(true);
            }
        }
        else
        {
            sellButton.SetActive(false);
            removeButton.SetActive(false);
            turretPanel.SetActive(false);
        }

        if (!shopPanel.activeInHierarchy)
        {
            openShopButton.SetActive(true);
        }
        else
        {
            openShopButton.SetActive(false);
        }
    }
}
