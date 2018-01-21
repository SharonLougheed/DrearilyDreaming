using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour {

    private PlayerHealth playerHealth;
    private Slider healthBar;
    private Text healthBarText;

    private int currentHealth,
                maxHealth;

    private void Awake() {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GetComponentInChildren<Slider>();
        healthBarText = GetComponentInChildren<Text>();
    }
    private void Start() {
        currentHealth = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        healthBarText.text = currentHealth + "/" + maxHealth;
    }
    private void Update() {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        currentHealth = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        healthBarText.text = currentHealth + "/" + maxHealth;
    }
}
