using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;//max health

    public float currentHealth;//Current health

    private Death deathComponent;//Dead
    private bool isDead = false;//not dead

    private void Awake()
    {
        currentHealth = maxHealth;//Start full health

        deathComponent = GetComponent<Death>();//Grab the die component and add it to the name deathComponent
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDead)//If dead do nothing
        {
            return;
        }

        currentHealth -= damageAmount;//Tage damage and store new value in currentHealth

        if (currentHealth <= 0f)//If health is zero
        {
            currentHealth = 0f;//Set zurrent health to zero
            Die();//then call die function
        }
    }

    public void Heal(float healAmount)
    {
        if (isDead)//cant heal if your dead
        {
            return;//nothng if dead
        }

        currentHealth += healAmount;//add health to currentHealth
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);//Clamp max health ampunt
    }

    private void Die()//How to die
    {
        isDead = true;//Sets the private bool to true

        if (deathComponent != null)//Checks death component. Can we die
        {
            deathComponent.Die();//calls die from death.cs
        }
        else
        {
            Destroy(gameObject);//still gunna die though
        }
    }
}
