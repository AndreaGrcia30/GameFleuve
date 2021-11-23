using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField]
    Gradient gradient;
    [SerializeField]
    Image fill;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        //Debug.Log($"current health{GameManager.instance.CurrentGameData.CurrentPlayerHealth}");
        //SetHealth(GameManager.instance.CurrentGameData.CurrentPlayerHealth);
    }

    //void OnLevelWasLoaded(int level) => SetHealth(GameManager.instance.CurrentGameData.CurrentPlayerHealth);

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
}
