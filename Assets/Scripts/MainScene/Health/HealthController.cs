using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private GameObject scoreCounter;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject spawnersToOff;


    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }

    }
    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent HealthChanged;
    public bool isInvincible { get; set; }
    public void RemoveHealth(float healthRemoveAmount)
    {
        if(currentHealth == 0) {
            return;
        }
        if (isInvincible)
        {
            return;
        }
        currentHealth -= healthRemoveAmount;
        HealthChanged.Invoke();
        if(currentHealth == 0)
        {
            OnDied.Invoke();
            scoreCounter.GetComponent<ScoreCounter>().enabled = false;
            spawnersToOff.SetActive(false);
            gameOver.SetActive(true);
        } else
        {
            OnDamaged.Invoke();
        }
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
    public void AddHealth(float healthAddAmount) 
    {
        if (currentHealth == maxHealth)
        {
            return;
        }
        currentHealth += healthAddAmount;
        HealthChanged.Invoke();
        if (currentHealth > 0) 
        {
            currentHealth = maxHealth;
        }
    }
}
