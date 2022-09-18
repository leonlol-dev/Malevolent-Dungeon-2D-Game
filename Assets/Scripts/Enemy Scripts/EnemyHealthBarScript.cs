using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Script that controls the UI health bars on the enemies.
public class EnemyHealthBarScript : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;

    private int maxHealth;

    public void SetMaxHealth(int _maxHealth)
    {
        maxHealth = _maxHealth;
        slider.maxValue = _maxHealth;
        slider.value = _maxHealth;
        text.text = _maxHealth + "/" + _maxHealth;
    }

    public void SetHealth(int _health)
    {
        slider.value = _health;
        text.text = _health + "/" + maxHealth;
    }
}
