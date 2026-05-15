using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

   public Image hpFill;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

       UpdateHPBar();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHPBar()
    {
        hpFill.fillAmount = currentHealth / maxHealth;
    }
}