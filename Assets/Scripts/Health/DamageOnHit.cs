using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageAmount = 100f;//Damage amount

    public bool destroySelfAfterDamage = false;//Is this object destroyed

    private void OnCollisionEnter(Collision collision)//calls on collision detection
    {
        Health otherHealth = collision.gameObject.GetComponent<Health>();//Does the other object have a health component

        if (otherHealth == null)//Starship has Colliders that are children of the empty game object Starship_player so look at parent
        {
            otherHealth = collision.gameObject.GetComponentInParent<Health>();//Check the parent store in otherHealth
        }

        if (otherHealth != null)//Health or not
        {
            otherHealth.TakeDamage(damageAmount);//Health take damage

            if (destroySelfAfterDamage)//Destroy this object bool
            {
                Destroy(gameObject);//do it
            }
        }
    }
}
