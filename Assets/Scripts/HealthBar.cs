using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    float maxTrainHealth= 200f;
    float currentTrainHealth;
    public TMP_Text text;

    private void Start()
    {
        currentTrainHealth = maxTrainHealth;
        SetMaxHealth(maxTrainHealth);
    }
    
    private void Update()
    {
        if (text != null)
        { 
            text.text = currentTrainHealth.ToString();
        }
    }
    

    public void SetMaxHealth(float health) 
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetHealth(float health) 
    {
        slider.value = health;
    }

    public void Damage(float amount) 
    {
        currentTrainHealth -= amount;
        if (currentTrainHealth < 0) 
        {
            currentTrainHealth = 0f;
        }
        SetHealth(currentTrainHealth);
    }
}
