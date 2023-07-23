using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    Animator slotAnimator;
    public static ActivateTurrets selectedSlot;
    internal GameObject shopPanel;
    Shop shop;
    public Transform buttonTransform;
    ActivateTurrets activateTurrets;
    


    private void Awake()
    {
        slotAnimator = GetComponent<Animator>();
        shopPanel = GameObject.FindWithTag("Shop");
        shop = FindObjectOfType<Shop>();
        activateTurrets = GetComponent<ActivateTurrets>();
    }
    private void Start()
    {
        shopPanel.SetActive(false);

    }
    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        return;
        shop.shopOpened = true;
        selectedSlot = GetSelectedSlot();

        shop.turretPanel.transform.position = buttonTransform.position;
    }
    private void Update()
    {
        HoverAnimation();
    }
    public ActivateTurrets GetSelectedSlot()
    {
        return activateTurrets;
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
