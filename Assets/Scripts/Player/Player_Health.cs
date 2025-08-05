using UnityEngine;
using TMPro;

public class Player_Health : MonoBehaviour
{
    public int Maximum_Health = 100;
    private int currentHealth;
    public GameObject player;

    public TMP_Text healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = Maximum_Health;
        UpdateHealthText();
    }

   

    public void TakeDamage(int damage)
    {
        Debug.Log("Player took damage: " + damage);
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, Maximum_Health);
        UpdateHealthText();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
     void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    public void Die()
    {
        Debug.Log("Player has died.");
        player.SetActive(false);
    }


}

