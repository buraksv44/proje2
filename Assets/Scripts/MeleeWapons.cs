using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeWapons : MonoBehaviour
{
    public Button rightButton, leftButton, backButton;

    public Animator rightAnim, leftAnim, backAnim;


    void Start()
    {

    }


   public void RightButton()
    {
        rightAnim.SetTrigger("RightMelee");

    }
   public void LeftButton()
    {
        leftAnim.SetTrigger("LeftMelee");

    }
   public void BackButton()
    {

        backAnim.SetTrigger("BackMelee");
    }

}
