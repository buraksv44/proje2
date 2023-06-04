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


    void RightButton()
    {
        rightAnim.SetTrigger("RightMelee");

    }
    void LeftButton()
    {
        leftAnim.SetTrigger("LeftMelee");

    }
    void BackButton()
    {

        backAnim.SetTrigger("BackMelee");
    }

}
