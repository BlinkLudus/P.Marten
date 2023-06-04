using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthDisplay : MonoBehaviour
{
    // This will contain the slider component attached to this object
    // Slider = variable is in the form of a slider component
    Slider bossHealthBar;

    // This is the boss' health component that we can ask info about the boss health
    BossHealth boss;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the Slider component of this game object
        // (the one this script is attached to)
        // Storing it in the healthBar value
        bossHealthBar = GetComponent<Slider>();

        // Search the entire scene for the bossHealth component
        // and store it in the boss variable
        boss = FindObjectOfType<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create temporary float variables
        // So we can use float division
        float bCurrentHealth = boss.GetHealth();
        float bMaxHealth = boss.bStartingHealth;

        // The slider value should be between 0 and 1, with 0 being empty and 1 being full
        // We divide the current health by max health to get a number between 0 and 1
        bossHealthBar.value = bCurrentHealth / bMaxHealth;
    }
}
