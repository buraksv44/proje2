using System.Collections;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Animator animator;
    public bool mouseIsOut = false;

    public static GameObject selectedSlot;
    public GameObject lvl1Tur, lvl2Tur, lvl3Tur, lvl4Tur;
    GameObject _shop;
    shop shp;




    private void Awake()
    {
        animator = GetComponent<Animator>();
        _shop = GameObject.FindWithTag("Shop");
        shp = FindObjectOfType<shop>();


    }
    private void Start()
    {
        _shop.SetActive(false);
    }



    private void OnMouseEnter()
    {
        mouseIsOut = false;
    }

    private void OnMouseDown()
    {

        animator.SetBool("isSelected", true);
        selectedSlot = GetSelectedSlot();
        if (_shop != null)
            _shop.SetActive(true);
    }
    private void OnMouseExit()
    {
        mouseIsOut = true;

    }
    IEnumerator DeselectNode()
    {
        if (mouseIsOut && Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isSelected", false);
        }
        return null;
    }
    private void Update()
    {
        InvokeRepeating("DeselectNode", 0, 0.5f);
        TurretSel();

    }

    public GameObject GetSelectedSlot()
    {
        return this.gameObject;
    }


    void TurretSel()
    {
        switch (shp.type)
        {
            case 1:

                lvl1Tur = selectedSlot.transform.GetChild(0).GetChild(0).gameObject;
                break;

            case 2:
                lvl2Tur = selectedSlot.transform.GetChild(0).GetChild(1).gameObject;

                break;

            case 3:
                lvl3Tur = selectedSlot.transform.GetChild(0).GetChild(2).gameObject;

                break;

            case 4:
                lvl4Tur = selectedSlot.transform.GetChild(0).GetChild(3).gameObject;

                break;
        }
    }
}
