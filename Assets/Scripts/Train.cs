using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train : MonoBehaviour
{
    public Image Healtbar;
    public Text Healt;
    public int healtbar;
    // Start is called before the first frame update
    void Start()
    {
       healtbar=((int)Healtbar.fillAmount);
        Healt.text = healtbar.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Healtbar.fillAmount -=0.01f;
            Debug.Log(Healtbar);

        }
        if (Input.GetMouseButton(1))
        {
            Healtbar.fillAmount +=0.01f;
            Debug.Log(Healtbar);

        }
    }
}
