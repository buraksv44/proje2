using UnityEngine;

public class Slot : MonoBehaviour
{
    Animator slotAnimator;
    public static Slot selectedSlot;
    public GameObject shopPanel;
    public TurretSpecs lvl1Tur, lvl2Tur, lvl3Tur, lvl4Tur;
    public TurretSpecs currentTurret;
    
    private void Awake()
    {
        slotAnimator = GetComponent<Animator>();
        shopPanel = GameObject.FindWithTag("Shop");
    }
    private void Start()
    {
        shopPanel.SetActive(false);
    }
    private void OnMouseDown()
    {
        selectedSlot = GetSelectedSlot();

        if(currentTurret.turret==null && shopPanel != null)
            shopPanel.SetActive(true);
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
            switch (currentTurret.type)
            {
                case 1:
                    lvl1Tur.turret.SetActive(true);
                    break;
                case 2:
                    lvl2Tur.turret.SetActive(true);
                    break;
                case 3:
                    lvl3Tur.turret.SetActive(true);
                    break;
                case 4:
                    lvl4Tur.turret.SetActive(true);
                    break;
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
