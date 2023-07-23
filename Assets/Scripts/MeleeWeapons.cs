using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeWeapons : MonoBehaviour
{
    public Animator Anim;
    GameObjects gameObjects;
    public int meleeType;
    List<GameObject> zombies;
    
    bool isEnabled = false;
    public int cooldown;
    public float fillAmount;
    //public Image rightImage;
    //public Image leftImage;
    //public Image backImage;
    public Image image;

    void Start()
    {
        gameObjects = FindObjectOfType<GameObjects>();
    }
    public void RightButton()
    {
        Anim.SetTrigger("RightMelee");
        MeleeWeapon();
    }
    public void LeftButton()
    {
        Anim.SetTrigger("LeftMelee");
        MeleeWeapon();
    }
    public void BackButton()
    {
        Anim.SetTrigger("BackMelee");
        MeleeWeapon();
    }
    public void MeleeWeapon()
    {
        if (meleeType == 1)
        {
            zombies = gameObjects.rightMelee;
            
        }
        else if (meleeType == 2)
        {
            zombies = gameObjects.leftMelee;
     

        }
        else if(meleeType == 3)
        {
            zombies = gameObjects.backMelee;

        }
        
        for (int i = 0; i < zombies.Count; i++)
        {
            if (zombies[i] != null)
            {
                zombies[i].gameObject.GetComponent<ZombieMovement>().health = 0;                
            }
        }
        StartCoroutine(Cooldown());
        
    }

    IEnumerator Cooldown() 
    {
        image.fillAmount = 0;
        //for (float fillAmount = 0; fillAmount <= 1; fillAmount += 1 / cooldown * Time.deltaTime)
        //{
        //    image.fillAmount += fillAmount;
        //}
        yield return null;
    }
}