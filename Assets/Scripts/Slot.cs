using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Animator slotAnimator;
    public static Slot selectedSlot;
    internal GameObject shopPanel;
    public TurretSpecs lvl1Tur, lvl2Tur, lvl3Tur, lvl4Tur;
    public TurretSpecs currentTurret;
    public List<TurretSpecs> turrets;
    Shop shop;


    private void Awake()
    {
        slotAnimator = GetComponent<Animator>();
        shopPanel = GameObject.FindWithTag("Shop");
        shop = FindObjectOfType<Shop>();
    }
    private void Start()
    {
        shopPanel.SetActive(false);
        turrets.Add(lvl1Tur);
        turrets.Add(lvl2Tur);
        turrets.Add(lvl3Tur);
        turrets.Add(lvl4Tur);
    }
    private void OnMouseDown()
    {
        selectedSlot = GetSelectedSlot();

        if (currentTurret.turret == null && shopPanel != null && !shopPanel.activeInHierarchy)
        {
            shop.OpenShop();
        }
        else 
        {
            
        }
    }
    private void Update()
    {
        HoverAnimation();
        ActivateTurret();
    }
    public Slot GetSelectedSlot()
    {
        return this;
    }
    void ActivateTurret()
    {
        if (currentTurret == null)
        {
            return;
        }
        else
        {
            if (currentTurret.type != 0f) 
            {
                turrets[currentTurret.type - 1].turret.SetActive(true);
            }
        }
    }
    void HoverAnimation()
    {
        if (selectedSlot != null)
        {
            if (gameObject == selectedSlot.gameObject)
            {
                slotAnimator.SetBool("isSelected", true);
            }
            else
            {
                slotAnimator.SetBool("isSelected", false);
            }
        }
        else
        {
            slotAnimator.SetBool("isSelected", false);
        }
    }
}
