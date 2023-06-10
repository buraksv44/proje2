using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeWapons : MonoBehaviour
{
    public Button Button;
    public Animator Anim;
    GameObjects gameObjects;
    public int meleeType;
    List<GameObject> zombies;
    void Start()
    {
        
        gameObjects = FindObjectOfType<GameObjects>();
    }


    public void RightButton()
    {
        Anim.SetTrigger("RightMelee");
        MeleeWapon();
    }
    public void LeftButton()
    {
        Anim.SetTrigger("LeftMelee");
        MeleeWapon();
    }
    public void BackButton()
    {
        Anim.SetTrigger("BackMelee");
        MeleeWapon();
    }

    public void MeleeWapon()
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
        
    }







}