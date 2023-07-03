using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Shop : MonoBehaviour
{
    Slot slot;
    public Button buyButton;
    public GameObject sellButton;
    public GameObject removeButton;
    public GameObject openShopButton;
    public GameObject turretPanel;
    public Button placeTurret;
    public TMP_Text text1, text2, text3, text4;
    public TurretSpecs selectedTurret;
    internal int amount = 0;
    public List<Transform> shopBuyTransform;
    internal Animator shopAnimator;
    internal GameObject shopPanel;
    CanvasGroup shopCanvasGroup;
    bool inInventory = false;
    public GameObject selectIcon;
    public List<Button> shopButtons;
    
    private void Awake()
    {
        slot = FindObjectOfType<Slot>();
        shopPanel = transform.GetChild(0).gameObject;
        shopAnimator = shopPanel.GetComponent<Animator>();
        shopCanvasGroup = GetComponent<CanvasGroup>();
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
        selectedTurret = slot.lvl1Tur;
        MoveSelectIconTo(shopButtons[0]);
    }

    public void SelectLevel2Turret()
    {
        selectedTurret = slot.lvl2Tur;
        MoveSelectIconTo(shopButtons[1]);
    }

    public void SelectLevel3Turret()
    {
        selectedTurret = slot.lvl3Tur;
        MoveSelectIconTo(shopButtons[2]);
    }

    public void SelectLevel4Turret()
    {
        selectedTurret = slot.lvl4Tur;
        MoveSelectIconTo(shopButtons[3]);
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
            selectedTurret.amount--;
        }
        
        Slot.selectedSlot.currentTurret = slot.turrets[selectedTurret.type-1];

        Slot.selectedSlot = null;
        selectedTurret = null;
        StartCoroutine("HideShop");
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
    }
    public void OpenInventory() 
    {
        if (!inInventory)
        {
            StartCoroutine("HideShop");
            StartCoroutine("SetInventory");
        }
    }
    public IEnumerator HideShop() 
    {
        shopAnimator.SetTrigger("shopClose");
        yield return new WaitForSeconds(0.15f);
        shopPanel.SetActive(false);
        shopCanvasGroup.alpha = 0f;
    }
    IEnumerator SetShop() 
    {
        yield return new WaitForSeconds(0.15f);
        foreach (TurretSpecs turret in slot.turrets)
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
        foreach (TurretSpecs turret in slot.turrets)
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
        text1.text = slot.lvl1Tur.amount.ToString();
        text2.text = slot.lvl2Tur.amount.ToString();
        text3.text = slot.lvl3Tur.amount.ToString();
        text4.text = slot.lvl4Tur.amount.ToString();

        if (selectedTurret != null && Slot.selectedSlot != null && selectedTurret.amount > 0)
        {
            //placeTurret.gameObject.transform.position = Slot.selectedSlot.gameObject.transform.position+new Vector3(-0.5f,1,0);
            placeTurret.gameObject.SetActive(true);
        }
        else 
        { 
            placeTurret.gameObject.SetActive(false); 
        }

        if (selectedTurret == null || inInventory || selectedTurret.turret == null)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.transform.position = shopBuyTransform[selectedTurret.type - 1].position;
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
    void StashTurret()
    {
        if (Slot.selectedSlot.currentTurret.type != 0f)
        {
            Slot.selectedSlot.turrets[Slot.selectedSlot.currentTurret.type - 1].turret.SetActive(false);
            Slot.selectedSlot.currentTurret.amount++;
        }
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
}
