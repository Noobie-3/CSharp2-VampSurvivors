using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public Image ExpBar;
    public TextMeshProUGUI levelText;
    GameController gc;

    // Start is called before the first frame update
    void Start ()
    {
        gc = GameObject.FindWithTag("GC").GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        levelText.text = "Lv. " + gc.level;
        slider.maxValue = gc.experienceToNextLevel;
        slider.value = gc.getXP();
    }
}
