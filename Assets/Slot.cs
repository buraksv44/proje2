using System.Collections;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Animator animator;
    public bool mouseIsOut=false;
    
    public static GameObject selectedSlot;

    GameObject shop;
    public static GameObject lvl1Tur, lvl2Tur, lvl3Tur, lvl4Tur;
    

    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        shop = GameObject.FindWithTag("Shop");
        
        

    }
    private void Start()
    {
        shop.SetActive(false);
    }



    private void OnMouseEnter()
    {
        mouseIsOut = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("seçildi");
        animator.SetBool("isSelected", true);
        selectedSlot = GetSelectedSlot();
        if(shop != null)
            shop.SetActive(true);
        
        
              
        
    }
    private void OnMouseExit()
    {
        mouseIsOut = true;
        Debug.Log("mouseçýktý");
        
    }
    IEnumerator DeselectNode() 
    {
        if (mouseIsOut && Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isSelected", false);
            Debug.Log("saldý");
        }
            return null;
    }
    private void Update()
    {
        InvokeRepeating("DeselectNode", 0, 0.5f);
           
    }

    public GameObject GetSelectedSlot() 
    {
        return this.gameObject;
    }

}
