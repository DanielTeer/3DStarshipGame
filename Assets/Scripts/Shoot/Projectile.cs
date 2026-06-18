using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 40f;//Bullet movement speed

    [Tooltip("How much damage the projectile deals.")]
    public float damageAmount = 50f;//damage the bullet causes

    public float lifetime = 3f;//Destroy after 3 sec if I miss

    private Rigidbody rb;//Names rigidbody rb

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();//Grabs the rigid body and adds it to rb

        rb.useGravity = false;//laser beam
    }

    private void Start()
    {
        rb.linearVelocity = transform.forward * speed;//Movement of bullet

        // Destroy the projectile after a few seconds so old bullets do not stay forever.
        Destroy(gameObject, lifetime);//Calls the 3sec die if miss and destroy bullet
    }

    private void OnCollisionEnter(Collision collision)//Calls if collision detected
    {
        Health health = collision.gameObject.GetComponent<Health>();// looks for health on target

        if (health == null)//if no health
        {
            health = collision.gameObject.GetComponentInParent<Health>();//Also look for health on parent
        }

        if (health != null)//Found health
        {
            health.TakeDamage(damageAmount);//cause target to take damage
        }

        Destroy(gameObject);//destroy bullet if hit
    }
}
