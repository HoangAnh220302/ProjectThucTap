using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float currentHealth;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 10f;
    public Image frontHealth;
    public Image backHealth;
    private void Start()
    {
        currentHealth = maxHealth;

    }
    private void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
        if(Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Heal(5);
        }
    }
    public void UpdateHealthUI()
    {
        float fillFront = frontHealth.fillAmount;
        float fillBack = backHealth.fillAmount;
        float hFraction = currentHealth/maxHealth;
        if(fillBack > hFraction)
        {
            frontHealth.fillAmount = hFraction;
            backHealth.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete *= percentComplete;
            backHealth.fillAmount = Mathf.Lerp(fillBack, hFraction, percentComplete);
        }
        if (fillFront < hFraction)
        {
            backHealth.color = Color.green;
            backHealth.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete *= percentComplete;
            backHealth.fillAmount = Mathf.Lerp(fillBack, backHealth.fillAmount, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        lerpTimer = 0f;
    }
    public void Heal(float healing)
    {
        currentHealth += healing;
        lerpTimer = 0f;
    }
}
