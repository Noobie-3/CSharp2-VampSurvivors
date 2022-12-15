using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    GameController gc;

    void Start()
    {
        gc = GameObject.FindWithTag("GC").GetComponent<GameController>();
    }

    void FixedUpdate()
    {
        slider.maxValue = gc.maxHealth;
        slider.value = gc.getHealth();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
