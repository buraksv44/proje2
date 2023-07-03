using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Animator slotAnimator;
    public static Slot selectedSlot;
    internal GameObject shopPanel;
    public TurretSpecs noTurret,lvl1Tur, lvl2Tur, lvl3Tur, lvl4Tur;
    public TurretSpecs currentTurret;
    public List<TurretSpecs> turrets;
    Shop shop;
    public Transform buttonTransform;


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

        shop.turretPanel.transform.position = buttonTransform.position;
        //if (!shopPanel.activeInHierarchy) 
        //{
        //    shopPanel.SetActive (true);
            
        //}

        //if (currentTurret.turret == null)
        //{
        //    if (!shopPanel.activeInHierarchy)
        //    {
        //        shop.OpenShop();
        //    }
        //}
        //else 
        //{
        //    shop.sellButtonX.SetActive(true);
        //    shop.sellButton.transform.position = buttonTransform.position;

        //}
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
            else
            {
                foreach (TurretSpecs turret in turrets) 
                {
                    if(turret.turret.activeInHierarchy)
                    turret.turret.SetActive(false);
                }
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
